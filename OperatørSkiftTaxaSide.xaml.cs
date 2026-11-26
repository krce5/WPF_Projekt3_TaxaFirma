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
    /// Interaction logic for OperatørSkiftTaxaSide.xaml
    /// </summary>
    public partial class OperatørSkiftTaxaSide : Window
    {
        private Taxafirma taxafirma;
        private string brugerNavnOperatør = "";
        

        

        public OperatørSkiftTaxaSide(Taxafirma taxafirma, string brugerNavnOperatør)
        {
            InitializeComponent();
            this.taxafirma = taxafirma;
            this.brugerNavnOperatør = brugerNavnOperatør;


            List<Chauffør> listeChaufførerMedTaxaer = new List<Chauffør>();
            listeChaufførerMedTaxaer = taxafirma.LavListeTaxaMedChauffør();
            ListboxTaxaTildeltChauffør.ItemsSource = listeChaufførerMedTaxaer;

            List<Chauffør> listChaufførerUdenTaxaer = new List<Chauffør>();
            listChaufførerUdenTaxaer = taxafirma.LavListeChaufførUdenTaxa();
            ListboxTaxaUdenCH.ItemsSource = listChaufførerUdenTaxaer;

            List<Taxa> taxaudenfiske = new List<Taxa>();
            taxaudenfiske = taxafirma.LavListeTaxaUdenChauffør();
            ListboxChauffør.ItemsSource = taxaudenfiske;
        }



        private void KnapTilbage_Click(object sender, RoutedEventArgs e)
        {
            OperatørSide operatørside = new OperatørSide(taxafirma,brugerNavnOperatør);
            operatørside.Show();
            this.Close();

           
        }

        private void ListboxTaxaUdenCH_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
