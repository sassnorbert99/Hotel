using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelLite
{
    class Person
    {
      private string name; //név
      private string tin; //adóazonosító szám
      private string birthCity;
      private string ssn; //személyi szám
      private string address; //lakcím
      private string birthDate; //születési dátum
      private int checkedRoom; //kivenni kívánt szoba


        public string BirthCity
        {
            get
            {
                return birthCity;
            }
            set
            {
                birthCity = value;
            }
        }
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

        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                if (value.Length != 11)
                {
                    throw new identityException("11 hosszú lehet a személyi azonosító");
                }
                else
                {
                    ssn = value;
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

        

        public Person()
        {

        }


        public Person(string Name, string Tin, string Identity, string Address, string Birthday,string BirthCity, string Nationality)
        {
            this.name = Name;
            this.tin = Tin;
            this.ssn = Identity;
            this.address = Address;
            this.birthDate = Birthday;
            this.birthCity = BirthCity;
            
        }
        /*
        public override string ToString()
        {
            return "név: " + name + " személyi száma: " + identity + " lakcíme: " + address + " kivett szoba: " + checkedRoom;
        }
        */

        /*
        public string SSN
        {
            get
            {
                return ssn;
            }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Az ssn nem lehet null!");
                if (value.Length != 9)
                    throw new ArgumentOutOfRangeException("Az ssn kötelezően 9 karakter hosszú!");
                this.ssn = value;
            }
        }

        public char Sex
        {
            get { return sex; }
            set
            {
                if (value != 'F' && value != 'M')
                    throw new ArgumentOutOfRangeException("A sex vagy F vagy M lehet!");
                this.sex = value;
            }
        }

        public string BirthCity
        {
            get { return birthCity; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException("A születési hely nem lehet null!");
                this.birthCity = value;
            }
        }
        */
    }
}
