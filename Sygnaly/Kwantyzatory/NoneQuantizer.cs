using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Kwantyzatory
{
    public class NoneQuantizer : Quantizer
    {

    public NoneQuantizer(int bitsNumber) : base (bitsNumber)
    {

    }
        
    public override Complex quantizeSample(Complex value, double amplitude)
    {
        return value * amplitude;
    }

}
}
