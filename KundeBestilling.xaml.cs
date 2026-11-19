using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WPF_Projekt3_TaxaFirma
{
    /// <summary>
    /// Interaction logic for KundeBestilling.xaml
    /// </summary>
    
    public partial class KundeBestilling : Window
    {
        Taxafirma taxafirma = new Taxafirma();
        
        
        public KundeBestilling()
        {
            InitializeComponent();
            Taxa t1 = new Taxa { erLedig = true, nrPlade = "AB 12 345" };
            Taxa t2 = new Taxa { erLedig = false, nrPlade = "EB 32 154" };
            Taxa t3 = new Taxa { erLedig = true, nrPlade = "XT 42 174" };
            Taxa t4 = new Taxa { erLedig = false, nrPlade = "AY 56 894" };
            taxafirma.listTaxaer.Add(t1);
            taxafirma.listTaxaer.Add(t2);
            taxafirma.listTaxaer.Add(t3);
            taxafirma.listTaxaer.Add(t4);
        }

        private void KnapFindTaxa_Click(object sender, RoutedEventArgs e)
        {
            ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
        }

        private void KnapBestil_Click(object sender, RoutedEventArgs e)
        {
            bool svar = taxafirma.FindTaxa();
            string nrnr = taxafirma.FindTaxaNrplade();
            if (svar)
            {
                LblBesked.Content = nrnr;
            }
            else
            {
                LblBesked.Content = "nej";
            }

        }

        private void ListBoxLedigTaxa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }
    }
}
