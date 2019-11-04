using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_prototype
{
    class Vendég
    {
        string nev;

        public string Nev
        {
            get
            {
                return nev;
            }
            set
            {
                nev = value;
            }
        }

        string taj;

        public string Taj
        {
            get
            {
                return taj;
            }
            set
            {
                taj = value;
            }
        }

        string lakcim;

        public string Lakcim
        {
            get
            {
                return lakcim;
            }
            set
            {
                lakcim = value;
            }
        }

        int kivettSzoba;

        public int KivettSzoba
        {
            get
            {
                return kivettSzoba;
            }
            set
            {
                kivettSzoba = value;
            }
        }

        public Vendég(string _nev, string _taj, string _lakcim, int _kivettSzoba)
        {
            Nev = _nev;
            Taj = _taj;
            Lakcim = _lakcim;
            KivettSzoba = _kivettSzoba;
        }

        public override string ToString()
        {
            return "név: "+Nev+" taj száma: "+Taj+" lakcíme: "+Lakcim+" kivett szoba: "+KivettSzoba;
        }
    }
}
