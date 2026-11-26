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

        private void KnapFradelTaxa_Click(object sender, RoutedEventArgs e)
        {
  
            Chauffør valgtChauffør = (Chauffør)ListboxTaxaTildeltChauffør.SelectedItem;

            // Gemmer taxaen, før den fjernes fra chaufføren.
            Taxa valgtTaxa = valgtChauffør.tildeltTaxa;
            // Fjerner taxaen fra den valgte chauffør.
            valgtChauffør.tildeltTaxa = null;

            // Flytter chaufføren fra listen med chauffører, der har en taxa,
            // til listen med chauffører, der ikke har en taxa.
            taxafirma.taxaMedChauffør.Remove(valgtChauffør);
            taxafirma.taxaUdenChauffør.Add(valgtChauffør);

            // Hvis chaufføren havde en taxa, tilføjes taxaen til listen
            // over taxaer uden chauffør.
            if (valgtTaxa != null)
            {
                taxafirma.taxaUdenFisk.Add(valgtTaxa);
            }

            // Genindlæser listen med chauffører, der har en taxa.
            ListboxTaxaTildeltChauffør.ItemsSource = null;
            ListboxTaxaTildeltChauffør.ItemsSource = taxafirma.taxaMedChauffør;
            // Genindlæser listen med chauffører uden taxa.
            ListboxTaxaUdenCH.ItemsSource = null;
            ListboxTaxaUdenCH.ItemsSource = taxafirma.taxaUdenChauffør;
            // Genindlæser listen med taxaer uden chauffør.
            ListboxChauffør.ItemsSource = null;
            ListboxChauffør.ItemsSource = taxafirma.taxaUdenFisk;
        }

        private void KnapTildelTaxa_Click(object sender, RoutedEventArgs e)
        {
            // Finder den valgte taxa og chauffør fra de to lister.
            Taxa valgtTaxa = (Taxa)ListboxChauffør.SelectedItem;
            Chauffør valgtChauffør = (Chauffør)ListboxTaxaUdenCH.SelectedItem;

            // Sætter taxaen sammen med den valgte chauffør.
            valgtChauffør.tildeltTaxa = valgtTaxa;

            // Flytter chaufføren fra listen uden taxa til listen med tildelte taxaer.
            taxafirma.taxaMedChauffør.Add(valgtChauffør);
            taxafirma.taxaUdenChauffør.Remove(valgtChauffør);

            // Fjerner taxaen fra listen over taxaer uden chauffør.
            taxafirma.taxaUdenFisk.Remove(valgtTaxa);

            // Opdaterer listen over chauffører med tildelte taxaer.
            ListboxTaxaTildeltChauffør.ItemsSource = null;
            ListboxTaxaTildeltChauffør.ItemsSource = taxafirma.taxaMedChauffør;

            // Opdaterer listen over chauffører uden taxa.
            ListboxTaxaUdenCH.ItemsSource = null;
            ListboxTaxaUdenCH.ItemsSource = taxafirma.taxaUdenChauffør;

            // Opdaterer listen over taxaer uden chauffør.
            ListboxChauffør.ItemsSource = null;
            ListboxChauffør.ItemsSource = taxafirma.taxaUdenFisk;
        }
    }
}
