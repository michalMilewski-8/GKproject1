﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjektGK1_1._0
{
    public enum ConstraintType
    {
        EQUAL_LENGTH,
        PARALLEL,
        NONE
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            polygons = new List<Polygon>();
            Polygon marek = new Polygon();
            marek.points = new List<VertexPoint>() { new VertexPoint(new Point(50, 50)), new VertexPoint(new Point(390, 50)), new VertexPoint(new Point(410, 380)), new VertexPoint(new Point(490, 400)), new VertexPoint(new Point(270, 520)), new VertexPoint(new Point(270, 400)), new VertexPoint(new Point(50, 400)) };
            polygons.Add(marek);
            AddLengthConstraint(new Point(70, 50));
            AddLengthConstraint(new Point(450, 390));

            AddParallelConstraint(new Point(270, 500));
            AddParallelConstraint(new Point(50, 90));

            drawing_panel.Invalidate();
        }


        #region Zmienne

        private const int VERTICE_SIZE = 10;
        private const int MouseBias = 5;
        private Size vartice_size = new Size(VERTICE_SIZE, VERTICE_SIZE);

        private int vertices_added_in_new_polygon;
        public List<Polygon> polygons = new List<Polygon>();
        private Point old_vertex_position;
        private int checked_polygon;
        private int checked_point;
        private bool is_draged;
        private bool mouse_down;
        private Point old_mouse_point;
        private int checked_line_end;

        private int times_clicked;
        private Constraint tmp;

        #endregion


        #region Rysowanie
        private void DrawVertice(Point p, Graphics e)
        {
            Point here = new Point(p.X, p.Y);
            here.Offset(-5, -5);
            e.FillEllipse(Brushes.Red, new Rectangle(here, vartice_size));
        }
        private void AddNewPolygon()
        {
            polygons.Add(new Polygon());
        }
        private void AddNewVertex(Point p)
        {
            polygons.Last().points.Add(new VertexPoint(new Point(p.X, p.Y)));
        }
        private void AddNewVertexAfter(Point p, int poly, int vertex)
        {
            Polygon pol = polygons[poly];
            pol.RemoveConstraint(pol.points[vertex]);
            polygons[poly].points.Insert(vertex + 1, new VertexPoint(new Point(p.X, p.Y)));

            drawing_panel.Invalidate();
        }
        private void AddPolygon(MouseEventArgs e)
        {
            if (vertices_added_in_new_polygon == 0)
            {
                AddNewPolygon();
                AddNewVertex(e.Location);
                vertices_added_in_new_polygon++;
            }
            else
            {
                AddNewVertex(e.Location);
                vertices_added_in_new_polygon++;
            }
            drawing_panel.Invalidate();
        }
        private void DrawLine(Point a, Point b, Graphics e, Brush br)
        {
            MidpointLine(a.X, a.Y, b.X, b.Y, e, br);
        }
        private void MidpointLine(int x, int y, int x2, int y2, Graphics e, Brush b)
        {
            //http://tech-algorithm.com/articles/drawing-line-using-bresenham-algorithm/
            int w = x2 - x;
            int h = y2 - y;
            int dx1 = 0, dy1 = 0, dx2 = 0, dy2 = 0;
            if (w < 0) dx1 = -1; else if (w > 0) dx1 = 1;
            if (h < 0) dy1 = -1; else if (h > 0) dy1 = 1;
            if (w < 0) dx2 = -1; else if (w > 0) dx2 = 1;
            try
            {
                int longest = Math.Abs(w);
                int shortest = Math.Abs(h);
                if (!(longest > shortest))
                {
                    longest = Math.Abs(h);
                    shortest = Math.Abs(w);
                    if (h < 0) dy2 = -1; else if (h > 0) dy2 = 1;
                    dx2 = 0;
                }
                int numerator = longest >> 1;
                for (int i = 0; i <= longest; i++)
                {
                    PutPixel(x, y, e, b);
                    numerator += shortest;
                    if (!(numerator < longest))
                    {
                        numerator -= longest;
                        x += dx1;
                        y += dy1;
                    }
                    else
                    {
                        x += dx2;
                        y += dy2;
                    }
                }
            }
            catch (Exception err)
            {
                return;
            }

        }
        private void PutPixel(int x, int y, Graphics e, Brush b)
        {
            e.FillRectangle(b, x, y, 1, 1);
        }
        private void DrawPolygon(Polygon poly, Graphics e)
        {

            VertexPoint old = poly.points[0];
            for (int i = 1; i < poly.points.Count; i++)
            {
                DrawLine(old.p, poly.points[i].p, e, old.brush);
                if (old.following_edge_constrain == ConstraintType.EQUAL_LENGTH)
                {
                    Point midpoint = new Point(old.p.X + (poly.points[i].p.X - old.p.X) / 2, old.p.Y + (poly.points[i].p.Y - old.p.Y) / 2);
                    midpoint.Offset(-VERTICE_SIZE, -VERTICE_SIZE);
                    Rectangle rec = new Rectangle(midpoint.X, midpoint.Y, VERTICE_SIZE * 2, VERTICE_SIZE * 2);
                    e.FillEllipse(Brushes.Blue, rec);
                    midpoint.Offset(VERTICE_SIZE / 2, VERTICE_SIZE / 2);
                    e.DrawString(old.constraint_id.ToString(), SystemFonts.DefaultFont, Brushes.White, midpoint);
                }
                else if (old.following_edge_constrain == ConstraintType.PARALLEL)
                {
                    Point midpoint = new Point(old.p.X + (poly.points[i].p.X - old.p.X) / 2, old.p.Y + (poly.points[i].p.Y - old.p.Y) / 2);
                    midpoint.Offset(-VERTICE_SIZE, -VERTICE_SIZE);
                    Rectangle rec = new Rectangle(midpoint.X, midpoint.Y, VERTICE_SIZE * 2, VERTICE_SIZE * 2);
                    e.FillEllipse(Brushes.DarkOliveGreen, rec);
                    midpoint.Offset(VERTICE_SIZE / 2, VERTICE_SIZE / 2);
                    e.DrawString(old.constraint_id.ToString(), SystemFonts.DefaultFont, Brushes.White, midpoint);
                }

                old = poly.points[i];
            }
            DrawLine(poly.points.Last().p, poly.points[0].p, e, poly.points.Last().brush);
            if (poly.points.Last().following_edge_constrain == ConstraintType.EQUAL_LENGTH)
            {
                Point midpoint = new Point(poly.points.Last().p.X + (poly.points[0].p.X - poly.points.Last().p.X) / 2, poly.points.Last().p.Y + (poly.points[0].p.Y - poly.points.Last().p.Y) / 2);
                midpoint.Offset(-VERTICE_SIZE, -VERTICE_SIZE);
                Rectangle rec = new Rectangle(midpoint.X, midpoint.Y, VERTICE_SIZE * 2, VERTICE_SIZE * 2);
                e.FillEllipse(Brushes.Blue, rec);
                midpoint.Offset(VERTICE_SIZE / 2, VERTICE_SIZE / 2);
                e.DrawString(poly.points.Last().constraint_id.ToString(), SystemFonts.DefaultFont, Brushes.White, midpoint);
            }
            else if (poly.points.Last().following_edge_constrain == ConstraintType.PARALLEL)
            {
                Point midpoint = new Point(poly.points.Last().p.X + (poly.points[0].p.X - poly.points.Last().p.X) / 2, poly.points.Last().p.Y + (poly.points[0].p.Y - poly.points.Last().p.Y) / 2);
                midpoint.Offset(-VERTICE_SIZE, -VERTICE_SIZE);
                Rectangle rec = new Rectangle(midpoint.X, midpoint.Y, VERTICE_SIZE * 2, VERTICE_SIZE * 2);
                e.FillEllipse(Brushes.DarkOliveGreen, rec);
                midpoint.Offset(VERTICE_SIZE / 2, VERTICE_SIZE / 2);
                e.DrawString(poly.points.Last().constraint_id.ToString(), SystemFonts.DefaultFont, Brushes.White, midpoint);
            }

            foreach (var p in poly.points)
            {
                DrawVertice(p.p, e);
            }
        }
        private void RefreshImage(Graphics e)
        {
            for (int i = 0; i < polygons.Count; i++)
            {
                polygons[i].Popraw();
            }
            foreach (var poly in polygons)
            {
                DrawPolygon(poly, e);
            }
        }
        private void MovePolygon(Point old, Point n, int poly)
        {
            int diffX = n.X - old.X;
            int diffY = n.Y - old.Y;

            for (int i = 0; i < polygons[poly].points.Count; i++)
            {
                Point older = polygons[poly].points[i].p;
                polygons[poly].points[i].p = new Point(older.X + diffX, older.Y + diffY);
            }
            drawing_panel.Invalidate();

        }
        private void DeleteVertice(Point p)
        {
            var res = FindIfOnVertex(p);
            if (res.Item1)
            {
                if (polygons[res.Item3].points.Count <= 3)
                {
                    polygons.RemoveAt(res.Item3);
                }
                else
                {
                    Polygon poly = polygons[res.Item3];
                    poly.RemoveConstraint(poly.points[res.Item2]);
                    poly.RemoveConstraint(poly.points[res.Item2 > 0 ? res.Item2 - 1 : poly.points.Count - 1]);
                    poly.points.RemoveAt(res.Item2);

                }
                drawing_panel.Invalidate();
            }
        }
        private void DeletePolygon(Point p)
        {
            var res = FindIfOnLine(p);
            if (res.Item1)
            {
                polygons.RemoveAt(res.Item3);
                drawing_panel.Invalidate();
            }
        }
        private void MoveEdge(Point old, Point n, int poly, int start_vertex, int end_vertex)
        {
            int diffX = n.X - old.X;
            int diffY = n.Y - old.Y;

            Point older = polygons[poly].points[start_vertex].p;
            polygons[poly].points[start_vertex].p = new Point(older.X + diffX, older.Y + diffY);
            older = polygons[poly].points[end_vertex].p;
            polygons[poly].points[end_vertex].p = new Point(older.X + diffX, older.Y + diffY);

            drawing_panel.Invalidate();

        }
        public void DeleteConstrint(MouseEventArgs e)
        {
            var res = FindIfOnLine(e.Location);
            if (res.Item1)
            {
                var poly = polygons[res.polygon];
                poly.RemoveConstraint(poly.points[res.fvertex]);
                drawing_panel.Invalidate();
            }
        }

        #endregion


        #region Logika

        private (bool, int, int) FindIfOnVertex(Point p)
        {
            foreach (var poly in polygons)
            {
                foreach (var v in poly.points)
                {
                    if (Math.Sqrt(Math.Abs((p.X - v.p.X) * (p.Y - v.p.Y))) <= MouseBias)
                    {
                        return (true, poly.points.IndexOf(v), polygons.IndexOf(poly));
                    }
                }
            }
            return (false, 0, 0);
        }
        private void DeleteNotCompletedPolygon()
        {
            if (vertices_added_in_new_polygon != 0)
            {
                polygons.Remove(polygons.Last());
                vertices_added_in_new_polygon = 0;
                drawing_panel.Invalidate();
            }
        }
        private (bool, int fvertex, int polygon, int svertex) FindIfOnLine(Point p)
        {
            foreach (var poly in polygons)
            {
                if (SegmentIntersectsCircle(poly.points[0].p, poly.points[1].p, p, 3 * MouseBias))
                    return (true, 0, polygons.IndexOf(poly), 1);

                for (int i = 1; i < poly.points.Count - 1; i++)
                {
                    if (SegmentIntersectsCircle(poly.points[i].p, poly.points[i + 1].p, p, MouseBias))
                        return (true, i, polygons.IndexOf(poly), i + 1);
                }
                if (SegmentIntersectsCircle(poly.points.Last().p, poly.points[0].p, p, MouseBias))
                    return (true, poly.points.Count - 1, polygons.IndexOf(poly), 0);

            }
            return (false, 0, 0, 0);
        }
        private bool SegmentIntersectsCircle(Point a, Point b, Point z, int r)
        {
            if (a.X != b.X)
            {
                if ((z.X < a.X + MouseBias && z.X > b.X - MouseBias) || (z.X > a.X - MouseBias && z.X < b.X + MouseBias))
                {
                    return CircleLineIntersect(z.X, z.Y, r, a, b);
                }
                else
                    return false;
            }
            else if (a.Y != b.Y)
            {
                if ((z.Y < a.Y + MouseBias && z.Y > b.Y - MouseBias) || (z.Y > a.Y - MouseBias && z.Y < b.Y + MouseBias))
                {
                    return CircleLineIntersect(z.X, z.Y, r, a, b);
                }
            }
            return false;
        }
        private bool CircleLineIntersect(int x, int y, int radius, Point linePoint1, Point linePoint2)
        {
            //https://stackoverflow.com/questions/18565416/circle-and-line-segment-collision-in-c-sharp

            Point p1 = new Point(linePoint1.X, linePoint1.Y);
            Point p2 = new Point(linePoint2.X, linePoint2.Y);
            p1.X -= x;
            p1.Y -= y;
            p2.X -= x;
            p2.Y -= y;
            float dx = p2.X - p1.X;
            float dy = p2.Y - p1.Y;
            float dr = (float)Math.Sqrt((double)(dx * dx) + (double)(dy * dy));
            float D = (p1.X * p2.Y) - (p2.X * p1.Y);

            float di = (radius * radius) * (dr * dr) - (D * D);

            if (di < 0) return false;
            else return true;
        }
        private void AddLengthConstraint(Point e)
        {
            var res = FindIfOnLine(e);
            if (res.Item1)
            {
                if (times_clicked == 0)
                {
                    tmp = new Length();
                    tmp.polygon = polygons[res.Item3];
                    tmp.a1 = polygons[res.Item3].points[res.fvertex];
                    tmp.b1 = polygons[res.Item3].points[res.svertex];
                    tmp.a1.brush = Brushes.Red;
                    times_clicked++;
                    drawing_panel.Invalidate();
                }
                else if (times_clicked == 1)
                {
                    if (tmp.polygon == polygons[res.polygon] && tmp.a1 != polygons[res.Item3].points[res.fvertex] && tmp.b1 != polygons[res.Item3].points[res.svertex])
                    {

                        if (tmp.polygon.points.FindIndex(0, match: (VertexPoint a) => { return (a.p.X == tmp.a1.p.X) && (a.p.Y == tmp.a1.p.Y); }) < tmp.polygon.points.FindIndex(0, match: (VertexPoint a) => { return (a.p.X == e.X) && (a.p.Y == e.Y); }))
                        {
                            tmp.a2 = polygons[res.Item3].points[res.fvertex];
                            tmp.b2 = polygons[res.Item3].points[res.svertex];
                            tmp.a1.brush = Brushes.Black;
                        }
                        else
                        {
                            tmp.a2 = tmp.a1;
                            tmp.b2 = tmp.b1;
                            tmp.a1 = polygons[res.Item3].points[res.fvertex];
                            tmp.b1 = polygons[res.Item3].points[res.svertex];
                            tmp.a2.brush = Brushes.Black;
                        }
                        times_clicked = 0;
                        if (tmp.polygon.AddConstraint(tmp))
                        {
                            tmp.a1.constraint_id = tmp.GetId();
                            tmp.a1.following_edge_constrain = ConstraintType.EQUAL_LENGTH;
                            tmp.a2.constraint_id = tmp.GetId();
                            tmp.a2.following_edge_constrain = ConstraintType.EQUAL_LENGTH;
                            tmp.IncrementId();

                        }
                        tmp.polygon.Popraw();
                        drawing_panel.Invalidate();
                    }
                    else
                    {
                        tmp.a1.brush = Brushes.Black;
                        tmp.error();
                        times_clicked = 0;
                        tmp = null;
                        drawing_panel.Invalidate();
                    }


                    tmp = null;
                    con_length.Checked = false;
                }
            }
        }
        private void AddParallelConstraint(Point e)
        {
            var res = FindIfOnLine(e);
            if (res.Item1)
            {
                if (times_clicked == 0)
                {
                    tmp = new Parallel();
                    tmp.polygon = polygons[res.Item3];
                    tmp.a1 = polygons[res.Item3].points[res.fvertex];
                    tmp.b1 = polygons[res.Item3].points[res.svertex];
                    tmp.a1.brush = Brushes.Red;
                    times_clicked++;
                    drawing_panel.Invalidate();
                }
                else if (times_clicked == 1)
                {
                    if (tmp.polygon == polygons[res.polygon] && tmp.a1 != polygons[res.Item3].points[res.fvertex] && tmp.b1 != polygons[res.Item3].points[res.svertex])
                    {
                        if (tmp.polygon.points.FindIndex(0, match: (VertexPoint a) => { return (a.p.X == tmp.a1.p.X) && (a.p.Y == tmp.a1.p.Y); }) < tmp.polygon.points.FindIndex(0, match: (VertexPoint a) => { return (a.p.X == e.X) && (a.p.Y == e.Y); }))
                        {
                            tmp.a2 = polygons[res.Item3].points[res.fvertex];
                            tmp.b2 = polygons[res.Item3].points[res.svertex];
                            tmp.a1.brush = Brushes.Black;
                        }
                        else
                        {
                            tmp.a2 = tmp.a1;
                            tmp.b2 = tmp.b1;
                            tmp.a1 = polygons[res.Item3].points[res.fvertex];
                            tmp.b1 = polygons[res.Item3].points[res.svertex];
                            tmp.a2.brush = Brushes.Black;
                        }
                        times_clicked = 0;
                        if ((tmp.a1 != tmp.b2 && tmp.b1 != tmp.a2) && tmp.polygon.AddConstraint(tmp))
                        {
                            tmp.a1.constraint_id = tmp.GetId();
                            tmp.a1.following_edge_constrain = ConstraintType.PARALLEL;
                            tmp.a2.constraint_id = tmp.GetId();
                            tmp.a2.following_edge_constrain = ConstraintType.PARALLEL;
                            tmp.IncrementId();

                        }
                        drawing_panel.Invalidate();
                        tmp.polygon.Popraw();
                    }
                    else
                    {
                        tmp.a1.brush = Brushes.Black;
                        tmp.error();
                        times_clicked = 0;
                        tmp = null;
                        drawing_panel.Invalidate();
                    }


                    tmp = null;
                    con_parallel.Checked = false;
                }
            }
        }
        public void NullTmpConstraint()
        {
            if (!(tmp is null))
            {
                if (!(tmp.a1 is null))
                    tmp.a1.brush = Brushes.Black;
                if (!(tmp.a2 is null))
                    tmp.a2.brush = Brushes.Black;
            }
            tmp = null;
            times_clicked = 0;
        }

        // Find the point of intersection between
        // the lines p1 --> p2 and p3 --> p4.
        // http://csharphelper.com/blog/2014/08/determine-where-two-lines-intersect-in-c/
        private void FindIntersection(
            PointF p1, PointF p2, PointF p3, PointF p4,
            out bool lines_intersect, out bool segments_intersect,
            out PointF intersection,
            out PointF close_p1, out PointF close_p2)
        {
            // Get the segments' parameters.
            float dx12 = p2.X - p1.X;
            float dy12 = p2.Y - p1.Y;
            float dx34 = p4.X - p3.X;
            float dy34 = p4.Y - p3.Y;

            // Solve for t1 and t2
            float denominator = (dy12 * dx34 - dx12 * dy34);

            float t1 =
                ((p1.X - p3.X) * dy34 + (p3.Y - p1.Y) * dx34)
                    / denominator;
            if (float.IsInfinity(t1))
            {
                // The lines are parallel (or close enough to it).
                lines_intersect = false;
                segments_intersect = false;
                intersection = new PointF(float.NaN, float.NaN);
                close_p1 = new PointF(float.NaN, float.NaN);
                close_p2 = new PointF(float.NaN, float.NaN);
                return;
            }
            lines_intersect = true;

            float t2 =
                ((p3.X - p1.X) * dy12 + (p1.Y - p3.Y) * dx12)
                    / -denominator;

            // Find the point of intersection.
            intersection = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);

            // The segments intersect if t1 and t2 are between 0 and 1.
            segments_intersect =
                ((t1 >= 0) && (t1 <= 1) &&
                 (t2 >= 0) && (t2 <= 1));

            // Find the closest points on the segments.
            if (t1 < 0)
            {
                t1 = 0;
            }
            else if (t1 > 1)
            {
                t1 = 1;
            }

            if (t2 < 0)
            {
                t2 = 0;
            }
            else if (t2 > 1)
            {
                t2 = 1;
            }

            close_p1 = new PointF(p1.X + dx12 * t1, p1.Y + dy12 * t1);
            close_p2 = new PointF(p3.X + dx34 * t2, p3.Y + dy34 * t2);
        }

        public bool cmp_point(Point p1,Point p2)
        {
            return !(p1.X > p2.X - 5 && p1.X < p2.X + 5 && p1.Y > p2.Y - 5 && p1.Y < p2.Y + 5);
        }

        public void AddNewVerticesOnIntersections()
        {
            List<Polygon> new_polygons = new List<Polygon>();
            bool isIntersecting = false;
            PointF closep1 = new PointF();
            PointF closep2 = new PointF();
            PointF randomp = new PointF();
            bool random = false;
            

            for (int k = 0; k < polygons.Count; k++)
            {
                List<(VertexPoint, VertexPoint)> toadd = new List<(VertexPoint, VertexPoint)>();
                new_polygons.Add(new Polygon());
                Polygon poly = polygons[k];

                for (int i = 0; i < poly.points.Count-1; i++)
                {


                    Point p1 = poly.points[i].p;
                    Point p2 = poly.points[i + 1].p;
                    Point p3;
                    Point p4;
                    for (int j = i + 1; j < poly.points.Count-1; j++)
                    {
                        isIntersecting = false;

                        p3 = poly.points[j].p;
                        p4 = poly.points[j + 1].p;
                        if (p1 != p3 && p2 != p4 && p1 != p4 && p2 != p3 && cmp_point(p1,p3) && cmp_point(p1, p4) && cmp_point(p2, p3) && cmp_point(p2, p4))
                        {
                            FindIntersection(p1, p2, p3, p4, out random, out isIntersecting, out randomp, out closep1, out closep2);

                            if (isIntersecting)
                            {
                                toadd.Add((poly.points[i], new VertexPoint(new Point((int)Math.Round(closep1.X), (int)Math.Round(closep1.Y)))));
                                toadd.Add((poly.points[j], new VertexPoint(new Point((int)Math.Round(closep2.X), (int)Math.Round(closep2.Y)))));
                                //poly.points.Insert(i, new VertexPoint(new Point((int)Math.Round(closep1.X), (int)Math.Round(closep1.Y))));
                                //poly.points.Insert(j, new VertexPoint(new Point((int)Math.Round(closep2.X), (int)Math.Round(closep2.Y))));

                            }
                        }

                    }

                    p3 = poly.points[poly.points.Count - 1].p;
                    p4 = poly.points[0].p;
                    if (p1 != p3 && p2 != p4 && p1 != p4 && p2 != p3 && cmp_point(p1, p3) && cmp_point(p1, p4) && cmp_point(p2, p3) && cmp_point(p2, p4))
                    {
                        FindIntersection(p1, p2, p3, p4, out random, out isIntersecting, out randomp, out closep1, out closep2);

                        if (isIntersecting)
                        {
                            toadd.Add((poly.points[i], new VertexPoint(new Point((int)Math.Round(closep1.X), (int)Math.Round(closep1.Y)))));
                            toadd.Add((poly.points.Last(), new VertexPoint(new Point((int)Math.Round(closep2.X), (int)Math.Round(closep2.Y)))));
                            //poly.points.Insert(i, new VertexPoint(new Point((int)Math.Round(closep1.X), (int)Math.Round(closep1.Y))));
                            //poly.points.Insert(0, new VertexPoint(new Point((int)Math.Round(closep2.X), (int)Math.Round(closep2.Y))));

                        }
                    }

                }

                foreach(var ad in toadd)
                {
                    poly.points.Insert(poly.points.IndexOf(ad.Item1)+1, ad.Item2);
                }

            }


            drawing_panel.Invalidate();
        }

        #endregion


        #region Events

        private void Drawing_panel_MouseClick(object sender, MouseEventArgs e)
        {

            if (add_polygon.Checked)
            {
                AddPolygon(e);
            }
            if (delete_vertice.Checked)
            {
                DeleteVertice(e.Location);
            }
            if (delete_polygon.Checked)
            {
                DeletePolygon(e.Location);
            }
            if (con_length.Checked)
            {
                AddLengthConstraint(e.Location);
            }
            if (con_parallel.Checked)
            {
                AddParallelConstraint(e.Location);
            }
            if (delete_constraint.Checked)
            {
                DeleteConstrint(e);
            }

        }
        private void Drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            RefreshImage(e.Graphics);
        }
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Escape)
            {
                DeleteNotCompletedPolygon();
            }
            if (e.KeyCode == Keys.Enter)
            {

                add_polygon.Checked = false;
                add_vertice.Checked = false;
                move_edge.Checked = false;
                move_polygon.Checked = false;
                move_vertice.Checked = false;
                delete_constraint.Checked = false;
                delete_polygon.Checked = false;
                delete_vertice.Checked = false;
                con_length.Checked = false;
                con_parallel.Checked = false;
                NullTmpConstraint();
                controls_panel.Refresh();
                drawing_panel.Invalidate();
            }

        }
        private void Add_polygon_CheckedChanged(object sender, EventArgs e)
        {
            if (vertices_added_in_new_polygon < 3)
                DeleteNotCompletedPolygon();
            else
                vertices_added_in_new_polygon = 0;
        }
        private void Drawing_panel_MouseDown(object sender, MouseEventArgs e)
        {
            if (move_vertice.Checked)
            {
                var res = FindIfOnVertex(e.Location);
                if (res.Item1)
                {
                    mouse_down = true;
                    old_vertex_position = polygons[res.Item3].points[res.Item2].p;
                    checked_polygon = res.Item3;
                    checked_point = res.Item2;
                    is_draged = true;
                }
            }
            if (add_vertice.Checked)
            {
                var res = FindIfOnLine(e.Location);
                if (res.Item1)
                {
                    mouse_down = true;
                    AddNewVertexAfter(e.Location, res.Item3, res.Item2);
                    checked_polygon = res.Item3;
                    checked_point = res.Item2 + 1;
                    is_draged = true;
                }
            }
            if (move_polygon.Checked || move_edge.Checked)
            {
                var res = FindIfOnLine(e.Location);
                if (res.Item1)
                {
                    mouse_down = true;
                    checked_polygon = res.Item3;
                    checked_point = res.Item2;
                    checked_line_end = res.Item4;
                    old_mouse_point = e.Location;
                    is_draged = true;
                }
            }
        }
        private void Drawing_panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouse_down && is_draged)
            {
                if (move_vertice.Checked || add_vertice.Checked)
                {
                    polygons[checked_polygon].points[checked_point].p = new Point(e.X, e.Y);
                    drawing_panel.Invalidate();
                }
                if (move_polygon.Checked)
                {
                    MovePolygon(old_mouse_point, e.Location, checked_polygon);
                    old_mouse_point = e.Location;
                }
                if (move_edge.Checked)
                {
                    MoveEdge(old_mouse_point, e.Location, checked_polygon, checked_point, checked_line_end);
                    old_mouse_point = e.Location;
                }
            }

        }
        private void Drawing_panel_MouseUp(object sender, MouseEventArgs e)
        {
            if (mouse_down && is_draged)
            {
                mouse_down = false;
            }
        }
        private void Clear_button_Click(object sender, EventArgs e)
        {
            polygons = new List<Polygon>();
            add_polygon.Checked = false;
            add_vertice.Checked = false;
            move_edge.Checked = false;
            move_polygon.Checked = false;
            move_vertice.Checked = false;
            delete_constraint.Checked = false;
            delete_polygon.Checked = false;
            delete_vertice.Checked = false;
            con_length.Checked = false;
            con_parallel.Checked = false;
            NullTmpConstraint();
            controls_panel.Refresh();
            drawing_panel.Invalidate();
        }
        private void Con_length_CheckedChanged(object sender, EventArgs e)
        {
            NullTmpConstraint();
        }
        private void Con_parallel_CheckedChanged(object sender, EventArgs e)
        {
            NullTmpConstraint();
        }


        #endregion

        private void zamien_Click(object sender, EventArgs e)
        {
            AddNewVerticesOnIntersections();
        }
    }

}
