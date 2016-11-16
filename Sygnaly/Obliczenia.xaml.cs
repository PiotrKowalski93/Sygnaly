using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Sygnaly.Sygaly;
using Sygnaly.StatyczneDane;

namespace Sygnaly
{
    /// <summary>
    /// Interaction logic for Obliczenia.xaml
    /// </summary>
    public partial class Obliczenia : Window
    {
        public Obliczenia()
        {
            InitializeComponent();

            if(DaneStatyczne.dane is SygnalCiagly)
            {
                SygnalCiagly A = (SygnalCiagly)DaneStatyczne.dane;

                SredniaSygnal1.Text = A.PoliczSrednia().ToString();
                SredniaBezwSygnal1.Text = A.PoliczSredniaBezwzgledna().ToString();
                SkutecznaSygnal1.Text = A.PoliczWartoscSkuteczna().ToString();
                WariancjaSygnal1.Text = A.PoliczWariancje().ToString();
                MocSredniaSygnal1.Text = A.PoliczSredniaMoc().ToString();
            }
            else if (DaneStatyczne.dane is SygnalDyskretny)
            {
                SygnalDyskretny A = (SygnalDyskretny)DaneStatyczne.dane;

                SredniaSygnal1.Text = A.LiczSrednia().ToString();
                SredniaBezwSygnal1.Text = A.LiczSredniaBezwzgledna().ToString();
                SkutecznaSygnal1.Text = A.LiczWartoscSkuteczna().ToString();
                WariancjaSygnal1.Text = A.LiczWariancje().ToString();
                MocSredniaSygnal1.Text = A.LiczSredniaMoc().ToString();
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
    }
}
