using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Okna
{
    public abstract class Okno
    {
        public static double TWO_PI = (double)(2 * Math.PI);
        public int length;

        public Complex[] apply(Complex[] filter)
        {
            this.length = filter.Count();

            for (int n = 0; n < filter.Count(); n++)
            {
                double real = filter[n].Real;
                real *= value(filter.Count(), n);
                filter[n] = new Complex(real, 0);
            }
            return filter;
        }

        public Complex[] apply(Complex[] filter, int offset, int length)
        {
            this.length = length;

            for (int n = offset; n < offset + length; ++n)
            {
                double real = filter[n].Real;
                real *= value(length, n - offset);
                filter[n] = new Complex(real, 0);
            }
            return filter;
        }

        public Complex[] generateCurve(int length)
        {
            Complex[] samples = new Complex[length];
            for (int n = 0; n < length; n++)
            {
                samples[n] = new Complex(1d * value(length, n), 0);
            }
            return samples;
        }

        public abstract double value(int lenght, int index);
    }
}
