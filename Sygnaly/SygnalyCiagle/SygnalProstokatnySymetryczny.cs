using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyCiagle
{
    [Serializable]
    class SygnalProstokatnySymetryczny : SygnalCiagly
    {
        public SygnalProstokatnySymetryczny(double A, double T, double t1, double d, double kw)
        {
            this.A = A;
            this.T = T;
            this.t1 = t1;
            this.d = d;
            this.kw = kw;

            x = new List<Complex>();
            y = new List<Complex>();

            double j = t1;

            for (int i = 0; i < n; i++)
            {
                x.Add(j);
                j = j + (d / (n - 1));
                y.Add(Licz(x[i].Real));
            }
        }

        private double Licz(double x)
        {
            double p = x % T;
            if (p <= kw * T)
            {
                return A;
            }
            else
            {
                return -A;
            }
        }
    }
}
