using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sygnaly.Sygaly;
using System.IO;

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
                    file.WriteLine(sygnal.x[i] + ";" + sygnal.y[i]);
                }
            }
        }

        public static Sygnal WczytajWykres(string sciezka)
        {
            List<double> x = new List<double>();
            List<double> y = new List<double>();

            using (StreamReader sr = File.OpenText(sciezka))
            {
                string s = String.Empty;
                while ((s = sr.ReadLine()) != null)
                {
                    var values = s.Split(';');

                    x.Add(double.Parse(values[0]));
                    y.Add(double.Parse(values[1]));
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
