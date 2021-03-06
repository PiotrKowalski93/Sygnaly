﻿using System;
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
using Sygnaly.Kwantyzatory;
using Sygnaly.Konwertery;

namespace Sygnaly
{
    /// <summary>
    /// Interaction logic for KonwersjaSygnalow.xaml
    /// </summary>
    public partial class KonwersjaSygnalow : Window
    {
        public List<KeyValuePair<double, double>> punkty;
        Sygnal A;
        Sygnal przekonwertowany;
        Sygnal zrekonstruowany;

        public KonwersjaSygnalow()
        {
            InitializeComponent();
            AddItems();
            if (DaneStatyczne.dane is SkokJednostkowy)
            {
                A = (SkokJednostkowy)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalProstokatny)
            {
                A = (SygnalProstokatny)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalProstokatnySymetryczny)
            {
                A = (SygnalProstokatnySymetryczny)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalny)
            {
                A = (SygnalSinusoidalny)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalnyJednopolowkowo)
            {
                A = (SygnalSinusoidalnyJednopolowkowo)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalSinusoidalnyDwupolowkowo)
            {
                A = (SygnalSinusoidalnyDwupolowkowo)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SygnalTrojkatny)
            {
                A = (SygnalTrojkatny)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SzumGaussowski)
            {
                A = (SzumGaussowski)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is SzumRozkladJednostajny)
            {
                A = (SzumRozkladJednostajny)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
            else if (DaneStatyczne.dane is ImpulsJednostkowy)
            {
                A = (ImpulsJednostkowy)DaneStatyczne.dane;
                wyswietlDyskretny(A);
            }
            else if (DaneStatyczne.dane is SzumImpulsowy)
            {
                A = (SzumImpulsowy)DaneStatyczne.dane;
                wyswietlDyskretny(A);
            }
            else
            {
                A = (Sygnal)DaneStatyczne.dane;
                wyswietlSygnal(A);
            }
        }

        private void AddItems()
        {
            TypKonwersji.Items.Add("Próbkowanie równomierne");
            TypKonwersji.Items.Add("Kwantyzacja równomierna z obcięciem");
            TypKonwersji.Items.Add("Kwantyzacja równomierna z zaokrągleniem");
            
            MetodaRekonstrukcji.Items.Add("Zero-order hold");
            MetodaRekonstrukcji.Items.Add("First-order hold");
            MetodaRekonstrukcji.Items.Add("Sinus Cardinalis");
        }

        private void wyswietlSygnal(Sygnal A)
        {
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Baza";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            mySeries.DataPointStyle = style;

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < A.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(A.x[i].Real, A.y[i].Real));
            }

            mySeries.ItemsSource = punkty;

            Baza.Series.Add(mySeries);
        }

        private void wyswietlDyskretny(Sygnal B)
        {
            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Baza";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < B.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(B.x[i].Real, B.y[i].Real));
            }

