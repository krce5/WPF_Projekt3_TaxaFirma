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
        private Taxafirma taxafirma;
        private string brugerNavnKunde = "";

        public KundeBestilling(Taxafirma taxafirma, string brugerNavnKunde)
        {
            InitializeComponent();
            this.taxafirma = taxafirma;
            this.brugerNavnKunde = brugerNavnKunde;
        }

        private void KnapFindTaxa_Click(object sender, RoutedEventArgs e)
        {
            ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
        }

        private void KnapBestil_Click(object sender, RoutedEventArgs e)
        {
            Taxa valgt = (Taxa)ListBoxLedigTaxa.SelectedItem;
            Bestilling bestilling;
            string stedA = TxtBoxStedA.Text;
            string stedB = TxtBoxStedB.Text;
            string brugerKunde = brugerNavnKunde;
            // string nrnr = taxafirma.FindTaxaNrplade();
            if (valgt != null)
            {
                if (stedA != "" && stedB != "")
                {
                    bool svar = taxafirma.FindTaxa(valgt);
                    if (svar)
                    {
                        bestilling = taxafirma.OpretBestilling(brugerKunde, valgt, stedA, stedB);
                        valgt.erLedig = false;
                        ListBoxLedigTaxa.ItemsSource = null;
                        ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
                        LblBesked.Content = "Du har bestilt en taxa med nummerplade: " + valgt.nrPlade;
                        TxtBestillingsOversigt.Text =
                            "BestillingsNr: " + bestilling.bestillingsNr + "\n" +
                            "Fra: " + bestilling.A + "\n" +
                            "Til: " + bestilling.B + "\n" +
                            "Kundenavn: " + bestilling.kunde.brugerNavn + "\n" +
                            "Med bil: " + bestilling.Taxa.nrPlade + "\n" +
                            "Din chauffør: " + bestilling.Ch.brugerNavn;

                        taxafirma.GemBestillingSomTxt(bestilling); //vi kalder metoden for at gemme bestillingen i .txt filen
                    }
                    else
                    {
                        LblBesked.Content = "FEJL! Denne taxa er ikke ledig.";
                    }
                }
                else
                {
                    LblBesked.Content = "FEJL! Husk at skrive addressen.";
                }
            }
            else
            {
                LblBesked.Content = "FEJL! Husk at vælge en taxa først.";
            }

        }

        private void ListBoxLedigTaxa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Taxa valgt = (Taxa)ListBoxLedigTaxa.SelectedItem;
            if (valgt != null)
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

        private void KnapLoggeUd_Click(object sender, RoutedEventArgs e) //genbruge til chaufførside
        {

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();

        }
    }
}
