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
            
        }

        private void KnapFindTaxa_Click(object sender, RoutedEventArgs e)
        {
            ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
        }

        private void KnapBestil_Click(object sender, RoutedEventArgs e)
        {
            Taxa valgt = (Taxa)ListBoxLedigTaxa.SelectedItem;
            bool svar = taxafirma.FindTaxa(valgt);
           // string nrnr = taxafirma.FindTaxaNrplade();
            if (svar)
            {
                
                valgt.erLedig = false;
                ListBoxLedigTaxa.ItemsSource = null;
                ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
                LblBesked.Content = "du har bestilt denne taxa";
            }
            else
            {
                LblBesked.Content = "Denne taxa er ikke ledig";
            }

        }

        private void ListBoxLedigTaxa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Taxa valgt = (Taxa)ListBoxLedigTaxa.SelectedItem;
            if(valgt != null)
            {
               // ListBoxLedigTaxa.ItemsSource = null;
               // ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
                if (valgt.erLedig == true)
                {
                    LblSvar.Content = "Du har valgt: " + valgt.nrPlade;
                }
                else
                {
                    LblSvar.Content = "Denne Taxa er ikke ledig: " + valgt.nrPlade;

                }
            }
        }
    }
}
