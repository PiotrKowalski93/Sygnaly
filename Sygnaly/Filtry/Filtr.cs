using Sygnaly.Okna;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Filtry
{
    public abstract class Filtr
    {
        protected Okno window;
        protected List<Complex> filter = null;
        protected int order;
        protected double lowFrqCutoff;
        protected double highFrqCutoff;
        protected double samplingRate;

        public Filtr(Okno window, int order, double lowFrqCutoff, double highFrqCutoff, double samplingRate)
        {
            this.window = window;
            this.order = order;
            this.lowFrqCutoff = lowFrqCutoff;
            this.highFrqCutoff = highFrqCutoff;
            this.samplingRate = samplingRate;
        }

        public abstract List<Complex> getFilter();
    }
}
