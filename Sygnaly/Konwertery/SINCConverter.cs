using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Konwertery
{
    class SINCConverter
    {

    private Complex[] values;
    private List<Complex> newValues;
    private int originalSamplingRate;
    private int newSamplingRate;

    public SygnalDyskretny Convert(SygnalDyskretny input, int samplingRate)
    {
            //int aLength = (int)(input.T * samplingRate);

            //values = input.getValues();

            //newValues = new Complex[aLength];

            //originalSamplingRate = input.getSamplingRate();

            //newSamplingRate = samplingRate;

            //for (int i = 0; i < newValues.Count(); i++)
            //{
            //    newValues[i] = interpolate(30, i, i);
            //}
            //return new SygnalDyskretny(newValues, samplingRate, input.getStartTime(), input.getAmplitude());

            return null;
    }

    public Complex interpolate(int window, int oldSample, int newSample)
    {
        Complex ret = Complex.Zero;
        int start = newSample - (window / 2);

        if (start <= 0)
        {
            start = 0;
        }

        int end = newSample + (window / 2);

        if (end >= newValues.Count)
        {
            end = newValues.Count;
        }

        for (int i = start; i < end; i++)
        {
            double oldVal = values[(int)(i * (1.0 * originalSamplingRate / newSamplingRate))].Real;

            double factor = SINC((newSample - i) * (1.0 * originalSamplingRate / newSamplingRate));

            ret += new Complex(oldVal, 0) * new Complex(factor, 0);
        }
        return ret;
    }

    public static double SINC(double n)
    {
        if (n == 0)
        {
            return 1;
        }
        else
        {
            return Math.Sin(Math.PI * n) / (Math.PI * n);
        }
    }
}
}
