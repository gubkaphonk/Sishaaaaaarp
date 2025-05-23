using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euclid
{
    public class Triangle
    {
        public Point A;
        public Point B;
        public Point C;

        public Segment AB => new Segment(A, B);
        public Segment AC => new Segment(A, C);
        public Segment BC => new Segment(B, C);

        public double Area
        {
            get
            {
                var p = (AB.Length + AC.Length + BC.Length) / 2;
                return Math.Sqrt(p * (p - AB.Length) * (p - AC.Length) * (p - BC.Length));
            }
        }

        public Triangle(Point a, Point b, Point c)
        {
            A = a;
            B = b;
            C = c;
        }
    }
}