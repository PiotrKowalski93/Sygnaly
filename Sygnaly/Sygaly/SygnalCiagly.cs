using Sygnaly.Sygaly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sygnaly.Sygaly
{
    class SygnalCiagly : Sygnal
    {
        private double xp;
        private double xk;
        private double dx;
        private double integ;
        int nint = 1000;

        public double PoliczSrednia()
        {
            srednia = (1 / ((t1 + d) - t1) * Integral(1));
            return srednia;
        }

        public double PoliczSredniaBezwzgledna()
        {
            sredniaBezwzgledna = (1 / ((t1 + d) - t1) * Integral(2));
            return sredniaBezwzgledna;
        }

        public double PoliczSredniaMoc()
        {
            sredniaMoc = (1 / ((t1 + d) - t1) * Integral(3));
            return sredniaMoc;
        }

        public double PoliczWariancje()
        {
            wariancja = (1 / ((t1 + d) - t1) * Integral(4));
            return wariancja;
        }

        public double PoliczWartoscSkuteczna()
        {
            wartoscSkuteczna = Math.Sqrt(sredniaMoc);
            return wartoscSkuteczna;
        }

        public double Integral(int x)
        {

            double dTemp = 0;

            if (T > 0)
            {
                dTemp = d - (d % T);
            }

            xp = t1;
            xk = t1 + d;

            int nTemp = 1000;

            dx = (xk - xp) / (double)nint;

            integ = 0;

            if (x == 1)
            {
                for (int i = 1; i < nint; i++)
                {
                    integ += Dubelc(xp + i * dx);
                }
                integ += (Dubelc(xp) + Dubelc(xk)) / 2;
            }
            else if (x == 2)
            {
                for (int i = 1; i < nint; i++)
                {
                    integ += Bezwzgledna(xp + i * dx);
                }
                integ += (Bezwzgledna(xp) + Bezwzgledna(xk)) / 2;
            }
            if (x == 3)
            {
                for (int i = 1; i < nint; i++)
                {
                    integ += Kwadrat(xp + i * dx);
                }
                integ += (Kwadrat(xp) + Kwadrat(xk)) / 2;
            }
            else if (x == 4)
            {
                srednia = (1 / ((t1 + d) - t1) * Integral(1));
                for (int i = 1; i < nTemp; i++)
                {
                    integ += Base(y[i].Real);
                }
                integ += (Base(xp) + Base(xk)) / 2;
            }
            integ *= dx;

            return integ;
        }

        protected double Dubelc(double x)
        {
            return x;
        }

        protected double Bezwzgledna(double x)
        {
            return Math.Abs(x);
        }

        protected double Kwadrat(double x)
        {
            return x * x;
        }

        protected double Base(double x)
        {
            return x - srednia;
        }
    }
}
