using System;
using System.Collections.Generic;
using Sygnaly.Sygaly;
using System.IO;
using System.Numerics;
using Sygnaly.SygnalyCiagle;
using Sygnaly.SygnalyDyskretne;
using Newtonsoft.Json;

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
                if (s is SkokJednostkowy)
                {
                    nazwa += "SkokJednostkowy";
                }
                if (s is SygnalProstokatny)
                {
                    nazwa += "SygnalProstokatny";
                }
                if (s is SygnalProstokatnySymetryczny)
                {
                    nazwa += "SygnalProstokatnySymetryczny";
                }
                if (s is SygnalSinusoidalny)
                {
                    nazwa += "SygnalSinusoidalny";
                }
                if (s is SygnalSinusoidalnyDwupolowkowo)
                {
                    nazwa += "SygnalSinusoidalnyDwupolowkowo";
                }
                if (s is SygnalSinusoidalnyJednopolowkowo)
                {
                    nazwa += "SygnalSinusoidalnyJednopolowkowo";
                }
                if (s is SygnalTrojkatny)
                {
                    nazwa += "SygnalTrojkatny";
                }
                if (s is SzumGaussowski)
                {
                    nazwa += "SzumGaussowski";
                }
                if (s is SzumRozkladJednostajny)
                {
                    nazwa += "SzumRozkladJednostajny";
                }

            }else
            {
                if (s is ImpulsJednostkowy)
                {
                    nazwa += "ImpulsJednostkowy";
                }
                if (s is SzumImpulsowy)
                {
                    nazwa += "SzumImpulsowy";
                }
            }
            
            string output = JsonConvert.SerializeObject(s);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(sciezka + "\\" + nazwa + "-" + zmiennaCzasu + ".txt"))
            {
               file.WriteLine(output);
            }
        }

        public static Sygnal WczytajWykres(string sciezka)
        {
            List<Complex> x = new List<Complex>();
            List<Complex> y = new List<Complex>();

            string sygnal = String.Empty;

            using (StreamReader sr = File.OpenText(sciezka))
            {
                sygnal = sr.ReadToEnd().Trim().TrimEnd();
            }

            if (sciezka.Contains("SkokJednostkowy"))
            {
                SkokJednostkowy ciagly = JsonConvert.DeserializeObject<SkokJednostkowy>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalProstokatny"))
            {
                SygnalProstokatny ciagly = JsonConvert.DeserializeObject<SygnalProstokatny>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalProstokatnySymetryczny"))
            {
                SygnalProstokatnySymetryczny ciagly = JsonConvert.DeserializeObject<SygnalProstokatnySymetryczny>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalSinusoidalny"))
            {
                SygnalSinusoidalny ciagly = JsonConvert.DeserializeObject<SygnalSinusoidalny>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalSinusoidalnyDwupolowkowo"))
            {
                SygnalSinusoidalnyDwupolowkowo ciagly = JsonConvert.DeserializeObject<SygnalSinusoidalnyDwupolowkowo>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalSinusoidalnyJednopolowkowo"))
            {
                SygnalSinusoidalnyJednopolowkowo ciagly = JsonConvert.DeserializeObject<SygnalSinusoidalnyJednopolowkowo>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SygnalTrojkatny"))
            {
                SygnalTrojkatny ciagly = JsonConvert.DeserializeObject<SygnalTrojkatny>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SzumGaussowski"))
            {
                SzumGaussowski ciagly = JsonConvert.DeserializeObject<SzumGaussowski>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SzumRozkladJednostajny"))
            {
                SzumRozkladJednostajny ciagly = JsonConvert.DeserializeObject<SzumRozkladJednostajny>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }      
            if (sciezka.Contains("ImpulsJednostkowy"))
            {
                ImpulsJednostkowy ciagly = JsonConvert.DeserializeObject<ImpulsJednostkowy>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }
            if (sciezka.Contains("SzumImpulsowy"))
            {
                ImpulsJednostkowy ciagly = JsonConvert.DeserializeObject<ImpulsJednostkowy>(sygnal);
                ciagly.UstawX(x);
                ciagly.UstawY(y);
                return ciagly;
            }

            return null;
        }
    }
}
