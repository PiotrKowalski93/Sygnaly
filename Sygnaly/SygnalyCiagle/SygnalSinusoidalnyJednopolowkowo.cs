using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyCiagle
{
    class SygnalSinusoidalnyJednopolowkowo : SygnalCiagly
    {
        public SygnalSinusoidalnyJednopolowkowo(double A, double T, double t1, double d)
        {
            this.A = A;
            this.T = T;
            this.t1 = t1;
            this.d = d;

            for (int i = 0; i < x.Count; i++)
            {
                y.Add(Licz(x[i].Real, A));
            }
        }

        private double Licz(double x, double y)
        {
            double z = 2 * Math.PI / T * x;
            double wyn = A * Math.Sin(z);
            if (wyn > 0)
                return wyn;
            else
                return 0;
        }
    }
}
