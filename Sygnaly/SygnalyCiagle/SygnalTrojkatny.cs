using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyCiagle
{
    class SygnalTrojkatny : SygnalCiagly
    {
        public SygnalTrojkatny(double A, double T, double t1, double d, double kw)
        {
            this.A = A;
            this.T = T;
            this.t1 = t1;
            this.d = d;
            this.kw = kw;

            for (int i = 0; i < x.Count; i++)
            {
                y.Add(Licz(x[i]));
            }
        }

        private double Licz(double x)
        {
            double p = x % T;
            double z = kw * T;
            if (p <= z)
                return (A * p / z);
            else
                return (A * ((T - p) / (T - z)));
        }
    }
}
