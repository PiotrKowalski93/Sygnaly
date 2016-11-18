using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyDyskretne
{
    class ImpulsJednostkowy : SygnalDyskretny
    {
        
        public ImpulsJednostkowy(double A, double t1, double d)
        {
            this.A = A;
            this.t1 = t1;
            this.d = d;

            //x = new List<System.Numerics.Complex>();
            //y = new List<System.Numerics.Complex>();
            //double j = t1;

            //for (int i = 0; i <= n; i++)
            //{
            //    x.Add(j);
            //    j = j + (d / (n - 1));

            //    y.Add(Calculate(x[i].Real));
            //}

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
                y.Add(Calculate(x[i].Real));
            }

            //for (int i = 0; i < x.Count; i++)
            //{
            //    y.Add(Calculate(x[i].Real));
            //}
        }

        private double Calculate(double x)
        {
            if (x == 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
