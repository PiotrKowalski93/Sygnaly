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
        int odleglosc = 100;
        int predkoscObiektu;
        int predkochOsrodka;
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
            rzeczywistaPredkosc.IsEnabled = false;
            predkoscObiektu = int.Parse(rzeczywistaPredkosc.Text.Trim());
            predkoscRozchodzenia.IsEnabled = false;
            predkochOsrodka = int.Parse(predkoscRozchodzenia.Text.Trim());
            while (nadal==true)
            {
                DateTime stopTime = DateTime.Now;
                TimeSpan roznica = stopTime - startTime;
                startTime = stopTime;
                double czasPrzemieszczenia = roznica.TotalSeconds;
                int droga = (int)(predkoscObiektu * czasPrzemieszczenia);
                if (kierunek == true) odleglosc += droga;
                else odleglosc -= droga;
                rzeczywistaOdleglosc.Text = odleglosc.ToString();
                await Task.Delay(2000);
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
    }
   
}
