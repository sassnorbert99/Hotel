using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beléptető_prototype
{
    public class Users
    {
        private int id = 1;
        public int Id
        {
            get { return id; }
            
            
        }

        private string username;
        public string Username
        {
            get { return username; }
            set
            {
                username = Username;
            }
        }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = Password; }
        }

        public Users(string username,string password)
        {
            id = id + 1;
            this.username = username;
            this.password = password;
        }
    }
}
