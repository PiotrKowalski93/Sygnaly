using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Okna
{
    public class Hanning : Okno
    {
        public override double value(int lenght, int index)
        {
            return 0.5f * (1d - (double)Math.Cos(TWO_PI * index / (length - 1d)));
        }
    }
}
