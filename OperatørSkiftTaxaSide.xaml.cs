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


            List<Chauffør> listeChaufførerMedTaxa = new List<Chauffør>();
            listeChaufførerMedTaxa = taxafirma.HentListeChaufførMedTaxa();
            ListBoxChaufførerMedTaxa.ItemsSource = listeChaufførerMedTaxa;

            List<Chauffør> listeChaufførerUdenTaxa = new List<Chauffør>();
            listeChaufførerUdenTaxa = taxafirma.HentListeChaufførUdenTaxa();
            ListBoxChaufførUdenTaxa.ItemsSource = listeChaufførerUdenTaxa;

            List<Taxa> listeTaxaUdenChauffør = new List<Taxa>();
            listeTaxaUdenChauffør = taxafirma.HentListeTaxaUdenChauffør();
            ListBoxTaxaUdenChauffør.ItemsSource = listeTaxaUdenChauffør;
        }



        private void KnapTilbage_Click(object sender, RoutedEventArgs e)
        {
            OperatørSide operatørside = new OperatørSide(taxafirma,brugerNavnOperatør);
            operatørside.Show();
            this.Close();

           
        }

        private void KnapFradelTaxa_Click(object sender, RoutedEventArgs e)
        {
  
            Chauffør valgtChauffør = (Chauffør)ListBoxChaufførerMedTaxa.SelectedItem;

            // Gemmer taxaen, før den fjernes fra chaufføren.
            Taxa valgtTaxa = valgtChauffør.tildeltTaxa;
            // Fjerner taxaen fra den valgte chauffør.
            valgtChauffør.tildeltTaxa = null;

            // Flytter chaufføren fra listen med chauffører, der har en taxa,
            // til listen med chauffører, der ikke har en taxa.
            taxafirma.listeChaufførerMedTaxa.Remove(valgtChauffør);
            taxafirma.listeChaufførerUdenTaxa.Add(valgtChauffør);

            // Hvis chaufføren havde en taxa, tilføjes taxaen til listen
            // over taxaer uden chauffør.
            if (valgtTaxa != null)
            {
                taxafirma.listeTaxaUdenChauffør.Add(valgtTaxa);
            }

            // Genindlæser listen med chauffører, der har en taxa.
            ListBoxChaufførerMedTaxa.ItemsSource = null;
            ListBoxChaufførerMedTaxa.ItemsSource = taxafirma.listeChaufførerMedTaxa;
            // Genindlæser listen med chauffører uden taxa.
            ListBoxChaufførUdenTaxa.ItemsSource = null;
            ListBoxChaufførUdenTaxa.ItemsSource = taxafirma.listeChaufførerUdenTaxa;
            // Genindlæser listen med taxaer uden chauffør.
            ListBoxTaxaUdenChauffør.ItemsSource = null;
            ListBoxTaxaUdenChauffør.ItemsSource = taxafirma.listeTaxaUdenChauffør;
        }

        private void KnapTildelTaxa_Click(object sender, RoutedEventArgs e)
        {
            // Finder den valgte taxa og chauffør fra de to lister.
            Taxa valgtTaxa = (Taxa)ListBoxTaxaUdenChauffør.SelectedItem;
            Chauffør valgtChauffør = (Chauffør)ListBoxChaufførUdenTaxa.SelectedItem;

            // Sætter taxaen sammen med den valgte chauffør.
            valgtChauffør.tildeltTaxa = valgtTaxa;

            // Flytter chaufføren fra listen uden taxa til listen med chaufører med taxaer.
            taxafirma.listeChaufførerUdenTaxa.Remove(valgtChauffør);
            taxafirma.listeChaufførerMedTaxa.Add(valgtChauffør);
            
            // Fjerner taxaen fra listen over taxaer uden chauffør.
            taxafirma.listeTaxaUdenChauffør.Remove(valgtTaxa);

            // Opdaterer listen over chauffører med taxaer.
            ListBoxChaufførerMedTaxa.ItemsSource = null;
            ListBoxChaufførerMedTaxa.ItemsSource = taxafirma.listeChaufførerMedTaxa;

            // Opdaterer listen over chauffører uden taxa.
            ListBoxChaufførUdenTaxa.ItemsSource = null;
            ListBoxChaufførUdenTaxa.ItemsSource = taxafirma.listeChaufførerUdenTaxa;

            // Opdaterer listen over taxaer uden chauffør.
            ListBoxTaxaUdenChauffør.ItemsSource = null;
            ListBoxTaxaUdenChauffør.ItemsSource = taxafirma.listeTaxaUdenChauffør;
        }
    }
}
