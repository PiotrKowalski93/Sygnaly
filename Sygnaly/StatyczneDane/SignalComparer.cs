using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.StatyczneDane
{
    class SignalComparer
    {
        public static double CalculateMSE(SygnalDyskretny signal1, SygnalDyskretny signal2)
        {
            double result = 0;

            List<Complex> val1 = signal1.y;
            List<Complex> val2 = signal2.y;

            for (int i = 0; i < val1.Count; i++)
            {
                result += (val1[i].Real - val2[i].Real) * (val1[i].Real - val2[i].Real);
            }

            return result / val1.Count;
        }

        public static double CalculateSNR(SygnalDyskretny signal1, SygnalDyskretny signal2)
        {
            double result = 0;

            List<Complex> val1 = signal1.y;
            List<Complex> val2 = signal2.y;

            for (int i = 0; i < val1.Count; i++)
            {
                result += val1[i].Real * val2[i].Real;
            }

            return 10 * Math.Log10(result / CalculateMSE(signal1, signal2));
        }

        public static double CalculatePSNR(SygnalDyskretny signal1, SygnalDyskretny signal2)
        {            
            double max = 0;

            List<Complex> val1 = signal1.y;
            List<Complex> val2 = signal2.y;

            for (int i = 0; i < val1.Count; i++)
            {
                if (val1[i].Real > max)
                {
                    max = val1[i].Real;
                }
            }

            return 10 * Math.Log10(max / CalculateMSE(signal1, signal2));
        }

        public static double CalculateMD(SygnalDyskretny signal1, SygnalDyskretny signal2)
        {
            List<Complex> val1 = signal1.y;
            List<Complex> val2 = signal2.y;

            double max = 0;

            for (int i = 0; i < val1.Count; i++)
            {
                double tmp = Math.Abs(val1[i].Real - val2[i].Real);
                if (tmp > max)
                {
                    max = tmp;
                }
            }

            return max;
        }
    }
}
