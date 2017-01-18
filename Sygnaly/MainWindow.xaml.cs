using Microsoft.Win32;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sygnaly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public List<KeyValuePair<double, double>> punkty;
        private Sygnal a;
        private Sygnal b;
        private Sygnal c;
        private int ile;

        public MainWindow()
        {
            InitializeComponent();
            AddItems();
        }

        private void AddItems()
        {
            TypySygnalow.Items.Add("Skok Jednostkowy");
            TypySygnalow.Items.Add("Prostokatny");
            TypySygnalow.Items.Add("Prostokatny Symetryczny");
            TypySygnalow.Items.Add("Sinusoidalny");
            TypySygnalow.Items.Add("Sinusoidalny Dwupolowkowo");
            TypySygnalow.Items.Add("Sinusoidalny Jednopolowkowo");
            TypySygnalow.Items.Add("Trójkatny");
            TypySygnalow.Items.Add("Szum Gaussowski");
            TypySygnalow.Items.Add("Szum o Rozdkladzie Jednostajnym");
            TypySygnalow.Items.Add("Impuls Jednostkowy");
            TypySygnalow.Items.Add("Szum Impulsowy");
            TypyOperacji.Items.Add("Sygnał 1 + Sygnał 2");
            TypyOperacji.Items.Add("Sygnał 1 - Sygnał 2");
            TypyOperacji.Items.Add("Sygnał 2 - Sygnał 1");
            TypyOperacji.Items.Add("Sygnał 1 * Sygnał 2");
            TypyOperacji.Items.Add("Sygnał 1 / Sygnał 2");
            TypyOperacji.Items.Add("Sygnał 2 / Sygnał 1");
            //IlePrzedzialow.Items.Add("5");
            //IlePrzedzialow.Items.Add("10");
            //IlePrzedzialow.Items.Add("15");
            //IlePrzedzialow.Items.Add("20");
            Konwersja.Items.Add("Sygnał 1");
            Konwersja.Items.Add("Sygnał 2");
            Konwersja.Items.Add("Sygnał Wynikowy");
            Amplituda.IsEnabled = true;
            Amplituda.Text = "2";
            CzasPoczatkowy.IsEnabled = true;
            CzasPoczatkowy.Text = "0";
            CzasTrwaniaSygnalu.IsEnabled = true;
            CzasTrwaniaSygnalu.Text = "10";
            OkresPodstwawowy.IsEnabled = true;
            OkresPodstwawowy.Text = "2";
        }
        private void ZaladujSygnal(int nr)
        {
            double A = double.Parse(Amplituda.Text.Trim());         // <-- Amplituda
            double t1 = double.Parse(CzasPoczatkowy.Text.Trim()); ;      // <-- Czas Poczatkowy
            double d = double.Parse(CzasTrwaniaSygnalu.Text.Trim());      // <-- Czas Trwania

            if (TypySygnalow.SelectedItem.ToString() == "Skok Jednostkowy")
            {
                if (nr == 1)
                    a = new SkokJednostkowy(A, t1, d);
                else
                    b = new SkokJednostkowy(A, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Prostokatny")
            {
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                double kw = double.Parse(WspolczynnikWpelnienia.Text.Trim());          // <-- Współczynnik wypełnienia (tylko dla prost. i trój.)
                if (nr == 1)
                    a = new SygnalProstokatny(A, T, t1, d, kw);
                else
                    b = new SygnalProstokatny(A, T, t1, d, kw);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Prostokatny Symetryczny")
            {
                double kw = double.Parse(WspolczynnikWpelnienia.Text.Trim());          // <-- Współczynnik wypełnienia (tylko dla prost. i trój.)
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                if (nr == 1)
                    a = new SygnalProstokatnySymetryczny(A, T, t1, d, kw);
                else
                    b = new SygnalProstokatnySymetryczny(A, T, t1, d, kw);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny")
            {
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                if (nr == 1)
                    a = new SygnalSinusoidalny(A, T, t1, d);
                else
                    b = new SygnalSinusoidalny(A, T, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny Dwupolowkowo")
            {
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                if (nr == 1)
                    a = new SygnalSinusoidalnyDwupolowkowo(A, T, t1, d);
                else
                    b = new SygnalSinusoidalnyDwupolowkowo(A, T, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny Jednopolowkowo")
            {
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                if (nr == 1)
                    a = new SygnalSinusoidalnyJednopolowkowo(A, T, t1, d);
                else
                    b = new SygnalSinusoidalnyJednopolowkowo(A, T, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Trójkatny")
            {
                double kw = double.Parse(WspolczynnikWpelnienia.Text.Trim());          // <-- Współczynnik wypełnienia (tylko dla prost. i trój.)
                double T = double.Parse(OkresPodstwawowy.Text.Trim()); ;       // <-- Okres
                if (nr == 1)
                    a = new SygnalTrojkatny(A, T, t1, d, kw);
                else
                    b = new SygnalTrojkatny(A, T, t1, d, kw);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Szum Gaussowski")
            {
                if (nr == 1)
                    a = new SzumGaussowski(A, t1, d);
                else
                    b = new SzumGaussowski(A, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Szum o Rozdkladzie Jednostajnym")
            {
                if (nr == 1)
                    a = new SzumRozkladJednostajny(A, t1, d);
                else
                    b = new SzumRozkladJednostajny(A, t1, d);
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Impuls Jednostkowy")
            {
                if (nr == 1)
                    a = new ImpulsJednostkowy(A, t1, d);
                else
                    b = new ImpulsJednostkowy(A, t1, d);
            }
            //Szum Impulsowy
            else
            {
                if (nr == 1)
                    a = new SzumImpulsowy(A, t1, d);
                else
                    b = new SzumImpulsowy(A, t1, d);
            }
            if (TypySygnalow.SelectedItem.ToString() == "Impuls Jednostkowy" || TypySygnalow.SelectedItem.ToString() == "Szum Impulsowy")
            {
                ScatterSeries mySeries = new ScatterSeries();
                mySeries.Title = "Sygnał";
                mySeries.IndependentValueBinding = new Binding("Key");
                mySeries.DependentValueBinding = new Binding("Value");
                punkty = new List<KeyValuePair<double, double>>();
                if (nr == 1)
                {
                    for (int i = 0; i < a.x.Count; i++)
                    {
                        punkty.Add(new KeyValuePair<double, double>(a.x[i].Real, a.y[i].Real));
                    }
                }
                else
                {
                    for (int i = 0; i < b.x.Count; i++)
                    {
                        punkty.Add(new KeyValuePair<double, double>(b.x[i].Real, b.y[i].Real));
                    }
                }
                mySeries.ItemsSource = punkty;

                Chart.Series.Add(mySeries);
            }
            else
            {
                LineSeries mySeries = new LineSeries();
                mySeries.Title = "Sygnał " + nr;
                mySeries.IndependentValueBinding = new Binding("Key");
                mySeries.DependentValueBinding = new Binding("Value");
                punkty = new List<KeyValuePair<double, double>>();
                if (nr == 1)
                {
                    for (int i = 0; i < a.x.Count; i++)
                    {
                        punkty.Add(new KeyValuePair<double, double>(a.x[i].Real, a.y[i].Real));
                    }
                }
                else
                {
                    for (int i = 0; i < b.x.Count; i++)
                    {
                        punkty.Add(new KeyValuePair<double, double>(b.x[i].Real, b.y[i].Real));
                    }
                }
                mySeries.ItemsSource = punkty;

                Chart.Series.Add(mySeries);
            }
            //if (IlePrzedzialow.SelectedItem.ToString() == "5")
            //    ile = 5;
            //else if (IlePrzedzialow.SelectedItem.ToString() == "10")
            //    ile = 10;
            //else if (IlePrzedzialow.SelectedItem.ToString() == "15")
            //    ile = 15;
            //else
            //    ile = 20;
        }
        
        private void Sygnal1_Click(object sender, RoutedEventArgs e)
        {
            Chart.Series.Clear();
            int nr = 1;
            ZaladujSygnal(nr);
        }
        private void Sygnal2_Click(object sender, RoutedEventArgs e)
        {
            if (Chart.Series.Count > 1)
            {
                Chart.Series.RemoveAt(1);
            }
            int nr = 2;
            ZaladujSygnal(nr);
        }
        private void TypWybrany(object sender, RoutedEventArgs e)
        {
            Amplituda.IsEnabled = true;
            CzasPoczatkowy.IsEnabled = true;
            CzasTrwaniaSygnalu.IsEnabled = true;
            if (TypySygnalow.SelectedItem.ToString() == "Skok Jednostkowy")
            {
                OkresPodstwawowy.Clear();
                OkresPodstwawowy.IsEnabled = false;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Prostokatny")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.IsEnabled = true;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Prostokatny Symetryczny")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.IsEnabled = true;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny Dwupolowkowo")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Sinusoidalny Jednopolowkowo")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Trójkatny")
            {
                OkresPodstwawowy.IsEnabled = true;
                WspolczynnikWpelnienia.IsEnabled = true;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Szum Gaussowski")
            {
                OkresPodstwawowy.Clear();
                OkresPodstwawowy.IsEnabled = false;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Szum o Rozdkladzie Jednostajnym")
            {
                OkresPodstwawowy.Clear();
                OkresPodstwawowy.IsEnabled = false;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            else if (TypySygnalow.SelectedItem.ToString() == "Impuls Jednostkowy")
            {
                OkresPodstwawowy.Clear();
                OkresPodstwawowy.IsEnabled = false;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
            //Szum Impulsowy
            else
            {
                OkresPodstwawowy.Clear();
                OkresPodstwawowy.IsEnabled = false;
                WspolczynnikWpelnienia.Clear();
                WspolczynnikWpelnienia.IsEnabled = false;
            }
        }
        private void Wczytaj_Click(object sender, RoutedEventArgs e)
        {
            ChartWynik.Series.Clear();
            c = new Sygnal();
            c.x = new List<System.Numerics.Complex>();
            c.y = new List<System.Numerics.Complex>();

            if (TypyOperacji.SelectedItem.ToString() == "Sygnał 1 + Sygnał 2")
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    c.y.Add(a.y[i] + b.y[i]);
                }
            }

            else if (TypyOperacji.SelectedItem.ToString() == "Sygnał 1 - Sygnał 2")
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    c.y.Add(a.y[i] - b.y[i]);
                }
            }
            else if (TypyOperacji.SelectedItem.ToString() == "Sygnał 2 - Sygnał 1")
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    c.y.Add(b.y[i] - a.y[i]);
                }
            }
            else if (TypyOperacji.SelectedItem.ToString() == "Sygnał 1 * Sygnał 2")
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    c.y.Add(a.y[i] * b.y[i]);
                }
            }
            else if (TypyOperacji.SelectedItem.ToString() == "Sygnał 1 / Sygnał 2")
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    if (b.y[i] != 0)
                        c.y.Add(a.y[i] / b.y[i]);
                    else
                        c.y.Add(0);
                }
            }
            else
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    c.x.Add(a.x[i]);
                    if (a.y[i] != 0)
                        c.y.Add(b.y[i] / a.y[i]);
                    else
                        c.y.Add(0);
                }
            }
            LineSeries mySeries = new LineSeries();
            mySeries.Title = "Wynik";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            for (int i = 0; i < c.x.Count; i++)
            {
                punkty.Add(new KeyValuePair<double, double>(c.x[i].Real, c.y[i].Real));
            }
            mySeries.ItemsSource = punkty;
            ChartWynik.Series.Add(mySeries);
        }

        private void ZapiszSygnal1_Click(object sender, RoutedEventArgs e)
        {
            if (a.x.Count > 0)
            {
                Serializacja.Serializacja.ZapiszWykres(a, "Sygnal1");
                MessageBox.Show("Zapisano Pomyślnie.", "Zapis", MessageBoxButton.OK);
            }
        }

        private void ZapiszSygnal2_Click(object sender, RoutedEventArgs e)
        {
            if (b.x.Count > 0)
            {
                Serializacja.Serializacja.ZapiszWykres(b, "Sygnal2");
                MessageBox.Show("Zapisano Pomyślnie.", "Zapis", MessageBoxButton.OK);
            }
        }

        private void ZapiszWynik_Click(object sender, RoutedEventArgs e)
        {
            if (c.x.Count > 0)
            {
                Serializacja.Serializacja.ZapiszWykres(a, "Wynik");
                MessageBox.Show("Zapisano Pomyślnie.", "Zapis", MessageBoxButton.OK);
            }
        }

        private void WczytajSygnal1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Serializacja.Serializacja.sciezka;
            openFileDialog1.Title = "Wczytaj Sygnal 1";

            if (openFileDialog1.ShowDialog() == true)
            {
                a = Serializacja.Serializacja.WczytajWykres(openFileDialog1.FileName);
                int nr = 1;
                NarysujWczytanyWykres(nr);
            }
        }

        private void WczytajSygnal2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Serializacja.Serializacja.sciezka;
            openFileDialog1.Title = "Wczytaj Sygnal 2";

            if (openFileDialog1.ShowDialog() == true)
            {
                b = Serializacja.Serializacja.WczytajWykres(openFileDialog1.FileName);
                int nr = 2;
                NarysujWczytanyWykres(nr);
            }
        }

        private void NarysujWczytanyWykres(int nr)
        {
            ScatterSeries mySeries = new ScatterSeries();
            mySeries.Title = "Sygnał";
            mySeries.IndependentValueBinding = new Binding("Key");
            mySeries.DependentValueBinding = new Binding("Value");
            punkty = new List<KeyValuePair<double, double>>();
            if (nr == 1)
            {
                for (int i = 0; i < a.x.Count; i++)
                {
                    punkty.Add(new KeyValuePair<double, double>(a.x[i].Real, a.y[i].Real));
                }
            }
            else
            {
                for (int i = 0; i < b.x.Count; i++)
                {
                    punkty.Add(new KeyValuePair<double, double>(b.x[i].Real, b.y[i].Real));
                }
            }
            mySeries.ItemsSource = punkty;
            Chart.Series.Add(mySeries);
        }

        private void Obliczenia1_Click(object sender, RoutedEventArgs e)
        {
            StatyczneDane.DaneStatyczne.dane = a;
            Obliczenia win2 = new Obliczenia(ile);
            win2.Show();
        }

        private void Obliczenia2_Click(object sender, RoutedEventArgs e)
        {
            StatyczneDane.DaneStatyczne.dane = b;
            Obliczenia win2 = new Obliczenia(ile);
            win2.Show();
        }
        private void Faza1_Click(object sender, RoutedEventArgs e)
        {
            StatyczneDane.DaneStatyczne.dane = a;
            Faza win2 = new Faza(ile);
            win2.Show();
        }
        private void Faza2_Click(object sender, RoutedEventArgs e)
        {
            StatyczneDane.DaneStatyczne.dane = b;
            Faza win2 = new Faza(ile);
            win2.Show();
        }

        private void KonwersjaSygnalow_Click(object sender, RoutedEventArgs e)
        {
            if (Konwersja.SelectedItem.ToString() == "Sygnał 1")
            { 
            StatyczneDane.DaneStatyczne.dane = a;
            }
            else if (Konwersja.SelectedItem.ToString() == "Sygnał 1")
            {
                StatyczneDane.DaneStatyczne.dane = b;
            }
            else
            {
                StatyczneDane.DaneStatyczne.dane = c;
            }
            KonwersjaSygnalow win2 = new KonwersjaSygnalow();
            win2.Show();
        }

        private void PoliczSplot_Click(object sender, RoutedEventArgs e)
        {
            Sygnal splot = new Sygnal();
            splot.x = new List<Complex>();
            splot.y = new List<Complex>();

            int M = a.x.Count;
            int N = b.x.Count;
            int dlugoscSplotu = M + N - 1;

            int i1;

            for (int i = 0; i < dlugoscSplotu; i++)
            {         
                Complex y = new Complex();
                i1 = i;

                for (int k = 0; k < N; k++)
                {
                    if(i1 >= 0 && i1 < M)
                    {
                        var h = a.y[i1];
                        var x = b.y[k];

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
            ChartWynik.Series.Add(mySeries);
        }
    }
}
