using System;
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
    public enum PolygonOperation
    {
        MOVE_VERTEX,
        CREATE_POLYGON,
        ADD_VERTEX
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            vertices_added_in_new_polygon = 0;
            times_clicked = 0;
            polygons = new List<Polygon>();

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
            polygons.Last().points.Add(new Point(p.X, p.Y));
        }
        private void AddNewVertexAfter(Point p, int poly, int vertex)
        {
            polygons[poly].points.Insert(vertex + 1, new Point(p.X, p.Y));
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
        private void DrawLine(Point a, Point b, Graphics e)
        {
            MidpointLine(a.X, a.Y, b.X, b.Y, e, Brushes.Black);
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
        private void PutPixel(int x, int y, Graphics e, Brush b)
        {
            e.FillRectangle(b, x, y, 1, 1);
        }
        private void DrawPolygon(Polygon poly, Graphics e)
        {

            Point old = poly.points[0];
            for (int i = 1; i < poly.points.Count; i++)
            {
                DrawLine(old, poly.points[i], e);
                old = poly.points[i];
            }
            DrawLine(poly.points.Last(), poly.points[0], e);
            foreach (var p in poly.points)
            {
                DrawVertice(p, e);
            }
        }
        private void RefreshImage(Graphics e)
        {
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
                Point older = polygons[poly].points[i];
                polygons[poly].points[i] = new Point(older.X + diffX, older.Y + diffY);
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
                    polygons[res.Item3].points.RemoveAt(res.Item2);
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

            Point older = polygons[poly].points[start_vertex];
            polygons[poly].points[start_vertex] = new Point(older.X + diffX, older.Y + diffY);
            older = polygons[poly].points[end_vertex];
            polygons[poly].points[end_vertex] = new Point(older.X + diffX, older.Y + diffY);

            drawing_panel.Invalidate();

        }

        #endregion

        #region Logika

        private (bool, int, int) FindIfOnVertex(Point p)
        {
            foreach (var poly in polygons)
            {
                foreach (var v in poly.points)
                {
                    if (Math.Sqrt(Math.Abs((p.X - v.X) * (p.Y - v.Y))) <= MouseBias)
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
                if (SegmentIntersectsCircle(poly.points[0], poly.points[1], p, 3 * MouseBias))
                    return (true, 0, polygons.IndexOf(poly), 1);

                for (int i = 1; i < poly.points.Count - 1; i++)
                {
                    if (SegmentIntersectsCircle(poly.points[i], poly.points[i + 1], p, MouseBias))
                        return (true, i, polygons.IndexOf(poly), i + 1);
                }
                if (SegmentIntersectsCircle(poly.points.Last(), poly.points[0], p, MouseBias))
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
                    times_clicked++;
                }
                else if (times_clicked == 1)
                {
                    if (tmp.polygon == polygons[res.polygon])
                    {
                        if (tmp.polygon.points.FindIndex(0, match: (Point a) => { return (a.X == tmp.a1.X) && (a.Y == tmp.a1.Y); }) < tmp.polygon.points.FindIndex(0, match: (Point a) => { return (a.X == e.X) && (a.Y == e.Y); }))
                        {
                            tmp.a2 = polygons[res.Item3].points[res.fvertex];
                            tmp.b2 = polygons[res.Item3].points[res.svertex];
                        }
                        else
                        {
                            tmp.a2 = tmp.a1;
                            tmp.b2 = tmp.b1;
                            tmp.a1 = polygons[res.Item3].points[res.fvertex];
                            tmp.b1 = polygons[res.Item3].points[res.svertex];
                        }
                        times_clicked = 0;
                    }
                    else
                    {
                        tmp.error();
                        times_clicked = 0;
                        tmp = null;
                    }
                    tmp.polygon.AddConstraint(tmp);
                    tmp.polygon.Popraw();
                    tmp = null;
                }
            }
        }


        public double SegmentLength(Point p, Point v)
        {
            return Math.Sqrt((p.X - v.X) * (p.Y - v.Y));
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

        }

        private void Drawing_panel_Paint(object sender, PaintEventArgs e)
        {
            RefreshImage(e.Graphics);
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (add_polygon.Checked)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    DeleteNotCompletedPolygon();
                }
                if (e.KeyCode == Keys.Enter)
                {
                    vertices_added_in_new_polygon = 0;
                    add_polygon.Checked = false;
                    add_polygon.Refresh();
                }
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
                    old_vertex_position = polygons[res.Item3].points[res.Item2];
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
                    polygons[checked_polygon].points[checked_point] = new Point(e.X, e.Y);
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
            vertices_added_in_new_polygon = 0;
            add_polygon.Checked = false;
            add_vertice.Checked = false;
            move_polygon.Checked = false;
            move_vertice.Checked = false;
            drawing_panel.Invalidate();
        }
        #endregion







        #region Classes
        public class Constraint
        {
            public Point a1, b1, a2, b2;
            public Polygon polygon;
            public void error()
            {
                MessageBox.Show("Invalid constraint can not create such polygon", "error", MessageBoxButtons.OK);

            }
            public bool IsConstraintOnEdge(Point a, Point b)
            {
                return ((a1 == a && b1 == b) || (a1 == b && b1 == a) || (a2 == a && b2 == b) || (a2 == b && b2 == a));
            }
            public double SegmentLength(Point p, Point v)
            {
                return Math.Sqrt((p.X - v.X) * (p.Y - v.Y));
            }
            public virtual bool IsConstraintValid() { return true; }
            public virtual void Popraw() { }
        }
        public class Length : Constraint
        {

            public override bool IsConstraintValid()
            {
                double len1 = SegmentLength(a1, b1);
                double len2 = SegmentLength(a2, b2);

                return ((len1 >= len2 - 2) && (len1 <= len2 + 2));
            }

            public override void Popraw()
            {
                if (!IsConstraintValid())
                {
                    double len = SegmentLength(a1, b1);
                    double alfa = len / SegmentLength(a2, b2);

                    Point v = new Point(a2.X - b2.X,a2.Y-b2.Y);

                    v.X = (int)(v.X*alfa);
                    v.Y = (int)(v.Y * alfa);
                    b2.X = a2.X + v.X;
                    b2.Y = a2.Y + v.Y;
                }
            }
        }

        public class Polygon
        {
            public List<Point> points;
            public List<Constraint> constraints;

            public bool IsConstraintOnEdge(Point a, Point b)
            {
                foreach (var c in constraints)
                {
                    if (c.IsConstraintOnEdge(a, b))
                        return true;
                }
                return false;
            }

            public void Popraw()
            {
                foreach(var p in points)
                {
                    int c = constraints.FindIndex((Constraint con) => { return (con.a2.X == p.X) && (con.a2.Y == p.Y); });
                    if (c >= 0)
                    {
                        constraints[c].Popraw();
                    }
                }
                if (IsConstraintsValid()) return;
                else
                {
                    foreach (var p in points)
                    {
                        int c = constraints.FindIndex((Constraint con) => { return (con.a2.X == p.X) && (con.a2.Y == p.Y); });
                        if (c >= 0)
                        {
                            constraints[c].Popraw();
                        }
                    }
                }

            }

            public void AddConstraint(Constraint c)
            {
                if ((!IsConstraintOnEdge(c.a1, c.b1)) && (!IsConstraintOnEdge(c.a2, c.b2)))
                    constraints.Add(c);

            }

            public bool IsConstraintsValid()
            {
                foreach(var c  in constraints)
                {
                    if (!c.IsConstraintValid())
                        return false;
                }
                return true;
            }

            public Polygon()
            {
                points = new List<Point>();
                constraints = new List<Constraint>();
            }

        }

        #endregion
    }






}
