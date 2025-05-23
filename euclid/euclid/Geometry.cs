using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public static class Geometry
    {
        public const double EPSILON = 1E-13;

        public static Segment CreateSegment(Point a, Point b)
        {
            if (a.X == b.X && a.Y == b.Y)
                throw new ArgumentException("Концы отрезка совпадают");

            return new Segment(a, b);
        }

       
    }
}