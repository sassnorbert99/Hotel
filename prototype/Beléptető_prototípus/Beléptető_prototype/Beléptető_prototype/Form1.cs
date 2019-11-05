using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Beléptető_prototype
{
    public partial class Form1 : Form
    {
        public List<Users> Users_list = new List<Users>();
        private string licence = "2D78-65JH-KHGF-78FV";
        
        public Form1()
        {
            InitializeComponent();
            Users a = new Users("a", "1");
            
            Users_list.Add(a);
            
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            String Username;
            string Password;
            bool success = false;
            Username = textBox1.Text;
            Password = textBox2.Text;
            MessageBox mb;
            if (Username == "" || Password == "")
            {
                MessageBox.Show("Felhasználónév és jelszó megadása kötelező!");
            }
            else
            {


                foreach (Users item in Users_list)
                {
                    if (item.Username == Username && item.Password == Password)
                    {
                        success = true;
                    }
                }

                if (success)
                {
                    MessageBox.Show("Sikeres bejelentkezés!");
                    Process.Start(@"C:\Users\O.Zsolt\Desktop\Hotel\prototype\Hotel_prototype\Hotel_prototype\bin\Debug\Hotel_prototype.exe");
                    Application.Exit();
                }

                else
                {
                    MessageBox.Show("Sikertelen bejelentkezés!");
                    textBox1.Clear();
                    textBox2.Clear();
                }
            }
        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBox_termekkulcs.Text!=licence)
            {
                MessageBox.Show("Hibás termékkulcs!");
                textBox_termekkulcs.Clear();
                textBox_felhasznalo.Clear();
                textBox_jelszo.Clear();
            }
            else
            {
                if (textBox_felhasznalo.Text=="" || textBox_jelszo.Text=="")
                {
                    MessageBox.Show("A jelszót és a felhasználó nevet kötelező megadni!");
                    textBox_termekkulcs.Clear();
                    textBox_felhasznalo.Clear();
                    textBox_jelszo.Clear();
                }
                else
                {
                    Users_list.Add(new Users(textBox_felhasznalo.Text,textBox_jelszo.Text));
                    MessageBox.Show("Sikeres regisztráció!");
                    textBox_termekkulcs.Clear();
                    textBox_felhasznalo.Clear();
                    textBox_jelszo.Clear();
                    panel2.Visible = false;
                }
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }
    }
}
