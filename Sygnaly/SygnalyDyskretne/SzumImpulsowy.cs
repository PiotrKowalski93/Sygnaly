using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyDyskretne
{
    class SzumImpulsowy : SygnalDyskretny
    {
        private Random random = new Random();
        private double p = 0.5;

        public SzumImpulsowy(double A, double t1, double d)
        {
            this.A = A;
            this.t1 = t1;
            this.d = d;

            x = new List<System.Numerics.Complex>();
            y = new List<System.Numerics.Complex>();
            double j = t1;

            for (int i = 0; i <= n; i++)
            {
                x.Add(j);
                j = j + (d / (n - 1));
            }

            x.Add(new System.Numerics.Complex(0, 0));

            for (int i = 0; i <= n; i++)
            {
                y.Add(Calculate());
            }

            //for (int i = 0; i < x.Count; i++)
            //{
            //    y.Add( Calculate());
            //}
        }

        private double Calculate()
        {
            if (random.NextDouble() < p)
            {
                return A;
            }
            return 0;
        }
    }
}
