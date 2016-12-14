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
    /// Interaction logic for KonwersjaSygnalow.xaml
    /// </summary>
    public partial class KonwersjaSygnalow : Window
    {
        public List<KeyValuePair<double, double>> punkty;
        Sygnal przekonwertowany;
        Sygnal A;
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
            SposobKonwersji.Items.Add("Próbkowanie równomierne");
            SposobKonwersji.Items.Add("Kwantyzacja równomierna z obcięciem");
            SposobKonwersji.Items.Add("Kwantyzacja równomierna z zaokrągleniem");
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
            if (SposobKonwersji.SelectedItem.ToString() == "Próbkowanie równomierne")
            {
                Parametry.Items.Add("0,25");
                Parametry.Items.Add("0,5");
                Parametry.Items.Add("1");
                Parametry.Items.Add("2");
                Parametry.Items.Add("3");
                Parametry.Items.Add("5");
                Parametry.Items.Add("10");
                Parametry.Items.Add("20");
                ParametryTekst.Text = "Częstotliwość próbkowania";
            }
            else if (SposobKonwersji.SelectedItem.ToString() == "Kwantyzacja równomierna z obcięciem")
            {
                ParametryTekst.Text = "Parametry kwantyzacji z obcięciem";
            }
            else 
            {
                ParametryTekst.Text = "Parametry kwantyzacji z zaokrągleniem";
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
            if (SposobKonwersji.SelectedItem.ToString() == "Próbkowanie równomierne")
            {
                double czestotliwosc =Double.Parse(Parametry.SelectedItem.ToString());
                int ilePunktow = (int)(czestotliwosc * A.d);
                int coIle = (int)(A.n / ilePunktow);
                for (int i = 0; i < A.n; i=i+coIle)
                {
                    przekonwertowany.x.Add(A.x[i]);
                    przekonwertowany.y.Add(A.y[i]);
                }
                przekonwertowany.x.Add(A.x[A.x.Count - 1]);
                przekonwertowany.y.Add(A.y[A.y.Count - 1]);
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
            }
        }
    }
}
