using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Sygaly
{
    public class SygnalPochodny : SygnalDyskretny
    {
        public SygnalPochodny(List<Complex> values, int czestotliwosc, double startTime, double amplitude)
        {
            this.n = czestotliwosc;
            this.t1 = startTime;
            this.A = amplitude;
            this.y = values;
            this.T = values.Count() * 1.0 / czestotliwosc;
        }


    }
}
