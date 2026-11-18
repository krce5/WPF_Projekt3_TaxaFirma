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
        public MainWindow()
        {
            Taxafirma taxafirma = new Taxafirma();
            Kunde k1 = new Kunde();
            k1.brugerNavn = "Carlos";
            k1.adgangskode = "123";
            taxafirma.listKunder.Add(k1);
            Console.WriteLine();
            taxafirma.FindKunde(TxtBoxBrugernavn.Text, TxtBoxAdgangskode.Text);
            //InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            //string navn = TxtBoxBrugernavn.Text;
            //string kode = TxtBoxAdgangskode.Text;

        }
    }
}