using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Kwantyzatory
{
    public abstract class Quantizer
    {
        protected int bitsNumber;
        protected double step;
        protected double[] stepsTable;

        public Quantizer(int bitsNumber)
        {
            this.bitsNumber = bitsNumber;
            step = 1.0 / Math.Pow(2, bitsNumber);
            switch (bitsNumber)
            {
                case 1:
                    stepsTable = QuantizationTables.ONE;
                    break;
                case 2:
                    stepsTable = QuantizationTables.TWO;
                    break;
                case 4:
                    stepsTable = QuantizationTables.FOUR;
                    break;
                case 6:
                    stepsTable = QuantizationTables.SIX;
                    break;
                case 8:
                    stepsTable = QuantizationTables.EIGHT;
                    break;
                case 12:
                    stepsTable = QuantizationTables.TWELVE;
                    break;
                default:
                    stepsTable = QuantizationTables.SIXTEEN;
                    break;
            }
        }

        public abstract Complex quantizeSample(Complex value, double amplitude);

        protected int getInterval(double value)
        {
            return (int)(value / step);
        }
    }
}
