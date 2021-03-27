using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot_BlackWhite
{
    class Numbers
    {
        public double a; // real
        public double b; // imaginary

        public Numbers(double a, double b)
        {
            this.a = a;
            this.b = b;
        }

        public void Square()
        {
            double temp = (a * a) - (b * b);
            b = 2.0d * a * b;
            a = temp;
        }
        public double Magnitude()
        {
            return Math.Sqrt((a * a) + (b * b));
        }
        public void Add(Numbers c)
        {
            a +=  c.a;
            b +=  c.b;
        }
    }
}
