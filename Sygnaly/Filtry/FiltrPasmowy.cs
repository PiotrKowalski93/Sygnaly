using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Sygnaly.Okna;

namespace Sygnaly.Filtry
{
    public class FiltrPasmowy : Filtr
    {
        public FiltrPasmowy(Okno window, int order, double lowFrqCutoff, double highFrqCutoff, double samplingRate) : base(window, order, lowFrqCutoff, highFrqCutoff, samplingRate)
        {
        }

        public override Complex[] getFilter()
        {
            return filter;
        }
    }
}
