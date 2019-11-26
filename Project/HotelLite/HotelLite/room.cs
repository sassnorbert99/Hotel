using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLite
{
    class room
    {
        int number; //szobaszám
        int beds; //ágyak száma
        comfort roomComfort; //kényelmi szint a szobáknak
        int price; //szoba ára

        public enum comfort
        {
            fapados,
            alacsony_kategória,
            közép_kategória,
            felső_kategória,
            luxus,
            elnöki_lakosztály
        }

        public int Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public int Beds
        {
            get
            {
                return beds;
            }
            set
            {
                if (value > 10)
                {
                    throw new bedsException("10-nél több ágy nem lehet egy szobában");
                }
                else
                {
                    beds = value;
                }
            }
        }


        public comfort RoomComfort
        {
            get
            {
                return roomComfort;
            }
            set
            {
                roomComfort = value;
            }
        }

        public int Price
        {
            get
            {
                return price;
            }
            set
            {
                if (value < 0)
                {
                    throw new priceLessException("nem lehet mínusz értékű a szoba");
                }
                else
                {
                    price = value;
                }
            }
        }
        
    }
}
