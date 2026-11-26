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
 
            Taxa t1 = new Taxa { erLedig = true, nrPlade = "AB 12 345", URL="bil1.png" };
            Taxa t2 = new Taxa { erLedig = false, nrPlade = "EB 35 196", URL = "bil2.png" };
            Taxa t3 = new Taxa { erLedig = true, nrPlade = "XT 42 174", URL = "bil3.png" };
            Taxa t4 = new Taxa { erLedig = false, nrPlade = "AY 56 894", URL = "bil2.png" };
            taxafirma.listTaxaer.Add(t1);
            taxafirma.listTaxaer.Add(t2);
            taxafirma.listTaxaer.Add(t3);
            taxafirma.listTaxaer.Add(t4);


            Chauffør ch1 = new Chauffør { brugerNavn = "Bob", adgangskode = "123", tildeltTaxa = t1};
            Chauffør ch2 = new Chauffør { brugerNavn = "Mogens", adgangskode = "321", tildeltTaxa = t3};
            Chauffør ch3 = new Chauffør { brugerNavn = "Jakob", adgangskode = "456", tildeltTaxa = t2 };
            Chauffør ch4 = new Chauffør { brugerNavn = "Penny", adgangskode = "456" };
            taxafirma.listChauffører.Add(ch1);
            taxafirma.listChauffører.Add(ch2);
            taxafirma.listChauffører.Add(ch3);
            taxafirma.listChauffører.Add(ch4);

            Taxaoperatør op1 = new Taxaoperatør { brugerNavn = "Lise", adgangskode = "789" };
            taxafirma.listTaxaoperatør.Add(op1);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string navn = TxtBoxBrugernavn.Text;
            //string kode = TxtBoxAdgangskode.Text;
            bool logindGodkendtKunde = taxafirma.FindKunde(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            bool loginGodkendtCh = taxafirma.FindChauffør(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            bool loginGodkendtOp = taxafirma.FindOperatør(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            string brugerKunde = TxtBoxBrugernavn.Text;
            if(logindGodkendtKunde)
            {
                KundeBestilling kundeSide = new KundeBestilling(taxafirma, brugerKunde);
                kundeSide.Show();
                this.Close();
            }
            else if(loginGodkendtCh)
            {
                // Sender det eksisterende taxafirma og chaufførens brugernavn til chaufførvinduet.
                ChaufførSide chaufførSide = new ChaufførSide(taxafirma, TxtBoxBrugernavn.Text);
                chaufførSide.Show();
                this.Close();
                chaufførSide.LblVelkommen.Content = "Velkommen " + TxtBoxBrugernavn.Text;
                //test
                string nrplade = taxafirma.FindchaufførNrplade(TxtBoxBrugernavn.Text);


                chaufførSide.LblNrPlade.Content = "Du skal kører med taxa: " + nrplade;


                //få adgang til og udskriv de gemte bestillinger fra .txt filen
                string[] læsBestilling = System.IO.File.ReadAllLines(@"gemteBestillinger.txt");
                chaufførSide.ListBoxBestillinger.ItemsSource = læsBestilling;
            }
            else if(loginGodkendtOp)
            {
                OperatørSide operatørSide = new OperatørSide(taxafirma, TxtBoxBrugernavn.Text);
                operatørSide.Show();
                this.Close();
                operatørSide.LblVelkommen.Content = "Velkommen " + TxtBoxBrugernavn.Text;

                operatørSide.ListBoxChauffører.ItemsSource = taxafirma.listChauffører;
                operatørSide.ListBoxTaxaer.ItemsSource = taxafirma.listTaxaer;
                operatørSide.ListBoxBestillinger.ItemsSource = taxafirma.listBestillinger;

                string[] læsBestilling = System.IO.File.ReadAllLines(@"gemteBestillinger.txt");
                operatørSide.ListBoxBestillinger.ItemsSource = læsBestilling;

            }
            else
            {
                LblBesked.Content = "Puuuhhaaaa :(";
            }
        }
    }
}