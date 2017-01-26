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
using Microsoft.Win32;
using System.Numerics;
using System.Windows.Navigation;

namespace Sygnaly
{
    public partial class SymulatorCzujnikaOdleglosci : Window
    {
        public List<KeyValuePair<double, double>> punkty;
        Sygnal A;
        int odleglosc;
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
            mySeries.Title = "Wysłany";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            style.Setters.Add(new Setter(LineDataPoint.BackgroundProperty, new SolidColorBrush(Colors.Red)));
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
            kierunek = true;
            czestotliwosc.IsEnabled = false;
            int czestosc = int.Parse(czestotliwosc.Text.Trim());
            rzeczywistaPredkosc.IsEnabled = false;
            predkoscObiektu = int.Parse(rzeczywistaPredkosc.Text.Trim());
            rzeczywistaOdleglosc.IsEnabled = false;
            odleglosc = int.Parse(rzeczywistaOdleglosc.Text.Trim());
            predkoscRozchodzenia.IsEnabled = false;
            predkoscOsrodka = int.Parse(predkoscRozchodzenia.Text.Trim());

            DateTime startTime = DateTime.Now;
            await Task.Delay(1000);
            while (nadal==true)
            {
                DateTime posredni = DateTime.Now;
                TimeSpan roznicaPosrednia = posredni - startTime;
                double czasPrzemieszczeniaPosredniego = roznicaPosrednia.TotalMilliseconds;
                int drogaPosrednia = (int)(predkoscObiektu * czasPrzemieszczeniaPosredniego/1000);
                int odlegloscPosrednia=odleglosc;
                if (kierunek == true) odlegloscPosrednia += drogaPosrednia;
                else odlegloscPosrednia -= drogaPosrednia;
                int czas=(int)(odlegloscPosrednia/((double)(predkoscOsrodka/1000.0)));

                //if(czas>0) await Task.Delay(czas);
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
                if (odleglosc==0) nadal = false;

                int czekaj = czestosc - (czasPrzemieszczenia*1000);
                startTime = DateTime.Now;
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

            if (Baza.Series.Count > 1)
            {
                Baza.Series.RemoveAt(1);
            }

            Sygnal przesuniety = new Sygnal();
            przesuniety.x = new List<System.Numerics.Complex>();
            przesuniety.y = new List<System.Numerics.Complex>();
            for (int i = 0; i < A.x.Count; i++)
            {
                if (A.x[i].Real- (czas / 1000.0) <= 0) przesuniety.x.Add(A.x[i] + 10 - (czas / 1000.0));
                else przesuniety.x.Add(A.x[i]-(double)(czas/1000.0));
                przesuniety.y.Add(A.y[i]);
            }

            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Odebrany";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");

            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            style.Setters.Add(new Setter(LineDataPoint.BackgroundProperty, new SolidColorBrush(Colors.Black)));
            mySeries.DataPointStyle = style;

            punkty = new List<KeyValuePair<double, double>>();

            for (int i = 0; i < przesuniety.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(przesuniety.x[i].Real, przesuniety.y[i].Real));
            }

            mySeries.ItemsSource = punkty;

            Baza.Series.Add(mySeries);
            PoliczKorelacje(przesuniety);
        }
        private void PoliczKorelacje(Sygnal przesuniety)
        {
            Wynik.Series.Clear();
            Sygnal korelacja = new Sygnal();
            korelacja.x = new List<Complex>();
            korelacja.y = new List<Complex>();

            int M = A.x.Count;
            int N = przesuniety.x.Count;
            int dlugoscSplotu = M + N - 1;

            double odstep = 20 / (double)(dlugoscSplotu-1);
            int p = 0;
            //korelacja.y.Add(0);
            for (double i = 0; i < 20; i += odstep)
            {
                korelacja.x.Add(i);
                double y = 0;
                int n = p - (N - 1);

                for (int k = 0; k < M; k++)
                {
                    if (k - n >= 0 && k - n < N)
                    {
                        double h = A.y[k].Real;
                        double x = przesuniety.y[k - n].Real;

                        y += h * x;
                    }
                }
                
                korelacja.y.Add(y);
                p++;
            }

            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Korelacja";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            Style style = new Style(typeof(LineDataPoint));
            style.Setters.Add(new Setter(LineDataPoint.TemplateProperty, null));
            style.Setters.Add(new Setter(LineDataPoint.BackgroundProperty, new SolidColorBrush(Colors.Blue)));
            mySeries.DataPointStyle = style;
            for (int i = 0; i < korelacja.y.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(korelacja.x[i].Real, korelacja.y[i].Real));
            }
            mySeries.ItemsSource = punkty;
            Wynik.Series.Add(mySeries);
            int zakres = korelacja.y.Count;
            double max = 0;
            int index=0;
            for (int s = zakres / 2; s < zakres; s++)
            {
                if (korelacja.y[s].Real > max)
                {
                    max = korelacja.y[s].Real;
                    index = s;
                }
            }
            double czas2 = korelacja.x[index].Real - korelacja.x[zakres / 2].Real;
            int droga = (int)(predkoscOsrodka * czas2 / 2);
            odlegloscSymulator.Text = droga.ToString();
        }
    }
   
}
