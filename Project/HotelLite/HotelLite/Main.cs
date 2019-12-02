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
            
            List<Person> quest = new List<Person>();
            tablaManager = new PersonTable();
            record_PersonLista = new List<Person>();
            bgWorker = new BackgroundWorker();


        }


        private void initdataGridView1()
        {
            

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
            login1.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            bgWorker.WorkerSupportsCancellation = true;

            bgWorker.DoWork += BgWorker_DoWork;
           
            bgWorker.RunWorkerCompleted += BgWorker_RunWorkerCompleted;



            //Mire megjelenik a form, szeretném ha bennelennének a dgv oszlopai
            button_view_Click(sender,e);
        }

        private void filldataGridView1()
        {
            //létrehozok egy segédváltozót amiben gyűjtöm a sorokat.
            DataGridViewRow[] rows = new DataGridViewRow[record_PersonLista.Count];

            //ciklussal bejárom a listát
            for (int i = 0; i < record_PersonLista.Count; i++)
            {
                //létrekell hozni egy egy sort
                DataGridViewRow row = new DataGridViewRow();

                //Egy egy sor cellákból épül fel. létrehozom ezeket is
                DataGridViewCell neptunCell = new DataGridViewTextBoxCell();
                //beállítom a cella értékét
                neptunCell.Value = record_PersonLista[i].Name;
                //A cellát a sorhoz adom

                row.Cells.Add(neptunCell);
                DataGridViewCell lastnameCell = new DataGridViewTextBoxCell();
                lastnameCell.Value = record_PersonLista[i].Name;
                row.Cells.Add(lastnameCell);


                DataGridViewCell firstNameCell = new DataGridViewTextBoxCell();
                firstNameCell.Value = record_PersonLista[i].BirthCity;
                row.Cells.Add(firstNameCell);


                //a kész sort a tömbhöz adom
                rows[i] = row;
            }

            dataGridView1.Rows.Clear();
            //A tömböt átadom a feltöltő metódusnak
            dataGridView1.Rows.AddRange(rows);
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
            //Feladata a DGW alaphelyzetbe állítása
            //Egy üres, oszlopokkal rendelkező táblaszerkezet kialakítása.

            //1.) üres legyen a dgv, azaz ne legyenek sorai és oszlopai.
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();

            //2.) oszlopok kialakítása: statikus típusként a DataGridViewColumn típust használjuk fel, amibe
            //a konkrét megjelenítési képességgel rendelkező oszlopot példányosítunk.
            DataGridViewColumn name = new DataGridViewTextBoxColumn();

            name.Name = "NAME"; //indexelve a dgv-t fogom elérni az oszlopot
            name.HeaderText = "Név"; //ez az oszlop fejléce

            //szélesség beállítása: dgv esetén használhatunk dinamikus méretezést, azonban ez költséges lehet.
            //ahol lehet kerüljük a költséges számításokat.

            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //ha nincs autosize mód, akkor be kell állítanunk a szélességet a width propertyben.
            //az oszlopot hozzáadom a dgv-hez
            dataGridView1.Columns.Add(name);


            
            DataGridViewColumn birthCity = new DataGridViewTextBoxColumn();
            birthCity.Name = "BIRTH_CITY";
            birthCity.HeaderText = "Születési h.";
            //a header + cellák szélességét dinamikusan vizsgálja, és ennek maximumát állítja be
            birthCity.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add(birthCity);

            DataGridViewColumn Szulid = new DataGridViewTextBoxColumn();
            Szulid.Name = "BIRTHDATE";
            Szulid.HeaderText = "SZülid";
            Szulid.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(Szulid);

            DataGridViewColumn TAX = new DataGridViewTextBoxColumn();
            TAX.Name = "TAX_NUMBER";
            TAX.HeaderText = "ADÓ";
            TAX.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(TAX);

            DataGridViewColumn SSN = new DataGridViewTextBoxColumn();
            SSN.Name = "SSN";
            SSN.HeaderText = "szem.ig.";
            SSN.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(SSN);

            DataGridViewColumn SEX = new DataGridViewTextBoxColumn();
            SEX.Name = "SEX";
            SEX.HeaderText = "Nem";
            SEX.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView1.Columns.Add(SEX);


        }
        void bgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            record_PersonLista = tablaManager.Select();
        }
        private void Main_Shown(object sender, EventArgs e)
        {
            
            bgWorker.RunWorkerAsync();
          
        }

        void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = string.Format("Hallgatók ({0} rekord)", record_PersonLista.Count);
            filldataGridView1();
        }

    }
}
