using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLite
{
    class Person
    {
        string name; //név
        string tin; //adóazonosító szám
        string identity; //személyi szám
        string address; //lakcím
        string birthDate; //születési dátum
        string nationality; //nemzetiség
        int checkedRoom; //kivenni kívánt szoba

        public int CheckedRoom
        {
            get
            {
                return checkedRoom;
            }
            set
            {
                if (value > 100)
                {
                    throw new tooMuchRoomException("nincs ennyi szoba a hotelban");
                }
                else
                {
                    checkedRoom = value;
                }
            }
        }

       

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Tin
        {
            get
            {
                return tin;
            }
            set
            {
                bool isIntString = tin.All(char.IsDigit);
                if (isIntString == true)
                {
                    tin = value;
                }
                else
                {
                    throw new tinException("Az adószám csak számokat tartalmazhat");
                }
            }

        }

        public string Identity
        {
            get
            {
                return identity;
            }
            set
            {
                if (value.Length != 11)
                {
                    throw new identityException("11 hosszú lehet a személyi azonosító");
                }
                else
                {
                    identity = value;
                }
            }
        }

        public string Address
        {
            get
            {
                return address;
            }
            set
            {
                address = value;
            }
        }


        public string BirthDate
        {
            get
            {
                return birthDate;
            }
            set
            {
                birthDate = value;
            }
        }

        public string Nationality
        {
            get
            {
                return nationality;
            }
            set
            {
                if (value.Length > 20)
                {
                    throw new nationalityException("túl hosszú a mező értéke");
                }
            }
        }

        public Person(string Name, string Tin, string Identity, string Address, string Birthday, string Nationality)
        {
            this.name = Name;
            this.tin = Tin;
            this.identity = Identity;
            this.address = Address;
            this.birthDate = Birthday;
            this.nationality = Nationality;
        }
        /*
        public override string ToString()
        {
            return "név: " + name + " személyi száma: " + identity + " lakcíme: " + address + " kivett szoba: " + checkedRoom;
        }
        */
    }
}
