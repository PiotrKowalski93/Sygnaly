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
    class SygnalSinusoidalnyDwupolowkowo : SygnalCiagly
    {
        public SygnalSinusoidalnyDwupolowkowo(double A, double T, double t1, double d)
        {
            this.A = A;
            this.T = T;
            this.t1 = t1;
            this.d = d;

            x = new List<Complex>();
            y = new List<Complex>();

            double j = t1;

            for (int i = 0; i < n; i++)
            {
                x.Add(j);
                j = j + (d / (n - 1));
                y.Add(Licz(x[i].Real, A));
            }

            //for (int i = 0; i < x.Count; i++)
            //{
            //    y.Add(Licz(x[i].Real, A));
            //}
        }

        private double Licz(double x, double y)
        {
            double z = y * Math.Sin(2 * Math.PI / T * x);
            return Math.Abs(z);
        }
    }
}
