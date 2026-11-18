using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Projekt3_TaxaFirma
{

    public class Taxafirma
    {
        public List<Kunde> listKunder = new List<Kunde>();
        public List<Taxa> listTaxaer = new List<Taxa>();
  
        public bool FindKunde(string brugerNavn, string adgangskode)
        {
            int i = 0;
            while (i < listKunder.Count)
            {
                Kunde kunde = listKunder[i]; //opret en object for at få adgang til listen
                if(brugerNavn == kunde.brugerNavn && adgangskode == kunde.adgangskode)
                {
                    kunde.erLoggetInd = true;
                    return true;

                }

                i++;
            }
            return false;
        }

        public bool FindTaxa()
        {
            int i = 0;
            while (i < listTaxaer.Count)
            {
                Taxa taxa = listTaxaer[i];
                if(taxa.erLedig == true)
                {
                    taxa.erLedig = false;
                    return false;
                }
                i++;
                return true;
            }
        }
    }
}
