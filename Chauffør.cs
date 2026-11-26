using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WPF_Projekt3_TaxaFirma
{
    public class Chauffør
    {
        public string brugerNavn;
        public string adgangskode;
        public bool erLoggetInd;
        public bool erLedig = true;
        public bool pause = false;
        public bool start = false;
        public double arbejdstid;

        public Taxa tildeltTaxa;
        public Stopwatch stopwatch = new Stopwatch();
        public double tid;
        public override string ToString()
        {
            
            if(tildeltTaxa != null)
            {
                return brugerNavn + " mødt på arbejde: " + start + "\n" +
                     "ledighed: " + erLedig + ", pause: " + pause + "\n" +
                     "bil: " + tildeltTaxa.nrPlade + "\n" +
                     "----------------";
            }
            else
            {
                return brugerNavn + " mødt på arbejde: " + start + "\n" +
                    "ledighed: " + erLedig + ", pause: " + pause + "\n" +
                    "uden taxa" + "\n" +
                    "----------------";
            }
        }
    }
}
