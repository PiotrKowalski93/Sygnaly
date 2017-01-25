using Sygnaly.Filtry;
using Sygnaly.Okna;
using Sygnaly.StatyczneDane;
using Sygnaly.Sygaly;
using Sygnaly.SygnalyCiagle;
using Sygnaly.SygnalyDyskretne;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Sygnaly
{
    /// <summary>
    /// Interaction logic for Filtry.xaml
    /// </summary>
    public partial class FiltryIOkna : Window
    {
        Sygnal A;
        SygnalPochodny sp;
        public List<KeyValuePair<double, double>> punkty;

        public FiltryIOkna()
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
            Okna.Items.Add("Hamming");
            Okna.Items.Add("Hanning");
            Okna.Items.Add("Blackman");

            Filtry.Items.Add("Dolnoprzepustowy");
            Filtry.Items.Add("Górnoprzepustowy");
            Filtry.Items.Add("Pasmowy");
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

            Sygnal.Series.Add(mySeries);
        }

        private void wyswietlDyskretny(Sygnal B)
        {
            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Sygnal";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < B.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(B.x[i].Real, B.y[i].Real));
            }

            mySeries.ItemsSource = punkty;
            Sygnal.Series.Add(mySeries);
        }

        private void GenerujFiltr_Click(object sender, RoutedEventArgs e)
        {
            Baza.Series.Clear();

            int rzad = int.Parse(RzadFiltru.Text);
            double czestotliwosc = double.Parse(Czestotliwosc.Text);
            double czestotliwoscNiskie = double.Parse(CzestotliwoscNiskie.Text);
            double czestotliwoscWysokie = double.Parse(CzestotliwoscWysokie.Text);

            string okno = Okna.SelectedItem.ToString();
            Filtr f = null;
            Okno o = null;

            if (okno == "Hamming")
            {
                o = new Hamming();
            }
            if (okno == "Hanning")
            {
                o = new Hanning();
            }
            if (okno == "Blackman")
            {
                o = new Blackman();
            }

            string filtr = Filtry.SelectedItem.ToString();

            if(filtr == "Dolnoprzepustowy")
            {
                f = new FiltrDolnoprzepustowy(o, rzad, czestotliwoscNiskie, czestotliwosc);
            }
            if (filtr == "Górnoprzepustowy")
            {
                f = new FiltrGornoprzepustowy(o, rzad, czestotliwoscWysokie, czestotliwosc);
            }
            if (filtr == "Pasmowy")
            {
                f = new FiltrPasmowy(o, rzad, czestotliwoscNiskie, czestotliwoscWysokie, czestotliwosc);
            }

            sp = new SygnalPochodny(f.getFilter(), rzad, 0, 1);

            double odstep = 10 / double.Parse(rzad.ToString());

            for (double i = 0; i < 10; i += odstep)
            {
                sp.x.Add(i);
            }

            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Filtr";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            var p = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < sp.x.Count; i++)
            {
                p.Add(new KeyValuePair<double, double>(sp.x[i].Real, sp.y[i].Real));
            }

            mySeries.ItemsSource = p;
            Baza.Series.Add(mySeries);

        }

        private void GenerujSygnalWynikowy_Click(object sender, RoutedEventArgs e)
        {
            Sygnal splot = new Sygnal();
            splot.x = new List<Complex>();
            splot.y = new List<Complex>();

            int M = A.x.Count;
            int N = sp.x.Count;
            int dlugoscSplotu = M + N - 1;

            int i1;

            for (int i = 0; i < dlugoscSplotu; i++)
            {
                Complex y = new Complex();
                i1 = i;

                for (int k = 0; k < N; k++)
                {
                    if (i1 >= 0 && i1 < M)
                    {
                        var h = A.y[i1];
                        var x = sp.y[k];

                        y += h * x;
                    }
                    i1--;

                }

                splot.y.Add(y);
            }

            double odstep = 10 / double.Parse(dlugoscSplotu.ToString());

            for (double i = 0; i < 10; i += odstep)
            {
                splot.x.Add(i);
            }

            Wynik.Series.Clear();
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Splot";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < splot.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(splot.x[i].Real, splot.y[i].Real));
            }

            mySeries.ItemsSource = punkty;
            Wynik.Series.Add(mySeries);
        }
    }
}
