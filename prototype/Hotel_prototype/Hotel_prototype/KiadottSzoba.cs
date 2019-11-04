using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_prototype
{
    class KiadottSzoba
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

        public KiadottSzoba(string _nev, int _kivettSzoba)
        {
            Nev = _nev;
            KivettSzoba = _kivettSzoba;
        }
    }
}
