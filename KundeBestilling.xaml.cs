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

            TxtBoxPris.Text =
                "Start gebyr: 49 kr" + "\n" +
                "Pris per KM: 17,70 kr" + "\n" + 
                "Pris i minut: 7,50 kr" + "\n" + 
                "Støt Brysterne pris per KM: 2 kr";
            }

        private void KnapFindTaxa_Click(object sender, RoutedEventArgs e)
        {
            //ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;

            ListBoxLedigTaxa.Items.Clear();

            int i = 0;
            while (i < taxafirma.listTaxaer.Count)
            {

                Taxa aktuel = taxafirma.listTaxaer[i];
                //1.Opret en beholder (StackPanel)
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.Margin = new Thickness(5);
                panel.Tag = aktuel;

                //2.Opret billedet
                Image billede = new Image();
                billede.Width = 40;
                billede.Height = 40;
                billede.Margin = new Thickness(0, 0, 5, 0);

                //Indlæs billedet manuelt
                billede.Source = new BitmapImage(new System.Uri("Images/" + aktuel.URL, System.UriKind.Relative));

                //3.Opret tekstfeltet
                TextBlock tekst = new TextBlock();
                tekst.Text = aktuel.ToString();
                tekst.VerticalAlignment = VerticalAlignment.Center;
                tekst.FontSize = 14;

                //4.Saml elementerne: Put billedet og teksten ind i panelet
                panel.Children.Add(billede);
                panel.Children.Add(tekst);

                //5.Put hele panelet direkte ind i ListBoxen
                ListBoxLedigTaxa.Items.Add(panel);

                i++;
            }


        }

        private void KnapBestil_Click(object sender, RoutedEventArgs e)
        {
            StackPanel valgtPanel = (StackPanel)ListBoxLedigTaxa.SelectedItem;
            if(valgtPanel == null)
            {
                LblBesked.Content = "FEJL! Husk at vælge en taxa først.";
                return;
            }

            //Taxa valgt = (Taxa)ListBoxLedigTaxa.SelectedItem;
            Taxa valgt = (Taxa)valgtPanel.Tag;

            Bestilling bestilling;
            string stedA = TxtBoxStedA.Text;
            string stedB = TxtBoxStedB.Text;
            string brugerKunde = brugerNavnKunde;
            string tid = taxafirma.FåFatITid(DateTime.Now);
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

                        //ListBoxLedigTaxa.ItemsSource = null;
                        //ListBoxLedigTaxa.ItemsSource = taxafirma.listTaxaer;
                        ListBoxLedigTaxa.Items.Clear();

                        LblBesked.Content = "Du har bestilt en taxa med nummerplade: " + valgt.nrPlade;
                        TxtBestillingsOversigt.Text =
                            "BestillingsNr: " + bestilling.bestillingsNr + "\n" +
                            "Fra: " + bestilling.A + "\n" +
                            "Til: " + bestilling.B + "\n" +
                            "Kundenavn: " + bestilling.kunde.brugerNavn + "\n" +
                            "Med bil: " + bestilling.Taxa.nrPlade + "\n" +
                            "Din chauffør: " + bestilling.Ch.brugerNavn + "\n" +
                            tid;

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
