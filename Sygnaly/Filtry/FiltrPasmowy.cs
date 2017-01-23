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
            filter = createBandstop();
            int half = order >> 1;
            for (int i = 0; i < filter.Count(); i++) {
                filter[i] = new Complex(((i == half ? 1.0 : 0.0) - filter[i].Real), 0);
            }
        }

        public Complex[] createBandstop()
        {
            Complex[] low = new FiltrDolnoprzepustowy(window, order, lowFrqCutoff, samplingRate).getFilter();
            Complex[] high = new FiltrGornoprzepustowy(window, order, highFrqCutoff, samplingRate).getFilter();
            for (int i = 0; i < low.Count(); i++)
            {
                low[i] = new Complex(low[i].Real + high[i].Real, 0);
            }
            return low;
        }

        public override Complex[] getFilter()
        {
            return filter;
        }
    }
}
