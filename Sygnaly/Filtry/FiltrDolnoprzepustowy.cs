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
    public class FiltrDolnoprzepustowy : Filtr
    {
        public FiltrDolnoprzepustowy(Okno window, int order, double lowFrqCutoff, double samplingRate) : base(window, order, lowFrqCutoff, 0, samplingRate)
        {
            double cutoff = lowFrqCutoff / samplingRate;

            //filter = new Complex[order + 1];
            filter = new List<Complex>();

            double factor = 2.0 * cutoff;
            int half = order >> 1;
            for (int i = 0; i < order + 1; i++)
            {
                filter.Add(new Complex(factor * SINCConverter.SINC(factor * (i - half)), 0));
            }

            filter = window.apply(filter);
        }

        public override List<Complex> getFilter()
        {
            return filter.ToList();
        }
    }
}
