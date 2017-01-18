using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Okna
{
    public class Blackman : Okno
    {
        protected double alpha;

        public Blackman(double alpha)
        {
            this.alpha = alpha;
        }

        public Blackman()
        {
            alpha = 0.16f;
        }
                
        public override double value(int length, int index)
        {
            double a0 = (1 - this.alpha) / 2f;
            double a1 = 0.5f;
            double a2 = this.alpha / 2f;

            return a0 - a1 * (double)Math.Cos(TWO_PI * index / (length - 1)) + a2 * (double)Math.Cos(4 * Math.PI * index / (length - 1));
        }
    }
}
