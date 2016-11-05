using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyCiagle
{
    class SkokJednostkowy : SygnalCiagly
    {
        public double ts;

        public SkokJednostkowy(double A, double t1, double d)
        {
            this.A = A;
            this.t1 = t1;
            this.d = d;
            ts = d / 2;
            for (int i = 0; i < x.Count; i++)
            {
                y.Add(Licz(x[i]));
            }
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
