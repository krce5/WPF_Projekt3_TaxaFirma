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

        public string FindchaufførNrplade(String brugerNavn )
        {
            int i = 0;
            string svar = "";
            while(i < listChauffører.Count)
            {
                Chauffør Ch = listChauffører[i];
                
                if(brugerNavn == Ch.brugerNavn)
                {


                    svar = Ch.tildeltTaxa.nrPlade;
                }



                i++;
            }
            return svar;

        }



        public bool ÆndreStatusStartVagt(string brugerNavn)
        {
            int i = 0;
            bool svar = true;
            ChaufførSide chaufførside = new ChaufførSide();

            while(i < listChauffører.Count)
            {
                Chauffør ch1 = listChauffører[i];
                if (ch1.brugerNavn == brugerNavn)
                {
                    if (ch1.start == false)
                    {
                        ch1.start = true;
                        svar = true;
                    }
                    else
                    {
                        ch1.start = false;
                        svar = false;
                    }
                }
                i++;
            }
            return svar;
        }

        public bool ÆndreStatusLedighed(string brugerNavn)
        {
            int i = 0;
            bool svar = false;
            ChaufførSide chaufførside = new ChaufførSide();

            while (i < listChauffører.Count)
            {
                Chauffør ch1 = listChauffører[i];
                if (ch1.brugerNavn == brugerNavn)
                {
                    if (ch1.erLedig == true)
                    {
                        ch1.erLedig = false;
                        svar = false;
                    }
                    else
                    {
                        ch1.erLedig = true;
                        svar = true;
                    }
                }
                i++;
            }
            return svar;
        }

        public bool ÆndreStatusPause(string brugerNavn)
        {
            int i = 0;
            bool svar = false;
            ChaufførSide chaufførside = new ChaufførSide();

            while (i < listChauffører.Count)
            {
                Chauffør ch1 = listChauffører[i];
                if (ch1.brugerNavn == brugerNavn)
                {
                    if (ch1.pause == false)
                    {
                        ch1.pause = true;
                        svar = true;
                    }
                    else
                    {
                        ch1.pause = false;
                        svar = false;
                    }
                }
                i++;
            }
            return svar;
        }

    }
}
