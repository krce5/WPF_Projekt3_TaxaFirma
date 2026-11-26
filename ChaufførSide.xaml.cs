using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for ChaufførSide.xaml
    /// </summary>
    public partial class ChaufførSide : Window
    {
        private Taxafirma taxafirma;
        private string brugerNavn = "";

        // Standard-constructoren bruges til at oprette chaufførvinduet uden ekstra oplysninger.
        public ChaufførSide()
        {
            InitializeComponent();
        }

        // Denne constructor modtager det eksisterende taxafirma og brugernavnet fra loginvinduet.
        // På den måde bruger chaufførvinduet den samme liste over chauffører.
        public ChaufførSide(Taxafirma taxafirma, string brugerNavn)
        {
            InitializeComponent();

            // Gemmer de modtagne værdier, så de kan bruges af start-vagt-knappen.
            this.taxafirma = taxafirma;
            this.brugerNavn = brugerNavn;
        }

        private void KnapStartVagt_Click(object sender, RoutedEventArgs e)
        {
            // Finder den loggede chauffør og ændrer start-status til true.
            bool ændreStatus = taxafirma.ÆndreStatusStartVagt(brugerNavn);
            Stopwatch startTid = taxafirma.FindStopwatch(brugerNavn);
            if (ændreStatus == true)
            {
                TxtBoxStatus.Text = "Du har startet din vagt: " + ændreStatus;
                startTid.Start();
                
            }
            else
            {
                TxtBoxStatus.Text = "Din vagt er afsluttet: " + ændreStatus;
                startTid.Stop();
                TxtSeTiden.Text = startTid.Elapsed.ToString(@"hh\:mm\:ss");
                startTid.Reset();
                TxtBoxStatus.Text = "Din vagt er afsluttet";
                
            }

        }

        private void SeTidNu_Click(object sender, RoutedEventArgs e)
        {
            Stopwatch arbejdstid = taxafirma.FindStopwatch(brugerNavn);

            if (arbejdstid != null)
            {
                TxtSeTiden.Text = arbejdstid.Elapsed.ToString(@"hh\:mm\:ss");
            }
        }

        private void KnapLedighed_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxStatus.Text = null;
            bool ændreStatus = taxafirma.ÆndreStatusLedighed(brugerNavn);
            if (ændreStatus == false)
            {
                TxtBoxStatus.Text = "Du er ikke ledig: " + ændreStatus;
            }
            else
            {
                TxtBoxStatus.Text = "Du er ledig: " + ændreStatus;
            }
        }

        private void KnapPause_Click(object sender, RoutedEventArgs e)
        {
            TxtBoxStatus.Text = null;
            bool ændreStatus = taxafirma.ÆndreStatusPause(brugerNavn);
            if (ændreStatus == true)
            {
                TxtBoxStatus.Text = "Du har startet din pause: " + ændreStatus;
            }
            else
            {
                TxtBoxStatus.Text = "Din pause er slut: " + ændreStatus;
            }
        }

        private void KnapLoggeUd_Click(object sender, RoutedEventArgs e)
        {
            taxafirma.GemArbejdsTiden(brugerNavn);

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
