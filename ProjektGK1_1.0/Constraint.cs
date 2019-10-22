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
    public class Constraint
    {
        public static int id = 1;
        public VertexPoint a1, b1, a2, b2;
        public Polygon polygon;
        public void error()
        {
            MessageBox.Show("Invalid constraint can not create such polygon", "error", MessageBoxButtons.OK);

        }
        public bool IsConstraintOnEdge(Point a, Point b)
        {
            return ((a1.p == a && b1.p == b) || (a1.p == b && b1.p == a) || (a2.p == a && b2.p == b) || (a2.p == b && b2.p == a));
        }
        public virtual bool IsConstraintValid() { return true; }
        public virtual void Popraw() { }
        public int GetId()
        {
            return id;
        }
        public void IncrementId()
        {
            id++;
        }
        public double SegmentLength(Point p, Point v)
        {
            double diffX = (v.X - p.X);
            double diffY = (v.Y - p.Y);

            return Math.Sqrt(diffX * diffX + diffY * diffY);
        }
    }

    public class Length : Constraint
    {
        public override bool IsConstraintValid()
        {
            double len1 = SegmentLength(a1.p, b1.p);
            double len2 = SegmentLength(a2.p, b2.p);

            return ((len1 >= len2 - 2) && (len1 <= len2 + 2));
        }
        public override void Popraw()
        {
            if (!IsConstraintValid())
            {
                double len = SegmentLength(a1.p, b1.p);
                if (SegmentLength(a2.p, b2.p) >= 0.01)
                {
                    double alfa = len / SegmentLength(a2.p, b2.p);
                    Point v = new Point(b2.p.X - a2.p.X, b2.p.Y - a2.p.Y);

                    v.X = (int)Math.Round(v.X * alfa);
                    v.Y = (int)Math.Round(v.Y * alfa);
                    if(v.X<20000 && v.Y <20000)
                    b2.p.X = a2.p.X + v.X;
                    b2.p.Y = a2.p.Y + v.Y;
                }
            }
        }
    }

    public class Parallel : Constraint
    {
        public double Angle(Point p, Point v, Point p2, Point v2)
        {
            Point diff1 = new Point(v.X - p.X, v.Y - p.Y);
            Point diff2 = new Point(v2.X - p2.X, v2.Y - p2.Y);

            return Iloczyn(diff1, diff2) / (Math.Sqrt(Iloczyn(diff1, diff1)) * Math.Sqrt(Iloczyn(diff2, diff2)));


            // return Math.Sqrt((p.X - v.X) * (p.Y - v.Y));
        }
        public double Iloczyn(Point diff1, Point diff2)
        {
            return diff1.X * diff2.X + diff1.Y * diff2.Y;
        }
        public override bool IsConstraintValid()
        {
            double angle = Angle(a1.p, b1.p, a2.p, b2.p);
            return angle >= 0.99999 || angle <= -0.999999;
        }
        public override void Popraw()
        {
            if (!IsConstraintValid())
            {
                double len = SegmentLength(a1.p, b1.p);
                double len2 = SegmentLength(a2.p, b2.p);
                double wsp = len2 / len;
                if (len >= 0.01)
                {
                    Point v = new Point(b1.p.X - a1.p.X, b1.p.Y - a1.p.Y);

                    v.X = (int)(Math.Round(v.X * wsp));
                    v.Y = (int)(Math.Round(v.Y * wsp));
                    if (Angle(a1.p, b1.p, a2.p, b2.p) > 0)
                    {
                        b2.p.X = a2.p.X + v.X;
                        b2.p.Y = a2.p.Y + v.Y;
                    }
                    else
                    {
                        b2.p.X = a2.p.X - v.X;
                        b2.p.Y = a2.p.Y - v.Y;
                    }
                }
            }
        }
    }
}
