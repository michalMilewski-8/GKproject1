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
    public class VertexPoint
    {
        public Point p;
        public Brush brush;
        public int constraint_id;
        public ConstraintType following_edge_constrain;
        public VertexPoint(Point point, Brush br)
        {
            p = point;
            brush = br;
            following_edge_constrain = ConstraintType.NONE;
        }
        public VertexPoint(Point point)
        {
            p = point;
            brush = Brushes.Black;
            following_edge_constrain = ConstraintType.NONE;
        }

    }
}
