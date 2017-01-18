using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Sygnaly.Okna;
using Sygnaly.Konwertery;

namespace Sygnaly.Filtry
{
    public class FiltrGornoprzepustowy : Filtr
    {
        public FiltrGornoprzepustowy(Okno window, int order, double lowFrqCutoff, double highFrqCutoff, double samplingRate) 
            : base(window, order, lowFrqCutoff, highFrqCutoff, samplingRate)
        {
            double cutoff = highFrqCutoff / samplingRate;
            filter = new Complex[order + 1];
            double factor = 2.0 * cutoff;
            int half = order >> 1;
            for (int i = 0; i < filter.Count(); i++)
            {
                filter[i] = new Complex((i == half ? 1.0 : 0.0) - factor * SINCConverter.SINC(factor * (i - half)), 0);
            }
            filter = window.apply(filter);
        }

        public override Complex[] getFilter()
        {
            return filter;
        }
    }
}
