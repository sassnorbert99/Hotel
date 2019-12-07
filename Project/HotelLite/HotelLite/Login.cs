using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

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

                this.Hide();
                ListForm main = new ListForm();
                main.ShowDialog();
                
            }
            else
            {
                MessageBox.Show("Hibás bejelentkezési adatok!");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {
            ListForm list = new ListForm();
            list.Close();
        }

       

private void CheckEnterKeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)

            {
                Button_Enter_Click(sender,e);
            }
        }

        private void TextBox_passwd_TextChanged(object sender, EventArgs e)
        {
            this.textBox_passwd.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckEnterKeyPress);
        }
    }
}