            mySeries.ItemsSource = punkty;
            Baza.Series.Add(mySeries);
        }

        private void ZmianaSposobuKonwersji(object sender, SelectionChangedEventArgs e)
        {
            Parametry.Items.Clear();

            if (TypKonwersji.SelectedItem.ToString() == "Próbkowanie równomierne")
            {
                Parametry.Items.Add("1");
                Parametry.Items.Add("2");
                Parametry.Items.Add("3");
                Parametry.Items.Add("5");
                Parametry.Items.Add("10");
                Parametry.Items.Add("20");
                Parametry.Items.Add("30");
                ParametryTekst.Text = "Częstotliwość próbkowania";
            }
            else if (TypKonwersji.SelectedItem.ToString() == "Kwantyzacja równomierna z obcięciem")
            {
                Parametry.Items.Add("1");
                Parametry.Items.Add("2");
                Parametry.Items.Add("4");
                Parametry.Items.Add("6");
                Parametry.Items.Add("8");
                Parametry.Items.Add("12");
                Parametry.Items.Add("14");
                ParametryTekst.Text = "Liczba bitów kwantyzacji";
            }
            else 
            {
                Parametry.Items.Add("1");
                Parametry.Items.Add("2");
                Parametry.Items.Add("4");
                Parametry.Items.Add("6");
                Parametry.Items.Add("8");
                Parametry.Items.Add("12");
                Parametry.Items.Add("14");
                ParametryTekst.Text = "Liczba bitów kwantyzacji";
            }
        }

        private void Konwertuj_Click(object sender, RoutedEventArgs e)
        {
            PoKonwersji.Series.Clear();

            przekonwertowany = new Sygnal();

            przekonwertowany.x = new List<System.Numerics.Complex>();
            przekonwertowany.y = new List<System.Numerics.Complex>();

            double maxX = A.x[0].Real;
            double minX = A.x[0].Real;

            for (int i = 0; i < A.x.Count; i++)
            {
                if (A.x[i].Real > maxX)
                {
                    maxX = A.x[i].Real;
                }
                if (A.x[i].Real < minX)
                {
                    minX = A.x[i].Real;
                }
            }

            A.d = maxX - minX;

            double czestotliwosc = Double.Parse(Parametry.SelectedItem.ToString());
            int ilePunktow = (int)(czestotliwosc * A.d);
            int coIle = (int)(A.n / ilePunktow);

            if (TypKonwersji.SelectedItem.ToString() == "Próbkowanie równomierne")
            {                    
                for (int i = 0; i < A.n; i = i + coIle)
                {
                    przekonwertowany.x.Add(A.x[i]);
                    przekonwertowany.y.Add(A.y[i]);
                }

                przekonwertowany.x.Add(A.x[A.x.Count - 1]);
                przekonwertowany.y.Add(A.y[A.y.Count - 1]);
            }

            if (TypKonwersji.SelectedItem.ToString() == "Kwantyzacja równomierna z obcięciem")
            {
                int liczbaBitow = int.Parse(Parametry.SelectedItem.ToString());

                RoundDownQuantizer rdq = new RoundDownQuantizer(liczbaBitow);

                for (int i = 0; i < A.n; i = i + coIle)
                {
                    przekonwertowany.x.Add(A.x[i]);
                    przekonwertowany.y.Add(rdq.quantizeSample(A.y[i], A.A));
                }
            }

            if (TypKonwersji.SelectedItem.ToString() == "Kwantyzacja równomierna z zaokrągleniem")
            {
                int liczbaBitow = int.Parse(Parametry.SelectedItem.ToString());

                MeanQuantizer mq = new MeanQuantizer(liczbaBitow);

                for (int i = 0; i < A.n; i = i + coIle)
                {
                    przekonwertowany.x.Add(A.x[i]);
                    przekonwertowany.y.Add(mq.quantizeSample(A.y[i], A.A));
                }
            }

            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Przekonwertowany";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < przekonwertowany.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(przekonwertowany.x[i].Real, przekonwertowany.y[i].Real));
            }

            mySeries.ItemsSource = punkty;
            PoKonwersji.Series.Add(mySeries);
            przekonwertowany.d = A.d;
            przekonwertowany.A = A.A;
            przekonwertowany.T = A.T;
            przekonwertowany.t1 = A.t1;
            przekonwertowany.kw = A.kw;
        }

        private void Rekonstruuj_Click(object sender, RoutedEventArgs e)
        {
            PoRekonstrukcji.Series.Clear();

            zrekonstruowany = new Sygnal();

            zrekonstruowany.x = new List<System.Numerics.Complex>();
            zrekonstruowany.y = new List<System.Numerics.Complex>();

            if (MetodaRekonstrukcji.SelectedItem.ToString() == "Zero-order hold")
            {
                int ileDodatkowych = (int)(400 / przekonwertowany.d);
                double roznica = (przekonwertowany.x[2].Real - przekonwertowany.x[1].Real) / (ileDodatkowych + 1);

                for (int i = 0; i < przekonwertowany.x.Count; i++)
                {
                    zrekonstruowany.x.Add(przekonwertowany.x[i].Real);
                    zrekonstruowany.y.Add(przekonwertowany.y[i].Real);

                    for (int j = 0; j < ileDodatkowych; j++)
                    {
                        if (i != przekonwertowany.x.Count - 1)
                        {
                            zrekonstruowany.x.Add(przekonwertowany.x[i].Real + (j * roznica));
                            zrekonstruowany.y.Add(przekonwertowany.y[i].Real);
                        }

                    }
                }
            }
            else if (MetodaRekonstrukcji.SelectedItem.ToString() == "First-order hold")
            {
                int ileDodatkowych = (int)(400 / przekonwertowany.d);
                double roznica = (przekonwertowany.x[2].Real - przekonwertowany.x[1].Real) / (ileDodatkowych + 1);

                for (int i = 0; i < przekonwertowany.x.Count; i++)
                {
                    zrekonstruowany.x.Add(przekonwertowany.x[i].Real);
                    zrekonstruowany.y.Add(przekonwertowany.y[i].Real);
                    if (i != przekonwertowany.x.Count - 1)
                    {
                        double roznicaY = (przekonwertowany.y[i + 1].Real - przekonwertowany.y[i].Real) / (ileDodatkowych + 1);

                        for (int j = 0; j < ileDodatkowych; j++)
                        {
                            if (i != przekonwertowany.x.Count - 1)
                            {
                                zrekonstruowany.x.Add(przekonwertowany.x[i].Real + (j * roznica));
                                zrekonstruowany.y.Add(przekonwertowany.y[i].Real + (j * roznicaY));
                            }

                        }
                    }
                }
            }
            else
            {
                SINCConverter sincconverter = new SINCConverter();
                zrekonstruowany = sincconverter.Konwert(przekonwertowany,(int)(A.n/A.d),int.Parse(Parametry.Text.ToString()));
            }
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Zrekonstruowany";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            mySeries.DataPointStyle = style;
            punkty = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < zrekonstruowany.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(zrekonstruowany.x[i].Real, zrekonstruowany.y[i].Real));
            }
            mySeries.ItemsSource = punkty;
            PoRekonstrukcji.Series.Add(mySeries);
        }

        private void LiczStatystyki_Click(object sender, RoutedEventArgs e)
        {
            SygnalDyskretny przedRekonstrukcja = new SygnalDyskretny();
            przedRekonstrukcja.x = new List<System.Numerics.Complex>();
            przedRekonstrukcja.y = new List<System.Numerics.Complex>();

            SygnalDyskretny poRekonstrukcji = new SygnalDyskretny();
            poRekonstrukcji.x = new List<System.Numerics.Complex>();
            poRekonstrukcji.y = new List<System.Numerics.Complex>();

            przedRekonstrukcja.A = A.A;
            poRekonstrukcji.A = zrekonstruowany.A;

            double maxX = A.x[0].Real;
            double minX = A.x[0].Real;

            for (int i = 0; i < A.x.Count; i++)
            {
                if (A.x[i].Real > maxX)
                {
                    maxX = A.x[i].Real;
                }
                if (A.x[i].Real < minX)
                {
                    minX = A.x[i].Real;
                }
            }

            A.d = maxX - minX;

            //double czestotliwosc = 50;
            //int ilePunktow = (int)(czestotliwosc * A.d);
            int coIle = (int)(A.n / 400);

            for (int i = 0; i < A.n; i = i + coIle)
            {
                przedRekonstrukcja.x.Add(A.x[i]);
                przedRekonstrukcja.y.Add(A.y[i]);

                poRekonstrukcji.x.Add(zrekonstruowany.x[i]);
                poRekonstrukcji.y.Add(zrekonstruowany.y[i]);
            }

            przedRekonstrukcja.x.Add(A.x[A.x.Count - 1]);
            przedRekonstrukcja.y.Add(A.y[A.y.Count - 1]);

            poRekonstrukcji.x.Add(zrekonstruowany.x[zrekonstruowany.x.Count - 1]);
            poRekonstrukcji.y.Add(zrekonstruowany.y[zrekonstruowany.y.Count - 1]);

            przedRekonstrukcja.PodzielPrzezAmplitude();
            poRekonstrukcji.PodzielPrzezAmplitude();

            MSE.Text = SignalComparer.CalculateMSE(przedRekonstrukcja, poRekonstrukcji).ToString();
            SNR.Text = SignalComparer.CalculateSNR(przedRekonstrukcja, poRekonstrukcji).ToString();
            PSNR.Text = SignalComparer.CalculatePSNR(przedRekonstrukcja, poRekonstrukcji).ToString();
            MD.Text = SignalComparer.CalculateMD(przedRekonstrukcja, poRekonstrukcji).ToString();
        }
    }
}
