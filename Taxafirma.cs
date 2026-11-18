using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Projekt3_TaxaFirma
{

    public class Taxafirma
    {
        public List<Kunde> listKunder = new List<Kunde>();
  
        public void FindKunde(string brugerNavn, string adgangskode)
        {
            int i = 0;
            while (i < listKunder.Count)
            {
                if(brugerNavn == listKunder.k1.brugerNavn)

                i++;
            }
        }
    }
}
