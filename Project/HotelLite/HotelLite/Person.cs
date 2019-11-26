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
    }
}
