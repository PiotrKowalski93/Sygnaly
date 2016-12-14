using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sygnaly;
using Sygnaly.Sygaly;
using Sygnaly.SygnalyCiagle;
using Sygnaly.SygnalyDyskretne;
using Sygnaly.StatyczneDane;
using Sygnaly.Properties;

namespace Sygnaly
{
    /// <summary>
    /// Interaction logic for Faza.xaml
    /// </summary>
    public partial class Faza : Window
    {
        private Sygnal d;
        private Sygnal e;
        private SygnalCiagly A;
        private SygnalDyskretny B;
        public List<KeyValuePair<double, double>> punkty;
        public List<KeyValuePair<double, double>> punktyU;
        public List<KeyValuePair<string, double>> punkty2;
        public List<KeyValuePair<string, double>> punkty2U;
        int ile;
        public Faza(int a)
        {
            InitializeComponent();
             ile = a;
            
            if (DaneStatyczne.dane is SkokJednostkowy)
            {
                SkokJednostkowy A = (SkokJednostkowy)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalProstokatny)
            {
                SygnalProstokatny A = (SygnalProstokatny)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalProstokatnySymetryczny)
            {
                SygnalProstokatnySymetryczny A = (SygnalProstokatnySymetryczny)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalny)
            {
                SygnalSinusoidalny A = (SygnalSinusoidalny)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalnyJednopolowkowo)
            {
                SygnalSinusoidalnyJednopolowkowo A = (SygnalSinusoidalnyJednopolowkowo)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalnyDwupolowkowo)
            {
                SygnalSinusoidalnyDwupolowkowo A = (SygnalSinusoidalnyDwupolowkowo)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SygnalTrojkatny)
            {
                SygnalTrojkatny A = (SygnalTrojkatny)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SzumGaussowski)
            {
                SzumGaussowski A = (SzumGaussowski)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is SzumRozkladJednostajny)
            {
                SzumRozkladJednostajny A = (SzumRozkladJednostajny)DaneStatyczne.dane;
                policzModul(A);
                policzFaze(A);
            }
            else if (DaneStatyczne.dane is ImpulsJednostkowy)
            {
                ImpulsJednostkowy B = (ImpulsJednostkowy)DaneStatyczne.dane;
                policzModul(B);
                policzFaze(B);
            }
            else
            {
                SzumImpulsowy B = (SzumImpulsowy)DaneStatyczne.dane;
                policzModul(B);
                policzFaze(B);
            }
        }
        private void policzModul(Sygnal sygnal)
        {
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Moduł";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < sygnal.y.Count; i++)
            {
                sygnal.y[i] = Math.Sqrt(Math.Pow(sygnal.y[i].Real, 2) + Math.Pow(sygnal.y[i].Imaginary, 2));
                punkty.Add(new KeyValuePair<double, double>(sygnal.x[i].Real, sygnal.y[i].Real));
            }
            mySeries.ItemsSource = punkty;

            ModulWykres.Series.Add(mySeries);
            policzHistogram(sygnal, 1);
        }
        private void policzFaze(Sygnal sygnal)
        {
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Faza";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < sygnal.x.Count; i++)
            {
                double k = 1;
                if (sygnal.y[i].Imaginary != 0)
                {
                    k = sygnal.y[i].Imaginary;
                }
                sygnal.y[i] = Math.Atan(sygnal.y[i].Real / k);
                punkty.Add(new KeyValuePair<double, double>(sygnal.x[i].Real, sygnal.y[i].Real));
            }
            mySeries.ItemsSource = punkty;

            FazaWykres.Series.Add(mySeries);
            policzHistogram(sygnal, 2);
        }
        private void policzHistogram(Sygnal sygnal, int nr)
        {
            double minReal = sygnal.y[0].Real;
            double maxReal = sygnal.y[0].Real;

            for (int i = 1; i < sygnal.y.Count; i++)
            {
                if (sygnal.y[i].Real > maxReal)
                    maxReal = sygnal.y[i].Real;
                if (sygnal.y[i].Real < minReal)
                    minReal = sygnal.y[i].Real;
            }

            double roznicaReal = maxReal - minReal;
            double szerokoscPrzedzialuReal = roznicaReal / ile;

            d = new Sygnal();
            d.x = new List<System.Numerics.Complex>();
            d.y = new List<System.Numerics.Complex>();

            for (int i = 0; i < ile; i++)
            {
                d.x.Add(minReal + (szerokoscPrzedzialuReal * i));
                int iloscWystapienR = 0;
                for (int j = 0; j < sygnal.y.Count; j++)
                {
                    if (sygnal.y[j].Real >= (minReal + (szerokoscPrzedzialuReal * i)) && sygnal.y[j].Real < (minReal + (szerokoscPrzedzialuReal * (i + 1))))
                        iloscWystapienR++;
                    if (i == (ile - 1) && sygnal.y[j] == maxReal)
                        iloscWystapienR++;
                }
                d.y.Add(iloscWystapienR);
            }
            ColumnSeries mySeries = new ColumnSeries();
            mySeries.Title = "Histogram";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty2 = new List<KeyValuePair<string, double>>();
            for (int i = 0; i < ile; i++)
            {
                if (i == ile - 1)
                    punkty2.Add(new KeyValuePair<string, double>("< " + Math.Round(d.x[i].Real, 2).ToString() + " ; " + Math.Round(d.x[i].Real + szerokoscPrzedzialuReal, 2).ToString() + " >", d.y[i].Real));
                else
                    punkty2.Add(new KeyValuePair<string, double>("< " + Math.Round(d.x[i].Real, 2).ToString() + " ; " + Math.Round(d.x[i].Real + szerokoscPrzedzialuReal, 2).ToString() + " )", d.y[i].Real));
            }
            mySeries.ItemsSource = punkty2;
            if (nr==1)
                ModulHistogram.Series.Add(mySeries);
            else
                FazaHistogram.Series.Add(mySeries);
        }
    }
}
