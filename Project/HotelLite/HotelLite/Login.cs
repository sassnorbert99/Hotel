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
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Label2_Click(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button_enter_Click(object sender, EventArgs e)
        {
            Entry entry = new Entry();
            if (textBox_loginname.Text==entry.LoginName && Convert.ToString(textBox_passwd.Text.GetHashCode())==entry.Passwd)
            {
                MessageBox.Show("Sikeres bejelentkezés!");
                textBox_passwd.Clear();
                Login login1 = new Login();
                this.Visible = false;
                
                

                

            }

            else
            {
                MessageBox.Show("Hibás bejelentkezési adatok!");
                textBox_passwd.Clear();
            }
            
        }
    }
}
