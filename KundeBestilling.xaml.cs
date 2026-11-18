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
            Taxa t1 = new Taxa { erLedig = true, nrPlade = "AB 123 45" };
            Taxa t2 = new Taxa { erLedig = false, nrPlade = "EB 321 54" };
            taxafirma.listTaxaer.Add(t1);
            taxafirma.listTaxaer.Add(t2);
        }

        private void KnapFindTaxa_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void KnapBestil_Click(object sender, RoutedEventArgs e)
        {
            bool svar = taxafirma.FindTaxa();

        }
    }
}
