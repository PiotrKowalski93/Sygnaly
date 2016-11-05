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

            for (int i = 0; i < x.Count; i++)
            {
                y.Add( Calculate());
            }
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
