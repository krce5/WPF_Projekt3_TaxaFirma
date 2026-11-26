using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using System.IO;

namespace WPF_Projekt3_TaxaFirma
{

    public class Taxafirma
    {
        public List<Kunde> listKunder = new List<Kunde>();
        public List<Taxa> listTaxaer = new List<Taxa>();

        public List<Chauffør> listChauffører = new List<Chauffør>();

        public List<Bestilling> listBestillinger = new List<Bestilling>();

        public List<Taxaoperatør> listTaxaoperatør = new List<Taxaoperatør>();
        public List<Chauffør> taxaMedChauffør = new List<Chauffør>();
        public List<Chauffør> taxaUdenChauffør = new List<Chauffør>();
        public List<Taxa> taxaUdenFisk = new List<Taxa>();


        public bool FindKunde(string brugerNavn, string adgangskode)
        {
            int i = 0;
            while (i < listKunder.Count)
            {
                Kunde kunde = listKunder[i]; //opret en object for at få adgang til listen
                if (brugerNavn == kunde.brugerNavn && adgangskode == kunde.adgangskode)
                {
                    kunde.erLoggetInd = true;
                    return true;

                }

                i++;
            }
            return false;
        }
        public bool FindChauffør(string brugerNavn, string adgangskode)
        {
            int i = 0;
            while (i < listChauffører.Count)
            {
                Chauffør ch = listChauffører[i];
                if (brugerNavn == ch.brugerNavn && adgangskode == ch.adgangskode)
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
            if (taxa.erLedig == true)
            {
                taxa.erLedig = false;
                return true;
            }
            else
            {
                return false;

            }
        }

        public bool FindOperatør(string brugerNavn, string adgangskode)
        {
            int i = 0;
            Taxaoperatør op1;
            while (i < listTaxaoperatør.Count)
            {
                op1 = listTaxaoperatør[i];
                if (brugerNavn == op1.brugerNavn && adgangskode == op1.adgangskode)
                {
                    op1.erLoggetInd = true;
                    return true;
                }
                i++;
            }
            return false;
        }

        public string FindTaxaNrplade()
        {
            int i = 0;
            string svar = "";
            while(i < listTaxaer.Count)
            {
                Taxa taxanr = listTaxaer[i];
                if (taxanr.erLedig == true)
                {
                    svar = taxanr.nrPlade;
                }
                i++;
            }
            return svar;
        }

        public string FindchaufførNrplade(String brugerNavn)
        {
            int i = 0;
            string svar = "";
            while (i < listChauffører.Count)
            {
                Chauffør Ch = listChauffører[i];

                if (brugerNavn == Ch.brugerNavn)
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

            while (i < listChauffører.Count)
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

        public Stopwatch FindStopwatch(string brugerNavn)
        {
            Stopwatch svar = null;
            int i = 0;
            while (i < listChauffører.Count)
            {
                Chauffør ch = listChauffører[i];
                if (brugerNavn == ch.brugerNavn)
                {
                    svar = ch.stopwatch;
                }

                i++;
            }
            return svar;
        }
        public Bestilling OpretBestilling(string brugerNavnKunde, Taxa taxa, string stedA, string stedB)
        {
            Bestilling bestilling = new Bestilling();
            Kunde lokalKunde = Find(brugerNavnKunde);
            Chauffør lokalChauffør = Find(taxa);

            int lokalBestillingsNR = rndBestillingsNr();
            bestilling.Ch = lokalChauffør;
            bestilling.kunde = lokalKunde;
            bestilling.A = stedA;
            bestilling.B = stedB;
            bestilling.bestillingsNr = lokalBestillingsNR;
            bestilling.Taxa = lokalChauffør.tildeltTaxa;

            listBestillinger.Add(bestilling);

            return bestilling;
        }
        private int rndBestillingsNr()
        {
            Random random = new Random();
            int svar = random.Next(1000, 2000);
            return svar;
        }

        private Kunde Find(string brugerNavn)
        {
            Kunde svar = null;
            int i = 0;
            while (i < listKunder.Count)
            {
                Kunde kunde = listKunder[i];
                if (kunde.brugerNavn == brugerNavn)
                {
                    svar = kunde;
                }
                i++;
            }

            return svar;
        }

        private Chauffør Find(Taxa tildeltTaxa)
        {
            Chauffør svar = null;
            int i = 0;
            while (i < listChauffører.Count)
            {
                Chauffør chauffør = listChauffører[i];
                if (chauffør.tildeltTaxa == tildeltTaxa)
                {
                    svar = chauffør;
                }
                i++;
            }
            return svar;
        }

        public string findChaufførNavn(string brugerNavn)
        {
            int i = 0;
            string svar = "";
            while (i < listChauffører.Count)
            {
                Chauffør cc = listChauffører[i];
                if (brugerNavn == cc.brugerNavn)
                {
                    svar = cc.brugerNavn;
                    return svar;
                }
                i++;

            }
            return svar;
        }

        public void findTildelteTaxa()
        {

        }

        public List<Chauffør> LavListeTaxaMedChauffør()
        {
            taxaMedChauffør.Clear();
            int i = 0;
            while(i < listChauffører.Count)
            {
                Chauffør cc = listChauffører[i];
                if(cc.tildeltTaxa != null)
                {
                    taxaMedChauffør.Add(listChauffører[i]);
                }
                i++;
            }
            return taxaMedChauffør;
        }

        public List<Chauffør> LavListeChaufførUdenTaxa()
        {
            taxaUdenChauffør.Clear();
            int i = 0;
            while (i < listChauffører.Count)
            {
                Chauffør cc = listChauffører[i];
                if (cc.tildeltTaxa == null)
                {
                    taxaUdenChauffør.Add(listChauffører[i]);
                }
                i++;
            }
            return taxaUdenChauffør;
        }

        public List<Taxa> LavListeTaxaUdenChauffør()
        {
            taxaUdenFisk.Clear();
            int i = 0;
            while (i < listTaxaer.Count)
            {
                Chauffør cc = listChauffører[i];
                if (cc.tildeltTaxa == null)
                {
                    taxaUdenFisk.Add(listTaxaer[i]);
                }
                i++;
            }
            return taxaUdenFisk;
        }

        public void GemBestillingSomTxt(Bestilling bestilling)
        {
            string filsti = Path.Combine(AppContext.BaseDirectory, "gemteBestillinger.txt"); //Fortæller hvor filen skal gemmes

            string tekst =  //fortælleer hvad der skal gemmes i filen
                "Bestillingsnr: " + bestilling.bestillingsNr + Environment.NewLine +
                "Fra: " + bestilling.A + Environment.NewLine +
                "Til: " + bestilling.B + Environment.NewLine +
                "Kundenavn: " + bestilling.kunde.brugerNavn + Environment.NewLine +
                "Med bil: " + bestilling.Taxa.nrPlade + Environment.NewLine +
                "Chauffør: " + bestilling.Ch.brugerNavn + Environment.NewLine +
                "---------------------------------------" + Environment.NewLine;
            File.AppendAllText(filsti, tekst, Encoding.UTF8); //Encoding - så særlige bogstaver på dansk kan fungere

        }
    }
}
