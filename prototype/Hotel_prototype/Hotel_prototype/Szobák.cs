using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotel_prototype
{
    class Szobák
    {
        int szobaszam;

        public int Szoba
        {
            get
            {
                return szobaszam;
            }
            set
            {
                szobaszam = value;
            }
        }

        int agyszam;

        public int Agyszam
        {
            get
            {
                return agyszam;
            }
            set
            {
                agyszam = value;
            }
        }

        felszereltseg felszereles;

        public felszereltseg Felszereles
        {
            get
            {
                return felszereles;
            }
            set
            {
                felszereles = value;
            }
        }

        public Szobák(int _szoba, int _agyszam, felszereltseg _felszereles)
        {
            Szoba = _szoba;
            Agyszam = _agyszam;
            Felszereles = _felszereles;
        }

        public override string ToString()
        {
            return "szobák száma: "+ Szoba + " ágyak száma: " + Agyszam + " agyszam felszereltsége: " + Felszereles;
        }
    }
}
