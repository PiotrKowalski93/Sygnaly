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
    public partial class SymulatorCzujnikaOdleglosci : Window
    {
        public List<KeyValuePair<double, double>> punkty;
        Sygnal A;
        Sygnal przesuniety;
        int odleglosc = 100;
        int predkoscObiektu;
        int predkoscOsrodka;
        bool nadal=true;
        bool kierunek = true;
        public SymulatorCzujnikaOdleglosci()
        {
            InitializeComponent();
            A = (Sygnal)DaneStatyczne.dane;
            wyswietlSygnal(A);
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
        private async void Start_Click(object sender, RoutedEventArgs e)
        {

            nadal = true;
            DateTime startTime = DateTime.Now;
            czestotliwosc.IsEnabled = false;
            int czestosc = int.Parse(czestotliwosc.Text.Trim());
            rzeczywistaPredkosc.IsEnabled = false;
            predkoscObiektu = int.Parse(rzeczywistaPredkosc.Text.Trim());
            predkoscRozchodzenia.IsEnabled = false;
            predkoscOsrodka = int.Parse(predkoscRozchodzenia.Text.Trim());
            while (nadal==true)
            {
                DateTime posredni = DateTime.Now;
                TimeSpan roznicaPosrednia = posredni - startTime;
                double czasPrzemieszczeniaPosredniego = roznicaPosrednia.TotalMilliseconds;
                int drogaPosrednia = (int)(predkoscObiektu * czasPrzemieszczeniaPosredniego/1000);
                int odlegloscPosrednia=odleglosc;
                if (kierunek == true) odlegloscPosrednia += drogaPosrednia;
                else odlegloscPosrednia -= drogaPosrednia;
                int czas=odlegloscPosrednia/(predkoscOsrodka/1000);

                await Task.Delay(czas);
                wyswietlSygnalPrzesuniety(A, czas);
                Czas.Text = (czas).ToString();
                DateTime stopTime = DateTime.Now;
                TimeSpan roznica = stopTime - startTime;
                startTime = stopTime;
                int czasPrzemieszczenia = (int)(roznica.TotalSeconds);
                int droga = (int)(predkoscObiektu * czasPrzemieszczenia);
                if (kierunek == true) odleglosc += droga;
                else odleglosc -= droga;
                rzeczywistaOdleglosc.Text = odleglosc.ToString();

                int czekaj = czestosc - (czasPrzemieszczenia*1000);
                if (czekaj>0) await Task.Delay(czekaj);
            }
        }
        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            nadal = false;
        }
        private void ZmianaKierunku_Click(object sender, RoutedEventArgs e)
        {
            if (kierunek == true) kierunek = false;
            else kierunek = true;
        }
        private void wyswietlSygnalPrzesuniety(Sygnal A, int czas)
        {
            Przesuniety.Series.Clear();
            przesuniety = new Sygnal();
            przesuniety.x = new List<System.Numerics.Complex>();
            przesuniety.y = new List<System.Numerics.Complex>();

            for (int i = 0; i < A.x.Count; i++)
            {
                if (A.x[i].Real- (czas / 1000.0) > 0) przesuniety.x.Add(A.x[i]-(double)(czas/1000.0));
                else przesuniety.x.Add(A.x[i] + 10 - (czas / 1000.0));
                przesuniety.y.Add(A.y[i]);
            }

            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Sygnał odebrany";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            mySeries.DataPointStyle = style;

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < przesuniety.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(przesuniety.x[i].Real, przesuniety.y[i].Real));
            }

            mySeries.ItemsSource = punkty;

            Przesuniety.Series.Add(mySeries);
        }
    }
   
}
