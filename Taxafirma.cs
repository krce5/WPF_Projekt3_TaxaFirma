using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Projekt3_TaxaFirma
{

    public class Taxafirma
    {
        public List<Kunde> listKunder = new List<Kunde>();
        public List<Taxa> listTaxaer = new List<Taxa>();

        public List<Chauffør> listChauffører = new List<Chauffør>();
  
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
        public bool FindChauffør( string brugerNavn, string adgangskode)
        {
            int i = 0;
            while(i< listChauffører.Count)
            {
                Chauffør ch = listChauffører[i];
                if(brugerNavn == ch.brugerNavn && adgangskode == ch.adgangskode)
                {
                    ch.erLoggetInd = true;
                    return true;
                }

                i++;
            }


            return false;
        }

        public bool FindTaxa(Taxa valgt) //finder den ledige taxa og ændre den fra true til false
        { 
            Taxa taxa = valgt;
            if(taxa.erLedig == true)
            {
                 taxa.erLedig = false;
                 return true;
            }
            else
            {
                return false;

            }     
        }

        public string FindTaxaNrplade() 
        {
            int i = 0;
            string svar = "";
            while(i < listTaxaer.Count)
            {
                Taxa taxanr = listTaxaer[i];
                if(taxanr.erLedig == true)
                {
                    svar = taxanr.nrPlade;
                }
                i++;
            }
            return svar;
        }

        public void ÆndreStatusStartVagt(string brugerNavn)
        {
            Chauffør ch1 = new Chauffør();
            ch1.brugerNavn = brugerNavn;
            //bool chaufførVariabel = FindChauffør(ch1.brugerNavn,ch1.adgangskode);
            int i = 0;
            ChaufførSide chaufførside = new ChaufførSide();

            while(i < listChauffører.Count)
            {
                if(chaufførside.TxtBoxStatus.Text == brugerNavn)
                {
                    ch1.start = true;
                }

                i++;
            }

            Console.WriteLine();

        }
    }
}
