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
    /// Interaction logic for Obliczenia.xaml
    /// </summary>
    public partial class Obliczenia : Window
    {
        private Sygnal d;
        private Sygnal e;
        public List<KeyValuePair<double, double>> punkty;
        public List<KeyValuePair<double, double>> punktyU;
        public List<KeyValuePair<string, double>> punkty2;
        public List<KeyValuePair<string, double>> punkty2U;
        int ile;
        public Obliczenia(int a)
        {
            InitializeComponent();
            ile = a;

            if(DaneStatyczne.dane is SygnalCiagly)
            {
                if (DaneStatyczne.dane is SkokJednostkowy)
                {
                    SkokJednostkowy A = (SkokJednostkowy)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalProstokatny)
                {
                    SygnalProstokatny A = (SygnalProstokatny)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalProstokatnySymetryczny)
                {
                    SygnalProstokatnySymetryczny A = (SygnalProstokatnySymetryczny)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalSinusoidalny)
                {
                    SygnalSinusoidalny A = (SygnalSinusoidalny)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalSinusoidalnyJednopolowkowo)
                {
                    SygnalSinusoidalnyJednopolowkowo A = (SygnalSinusoidalnyJednopolowkowo)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalSinusoidalnyDwupolowkowo)
                {
                    SygnalSinusoidalnyDwupolowkowo A = (SygnalSinusoidalnyDwupolowkowo)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SygnalTrojkatny)
                {
                    SygnalTrojkatny A = (SygnalTrojkatny)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else if (DaneStatyczne.dane is SzumGaussowski)
                {
                    SzumGaussowski A = (SzumGaussowski)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
                else 
                {
                    SzumRozkladJednostajny A = (SzumRozkladJednostajny)DaneStatyczne.dane;
                    policzA(A);
                    policzHistogramA(A);
                }
            }
            else if (DaneStatyczne.dane is SygnalDyskretny)
            {
                if (DaneStatyczne.dane is ImpulsJednostkowy)
                {
                    ImpulsJednostkowy B = (ImpulsJednostkowy)DaneStatyczne.dane;
                    policzB(B);
                    policzHistogramB(B);
                }
                else
                {
                    SzumImpulsowy B = (SzumImpulsowy)DaneStatyczne.dane;
                    policzB(B);
                    policzHistogramB(B);
                }
            }
            //if (DaneStatyczne.b is SygnalCiagly)
            //{
            //    SygnalCiagly B = (SygnalCiagly)DaneStatyczne.b;

            //    SredniaSygnal2.Text = B.PoliczSrednia().ToString();
            //    SredniaBezwSygnal2.Text = B.PoliczSredniaBezwzgledna().ToString();
            //    SkutecznaSygnal2.Text = B.PoliczWartoscSkuteczna().ToString();
            //    WariancjaSygnal2.Text = B.PoliczWariancje().ToString();
            //    MocSredniaSygnal2.Text = B.PoliczSredniaMoc().ToString();
            //}
            //else if (DaneStatyczne.b is SygnalDyskretny)
            //{
            //    SygnalDyskretny B = (SygnalDyskretny)DaneStatyczne.b;

            //    SredniaSygnal2.Text = B.LiczSrednia().ToString();
            //    SredniaBezwSygnal2.Text = B.LiczSredniaBezwzgledna().ToString();
            //    SkutecznaSygnal2.Text = B.LiczWartoscSkuteczna().ToString();
            //    WariancjaSygnal2.Text = B.LiczWariancje().ToString();
            //    MocSredniaSygnal2.Text = B.LiczSredniaMoc().ToString();
            //}
        }
        private void policzA(SygnalCiagly A)
        {
                LineSeries mySeries = new LineSeries();
                mySeries.Title = "Amplituda";
                mySeries.IndependentValueBinding = new Binding("Key");
                mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < A.x.Count; i++)
                    {
                        punkty.Add(new KeyValuePair<double, double>(A.x[i].Real, A.y[i].Real));
                    }
                mySeries.ItemsSource = punkty;

                AmplitudaRzeczywista.Series.Add(mySeries);
            LineSeries mySeries2 = new LineSeries();
            mySeries2.Title = "Amplituda";
            mySeries2.IndependentValueBinding = new Binding("Key");
            mySeries2.DependentValueBinding = new Binding("Value");
            punktyU = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < A.x.Count; i++)
            {
                punktyU.Add(new KeyValuePair<double, double>(A.x[i].Real, A.y[i].Imaginary));
            }
            mySeries2.ItemsSource = punktyU;

            AmplitudaUrojona.Series.Add(mySeries2);
        }
        private void policzB(SygnalDyskretny B)
        {
            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Sygnał";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
                for (int i = 0; i < B.x.Count; i++)
                {
                    punkty.Add(new KeyValuePair<double, double>(B.x[i].Real, B.y[i].Real));
                }
            mySeries.ItemsSource = punkty;
            AmplitudaRzeczywista.Series.Add(mySeries);
        }
        private void policzHistogramA(SygnalCiagly A)
        {
            policzHistogram(A);
            SredniaSygnal1.Text = A.PoliczSrednia().ToString();
            SredniaBezwSygnal1.Text = A.PoliczSredniaBezwzgledna().ToString();
            SkutecznaSygnal1.Text = A.PoliczWartoscSkuteczna().ToString();
            WariancjaSygnal1.Text = A.PoliczWariancje().ToString();
            MocSredniaSygnal1.Text = A.PoliczSredniaMoc().ToString();
        }
        private void policzHistogramB(SygnalDyskretny B)
        {
            policzHistogram(B);
            SredniaSygnal1.Text = B.LiczSrednia().ToString();
            SredniaBezwSygnal1.Text = B.LiczSredniaBezwzgledna().ToString();
            SkutecznaSygnal1.Text = B.LiczWartoscSkuteczna().ToString();
            WariancjaSygnal1.Text = B.LiczWariancje().ToString();
            MocSredniaSygnal1.Text = B.LiczSredniaMoc().ToString();
        }
        private void policzHistogram(Sygnal sygnal)
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
            for (int i = 0; i < ile; i++)
            {
                d.x[i] = (minReal + (szerokoscPrzedzialuReal * i));
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
            HistogramRzeczywista.Series.Clear();
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
            HistogramRzeczywista.Series.Add(mySeries);
            double minU = sygnal.y[0].Imaginary;
            double maxU = sygnal.y[0].Imaginary;
            for (int i = 1; i < sygnal.y.Count; i++)
            {
                if (sygnal.y[i].Imaginary > maxU)
                    maxU = sygnal.y[i].Imaginary;
                if (sygnal.y[i].Imaginary < minU)
                    minU = sygnal.y[i].Imaginary;
            }
            double roznicaU = maxU - minU;
            double szerokoscPrzedzialuU = roznicaU / ile;
            bool czy0=false;
            if (szerokoscPrzedzialuU == 0)
            {
                szerokoscPrzedzialuU = 0.1;
                czy0 = true;
                minU = (ile*0.1)/(-2);
            }
            e = new Sygnal();
            for (int i = 0; i < ile; i++)
            {
                e.x[i] = (minU + (szerokoscPrzedzialuU * i));
                int iloscWystapienU = 0;
                for (int j = 0; j < sygnal.y.Count; j++)
                {
                    if (sygnal.y[j].Imaginary >= (minU + (szerokoscPrzedzialuU * i)) && sygnal.y[j].Imaginary < (minU + (szerokoscPrzedzialuU * (i + 1))))
                        iloscWystapienU++;
                    if (czy0 == false && i == (ile - 1) && sygnal.y[j] == maxU)
                        iloscWystapienU++;
                }
                e.y.Add(iloscWystapienU);
            }
            HistogramUrojona.Series.Clear();
            ColumnSeries mySeries2 = new ColumnSeries();
            mySeries2.Title = "Histogram";
            mySeries2.IndependentValueBinding = new Binding("Key");
            mySeries2.DependentValueBinding = new Binding("Value");
            punkty2U = new List<KeyValuePair<string, double>>();
            for (int i = 0; i < ile; i++)
            {
                if (i == ile - 1)
                    punkty2U.Add(new KeyValuePair<string, double>("< " + Math.Round(e.x[i].Real, 2).ToString() + " ; " + Math.Round(e.x[i].Real + szerokoscPrzedzialuU, 2).ToString() + " >", e.y[i].Real));
                else
                    punkty2U.Add(new KeyValuePair<string, double>("< " + Math.Round(e.x[i].Real, 2).ToString() + " ; " + Math.Round(e.x[i].Real + szerokoscPrzedzialuU, 2).ToString() + " )", e.y[i].Real));
            }
            mySeries2.ItemsSource = punkty2U;
            HistogramUrojona.Series.Add(mySeries2);
        }
    }
}
