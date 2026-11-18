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
        Taxafirma t = new Taxafirma();
        public MainWindow(Taxafirma taxaStation)
        {
            t = taxaStation;
            InitializeComponent();

            Kunde k1 = new Kunde();
            k1.brugerNavn = "Carlos";
            k1.adgangskode = "123";
            taxafirma.listKunder.Add(k1);

            Kunde k2 = new Kunde {brugerNavn = "Bent", adgangskode = "hej med dig" };
            taxafirma.listKunder.Add(k2);
          
            
          
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //string navn = TxtBoxBrugernavn.Text;
            //string kode = TxtBoxAdgangskode.Text;
            bool logindGodkendt = taxafirma.FindKunde(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);

            if(logindGodkendt)
            {
                TxtBoxBesked.Text = "Yupiiiii!";
                KundeBestillingsSide kundeSide = new KundeBestillingsSide(t);
                kundeSide.Show();
            }
            else
            {
                TxtBoxBesked.Text = "Puuuhhaaaa :(";
            }
        }
    }
}