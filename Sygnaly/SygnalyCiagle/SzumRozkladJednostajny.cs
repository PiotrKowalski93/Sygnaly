using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.SygnalyCiagle
{
    class SzumRozkladJednostajny : SygnalCiagly
    {
        private Random random = new Random();

        public SzumRozkladJednostajny(double A, double t1, double d)
        {
            this.A = A;
            this.t1 = t1;
            this.d = d;

            x = new List<Complex>();
            y = new List<Complex>();

            double j = 0;

            for (int i = 0; i < n; i++)
            {
                x.Add(j);
                j = j + ((d - t1) / (n - 1));
                y.Add(random.NextDouble() * A);
            }
        }

    }
}
