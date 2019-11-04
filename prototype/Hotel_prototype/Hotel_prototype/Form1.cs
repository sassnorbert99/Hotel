using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_prototype
{
    public partial class Form1 : Form
    {
        List<Vendég> vendeglista = new List<Vendég>();
        List<Szobák> szoba = new List<Szobák>();
        public Form1()
        {
            InitializeComponent();
            Vendég a = new Vendég("Sass-Gyarmati Norbert", "123456789", "3413. Cserépfalu xy út 00", 1);
            vendeglista.Add(a);
            Random rnd = new Random();
            for (int i = 0; i < 10; i++)
            {
                Szobák c = new Szobák(i, rnd.Next(1, 5), felszereltseg.KOMFORTOS);
                szoba.Add(c);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            








        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();
            Vendég a = new Vendég(nevbox.Text, tajbox.Text, lakbox.Text, int.Parse(szobabox.Text));
            vendeglista.Add(a);
            for (int i = 0; i < vendeglista.Count; i++)
            {
                comboBox1.Items.Add("név: " + vendeglista[i].Nev + " taj száma: " + vendeglista[i].Taj + " lakcíme: " + vendeglista[i].Lakcim + " kivett szoba: " + vendeglista[i].KivettSzoba);
            }
            for (int i = 0; i < szoba.Count; i++)
            {
                comboBox2.Items.Add("szobaszám: " + szoba[i].Szoba + " ágyak száma: " + szoba[i].Agyszam + " felszererltsége: " + szoba[i].Felszereles);
            }
            for (int i = 0; i < vendeglista.Count; i++)
            {
                if (vendeglista[i].KivettSzoba != szoba[i].Szoba)
                {
                    comboBox3.Items.Add("kivett szoba tulajdonosa: " + vendeglista[i].Nev + "kivett szoba címe: " + vendeglista[i].KivettSzoba);
                    comboBox2.Items.Remove(vendeglista[i].KivettSzoba);
                }
            }
            nevbox.Clear();
            lakbox.Clear();
            tajbox.Clear();
            szobabox.Clear();
        }
    }
}
