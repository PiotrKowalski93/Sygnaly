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

            for (int i = 0; i < x.Count; i++)
            {
                y.Add(Calculate(x[i]));
            }
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
