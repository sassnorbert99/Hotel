using HotelLite.Tables;
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
    public partial class Main : Form
    {
        PersonTable tablaManager;
        List<Person> record_PersonLista;
        BackgroundWorker bgWorker;

        public Main()
        {
            InitializeComponent();
            this.Activate();
            List<Person> quest = new List<Person>();
            tablaManager = new PersonTable();
            record_PersonLista = new List<Person>();
            bgWorker = new BackgroundWorker();


        }

        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login1 = new Login();
            login1.Show();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bgWorker.WorkerSupportsCancellation = true;
            bgWorker.DoWork += BgWorker_DoWork;
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted; ;
        }

        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            record_PersonLista = tablaManager.Select();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            //Person a = new Person(nameTextBox.Text,);
        }

        private void button_view_Click(object sender, EventArgs e)
        {
            //nem biztos, hogy jó
            checkedListBoxReserved.Show();
        }
    }
}
