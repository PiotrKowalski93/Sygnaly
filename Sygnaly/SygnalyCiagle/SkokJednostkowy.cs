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
    class SkokJednostkowy : SygnalCiagly
    {
        public double ts;

        public SkokJednostkowy(double A, double t1, double d)
        {
            this.A = A;
            this.t1 = t1;
            this.d = d;
            ts = d / 2;

            x = new List<Complex>();
            y = new List<Complex>();

            double j = t1;

            for (int i = 0; i < n; i++)
            {
                x.Add(j);
                j = j + ((d - t1) / (n - 1));
                y.Add(Licz(x[i].Real));
            }

            //for (int i = 0; i < x.Count; i++)
            //{
            //    y.Add(Licz(x[i].Real));
            //}
        }

        private double Licz(double x)
        {
            if (x < ts)
                return 0;
            else if (x == ts)
            {
                double k = A / 2;
                return k;
            }
            else
                return A;
        }
    }
}
