using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Sygaly
{

    [Serializable]
    class SygnalDyskretny : Sygnal
    {
        public double LiczSrednia()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i].Real;
            srednia = (1 / ((y[y.Count - 1].Real) - y[0].Real + 1)) * sum;

            return srednia;
        }

        public double LiczSredniaBezwzgledna()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i].Real;
            sredniaBezwzgledna = (1 / ((y[y.Count - 1].Real) - y[0].Real + 1)) * Math.Abs(sum);

            return sredniaBezwzgledna;
        }

        public double LiczSredniaMoc()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i].Real;
            sredniaMoc = (1 / ((y[y.Count - 1].Real) - y[0].Real + 1)) * Math.Abs(sum);

            return sredniaMoc;
        }

        public double LiczWariancje()
        {
            double sum = 0;
            for (int i = 0; i < y.Count; i++)
            {
                sum = y[i].Real - LiczSrednia();
            }
            wariancja = (1 / y.Count) * sum;

            return wariancja;
        }

        public double LiczWartoscSkuteczna()
        {
            wartoscSkuteczna = Math.Sqrt(sredniaMoc);

            return wartoscSkuteczna;
        }
    }
}
