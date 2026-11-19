using System;
using System.Collections.Generic;
using System.Text;

namespace WPF_Projekt3_TaxaFirma
{
    public class Taxa
    {
        public bool erLedig;
        public string nrPlade;
        public override string ToString()
        {
            if(erLedig == true)
            {
                return nrPlade + ": Er ledig";
            }
            else
            {
                return nrPlade + ": Er ikke ledig";
            }
        }
    }
}
