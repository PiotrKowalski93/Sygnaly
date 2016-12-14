using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Kwantyzatory
{
    public class MeanQuantizer : Quantizer
    {

    public MeanQuantizer(int bitsNumber) : base (bitsNumber)
    {
    }

    
    public override Complex quantizeSample(Complex value, double amplitude)
    {
        if (Math.Abs(value.Real) == 1 || value.Real == 0)
        {
            return value * amplitude;
        }
        int sign = 1;
        if (value.Real < 0)
        {
            sign = -1;
        }
        int interval = getInterval(value.Real);
        double newReal = (stepsTable[sign * interval] + stepsTable[(sign * interval) + 1]) / 2.0;
        return new Complex(newReal * amplitude * sign, value.Imaginary);
    }
}
}
