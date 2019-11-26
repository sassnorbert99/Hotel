using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelLite
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button_Enter_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            if (entry.LoginName == textBox_loginname.Text && entry.Passwd == Convert.ToString(textBox_passwd.Text.GetHashCode())) 
            {
                textBox_passwd.Clear();
                MessageBox.Show("Sikeres bejelentkezés!");
                

                Main main = new Main();
                main.Show();
            }
            else
            {
                MessageBox.Show("Hibás bejelentkezési adatok!");
            }
        }
    }
}
