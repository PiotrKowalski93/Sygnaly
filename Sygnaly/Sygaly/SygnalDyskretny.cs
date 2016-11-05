using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Sygaly
{
    class SygnalDyskretny : Sygnal
    {
        public double LiczSrednia()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i];
            srednia = (1 / ((y[y.Count - 1]) - y[0] + 1)) * sum;

            return srednia;
        }

        public double LiczSredniaBezwzgledna()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i];
            sredniaBezwzgledna = (1 / ((y[y.Count - 1]) - y[0] + 1)) * Math.Abs(sum);

            return sredniaBezwzgledna;
        }

        public double LiczSredniaMoc()
        {
            double sum = 0.0;
            for (int i = 0; i < y.Count; i++)
                sum = sum + y[i];
            sredniaMoc = (1 / ((y[y.Count - 1]) - y[0] + 1)) * Math.Abs(sum);

            return sredniaMoc;
        }

        public double LiczWariancje()
        {
            double sum = 0;
            for (int i = 0; i < y.Count; i++)
            {
                sum = y[i] - LiczSrednia();
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
