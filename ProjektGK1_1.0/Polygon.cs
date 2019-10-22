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
    public class Polygon
    {
        public List<VertexPoint> points;
        public List<Constraint> constraints;

        public void RemoveConstraint(Constraint con)
        {
            con.a1.constraint_id = -1;
            con.a1.following_edge_constrain = ConstraintType.NONE;
            con.a2.constraint_id = -1;
            con.a2.following_edge_constrain = ConstraintType.NONE;
            //con.b1.constraint_id = -1;
            //con.b1.following_edge_constrain = ConstraintType.NONE;
            //con.b2.constraint_id = -1;
            //con.b2.following_edge_constrain = ConstraintType.NONE;
            constraints.Remove(con);
        }
        public void RemoveConstraint(List<Constraint> con_list)
        {
            for (int i = 0; i < con_list.Count; i++)
            {
                Constraint con = con_list[i];
                con.a1.constraint_id = -1;
                con.a1.following_edge_constrain = ConstraintType.NONE;
                con.a2.constraint_id = -1;
                con.a2.following_edge_constrain = ConstraintType.NONE;
                //con.b1.constraint_id = -1;
                //con.b1.following_edge_constrain = ConstraintType.NONE;
                //con.b2.constraint_id = -1;
                //con.b2.following_edge_constrain = ConstraintType.NONE;
                constraints.Remove(con);
            }
        }
        public void RemoveConstraint(VertexPoint point)
        {
            int index = points.FindIndex((VertexPoint vp) => vp.p == point.p);
            if (index >= 0)
                if (IsConstraintOnEdge(point.p, (index + 1 < points.Count ? points[index + 1].p : points[0].p)))
                    RemoveConstraint(constraints.FindAll((Constraint con) => con.a1.p == point.p || con.a2.p == point.p));
        }
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
            foreach (var p in points)
            {
                int c = constraints.FindIndex((Constraint con) => { return con.a1.p == p.p; });
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
                    int c = constraints.FindIndex((Constraint con) => { return con.a1.p == p.p; });
                    if (c >= 0)
                    {
                        constraints[c].Popraw();
                    }
                }
            }

        }
        public bool AddConstraint(Constraint c)
        {
            if ((!IsConstraintOnEdge(c.a1.p, c.b1.p)) && (!IsConstraintOnEdge(c.a2.p, c.b2.p)))
            {
                constraints.Add(c);
                return true;
            }
            return false;
        }
        public bool IsConstraintsValid()
        {
            foreach (var c in constraints)
            {
                if (!c.IsConstraintValid())
                    return false;
            }
            return true;
        }
        public Polygon()
        {
            points = new List<VertexPoint>();
            constraints = new List<Constraint>();
        }

    }
}
