using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Okna
{
    public class Hamming : Okno
    {
        public override double value(int lenght, int index)
        {
            return 0.54d - 0.46d * (double)Math.Cos(TWO_PI * index / (length - 1));
        }
    }
}
