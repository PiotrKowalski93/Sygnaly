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
    private Complex[] newValues;
    private int originalSamplingRate;
    private int newSamplingRate;
    Sygnal zrekonstruowany;

    public Sygnal Konwert(Sygnal input, int samplingRate, int originalSamplingRate)
    {
            values = new Complex[input.y.Count];
            int aLength = (int)(input.d *samplingRate);
            for (int i = 0; i < input.y.Count; i++)
            {
                values[i] = input.y[i];
            }
            newValues = new Complex[aLength];

            this.originalSamplingRate = originalSamplingRate;

            newSamplingRate = samplingRate;

            for (int i = 0; i < newValues.Count(); i++)
            {
                newValues[i] = interpolate(30, i, i);
            }
            //int ileDodatkowych = (int)(400 / (originalSamplingRate*input.d))-originalSamplingRate;
            //double roznica = (input.x[1].Real - input.x[0].Real) / (ileDodatkowych + 1);
            zrekonstruowany = new Sygnal();
            zrekonstruowany.x = new List<System.Numerics.Complex>();
            zrekonstruowany.y = new List<System.Numerics.Complex>();
            /*int j;
            for (int i = 0; i < input.x.Count; i++)
            {
                j = 0;
                zrekonstruowany.x.Add(input.x[i].Real);
                zrekonstruowany.y.Add(newValues[i+j]);

                if (i != input.x.Count)
                {
                    for (j = 1; j <= ileDodatkowych; j++)
                    {
                        if (i != input.x.Count)
                        {
                            
                                zrekonstruowany.x.Add(input.x[i].Real + (j * roznica));
                                zrekonstruowany.y.Add(newValues[i + j]);
                            
                        }

                    }
                }
            }*/
            double roznica = input.d/ newValues.Length;
            double ix=0;
            for (int i = 0; i < newValues.Length; i++)
            {
                zrekonstruowany.x.Add(ix);
                zrekonstruowany.y.Add(newValues[i]);
                ix += roznica;
            }
            zrekonstruowany.t1 = input.t1;
            zrekonstruowany.A = input.A;
            zrekonstruowany.d = input.d;
            zrekonstruowany.n = newValues.Length;
            //return new SygnalDyskretny(newValues, samplingRate, input.t1, input.A);
            return zrekonstruowany;
    }

    public Complex interpolate(int window, int oldSample, int newSample)
    {
        double ret=0;
        int start = newSample - (window / 2);

        if (start <= 0)
        {
            start = 0;
        }

        int end = newSample + (window / 2);

        if (end >= newValues.Count())
        {
            end = newValues.Count();
        }

        for (int i = start; i < end; i++)
        {
            double oldVal = values[(int)(i * (1.0 * originalSamplingRate / newSamplingRate))].Real;

            double factor = SINC((newSample - i) * (1.0 * originalSamplingRate / newSamplingRate));

            ret += oldVal*factor;
        }
        return new Complex(ret * (1.0 * originalSamplingRate / newSamplingRate), 0);
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
