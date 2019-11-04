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
        public Form1()
        {
            InitializeComponent();
            Vendég a = new Vendég("Sass-Gyarmati Norbert", "123456789", "3413. Cserépfalu xy út 00", 1);
            vendeglista.Add(a);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            
            
            
            List<Szobák> szoba = new List<Szobák>();
            for (int i = 0; i < 10; i++)
            {
                Szobák c = new Szobák(i, rnd.Next(1, 5), felszereltseg.KOMFORTOS);
                szoba.Add(c);
            }

            for (int i = 0; i < vendeglista.Count; i++)
            {
                comboBox1.Items.Add("név: " + vendeglista[i].Nev + " taj száma: " + vendeglista[i].Taj + " lakcíme: " + vendeglista[i].Lakcim + " kivett szoba: " + vendeglista[i].KivettSzoba);
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
