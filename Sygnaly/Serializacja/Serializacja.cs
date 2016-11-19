using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sygnaly.Sygaly;
using System.IO;
using System.Numerics;

namespace Sygnaly.Serializacja
{
    static class Serializacja
    {
        public static string sciezka = Environment.CurrentDirectory + "\\ZapisaneWykresy";
        
        public static void ZapiszWykres(object s, string nazwaWykresu)
        {
            string zmiennaCzasu = DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + "-" + DateTime.Now.Hour + "-"
                + DateTime.Now.Minute + "-" + DateTime.Now.Second;

            string nazwa = nazwaWykresu;

            if(s is SygnalCiagly)
            {
                nazwa += "Ciagly";

            }else
            {
                nazwa += "Dyskretny";
            }

            Sygnal sygnal = (Sygnal)s;

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(sciezka + "\\" + nazwa + "-" + zmiennaCzasu + ".txt"))
            {
                for(int i = 0; i<sygnal.x.Count;  i++)
                {
                    file.WriteLine(sygnal.x[i].Real + ";" + sygnal.x[i].Imaginary + ";" + sygnal.y[i].Real + ";" + sygnal.y[i].Imaginary + ";");
                }
            }
        }

        public static Sygnal WczytajWykres(string sciezka)
        {
            List<Complex> x = new List<Complex>();
            List<Complex> y = new List<Complex>();

            using (StreamReader sr = File.OpenText(sciezka))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    var values = s.Split(';');

                    x.Add(new Complex(double.Parse(values[0]), double.Parse(values[1])));
                    y.Add(new Complex(double.Parse(values[2]), double.Parse(values[3])));

                    //x.Add(double.Parse(values[0]));
                    //y.Add(double.Parse(values[1]));
                }
            }

            if(sciezka.Contains("Ciagly"))
            {
                SygnalCiagly ciagly = new SygnalCiagly();
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            else
            {
                SygnalDyskretny dyskretny = new SygnalDyskretny();
                dyskretny.UstawX(x);
                dyskretny.UstawY(y);
                return dyskretny;
            }

        }
    }
}
