using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_Projekt3_TaxaFirma
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Taxafirma taxafirma = new Taxafirma();
        
        public MainWindow()
        {
            InitializeComponent();

            Kunde k1 = new Kunde();
            k1.brugerNavn = "Carlos";
            k1.adgangskode = "123";
            taxafirma.listKunder.Add(k1);

            Kunde k2 = new Kunde {brugerNavn = "Bent", adgangskode = "hej med dig" };
            taxafirma.listKunder.Add(k2);
 
            Taxa t1 = new Taxa { erLedig = true, nrPlade = "AB 12 345" };
            Taxa t2 = new Taxa { erLedig = false, nrPlade = "EB 32 154" };
            Taxa t3 = new Taxa { erLedig = true, nrPlade = "XT 42 174" };
            Taxa t4 = new Taxa { erLedig = false, nrPlade = "AY 56 894" };
            taxafirma.listTaxaer.Add(t1);
            taxafirma.listTaxaer.Add(t2);
            taxafirma.listTaxaer.Add(t3);
            taxafirma.listTaxaer.Add(t4);


            Chauffør ch1 = new Chauffør { brugerNavn = "Bob", adgangskode = "123", tildeltTaxa = t1};
            Chauffør ch2 = new Chauffør { brugerNavn = "Mogens", adgangskode = "321", tildeltTaxa = t2};
            Chauffør ch3 = new Chauffør { brugerNavn = "Morten", adgangskode = "456", tildeltTaxa = t3 };
            Chauffør ch4 = new Chauffør { brugerNavn = "Penny", adgangskode = "456", tildeltTaxa = t4 };
            taxafirma.listChauffører.Add(ch1);
            taxafirma.listChauffører.Add(ch2);
            taxafirma.listChauffører.Add(ch3);
            taxafirma.listChauffører.Add(ch4);



        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string navn = TxtBoxBrugernavn.Text;
            //string kode = TxtBoxAdgangskode.Text;
            bool logindGodkendtKunde = taxafirma.FindKunde(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            bool loginGodkendtCh = taxafirma.FindChauffør(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            string brugerKunde = TxtBoxBrugernavn.Text;
            if(logindGodkendtKunde)
            {
                TxtBoxBesked.Text = "Yupiiiii!";
                KundeBestilling kundeSide = new KundeBestilling(taxafirma, brugerKunde);
                kundeSide.Show();
                this.Close();
            }
            else if(loginGodkendtCh)
            {

                TxtBoxBesked.Text = "Yupiiiii!";
                // Sender det eksisterende taxafirma og chaufførens brugernavn til chaufførvinduet.
                ChaufførSide chaufførSide = new ChaufførSide(taxafirma, TxtBoxBrugernavn.Text);
                chaufførSide.Show();
                this.Close();
                chaufførSide.LblVelkommen.Content = "Velkommen " + TxtBoxBrugernavn.Text;
                //test
                string nrplade = taxafirma.FindchaufførNrplade(TxtBoxBrugernavn.Text);


                chaufførSide.LblNrPlade.Content = "Du skal kører med " + nrplade;


                //få adgang til og udskriv de gemte bestillinger fra .txt filen
                string[] læsBestilling = System.IO.File.ReadAllLines(@"gemteBestillinger.txt");
                chaufførSide.ListBoxBestillinger.ItemsSource = læsBestilling;
            }
            else
            {
                TxtBoxBesked.Text = "Puuuhhaaaa :(";
            }
        }
    }
}