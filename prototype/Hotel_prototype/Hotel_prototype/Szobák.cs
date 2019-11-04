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
    }
}
