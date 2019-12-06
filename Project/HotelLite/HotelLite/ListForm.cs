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
    public partial class ListForm : Form
    {
        private PersonTable manager_studentsTable;
        private List<Person> records_studentsList;
        private BackgroundWorker bgWorker_studentsList; // bg worker a lekérdezéshez
        private List<int> szobak = new List<int>() { 1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20};

        public ListForm()
        {
            InitializeComponent();
            Login login = new Login();
            
            manager_studentsTable = new PersonTable();
            // loadRecords(); javaslat 1: rossz, mivel kifagyasztja a programot 

            bgWorker_studentsList = new BackgroundWorker();
        }

        private void initDataGridView_students()
        {
            //Feladata a DGW alaphelyzetbe állítása
            //Egy üres, oszlopokkal rendelkező táblaszerkezet kialakítása.

            //1.) üres legyen a dgv, azaz ne legyenek sorai és oszlopai.
            dataGridView_students.Rows.Clear();
            dataGridView_students.Columns.Clear();


            DataGridViewColumn id = new DataGridViewTextBoxColumn();
            id.Name = "id";
            id.HeaderText = "Id";
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(id);

            DataGridViewColumn RoomColumn = new DataGridViewTextBoxColumn();
            RoomColumn.Name = "room";
            RoomColumn.HeaderText = "Szoba";
            RoomColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(RoomColumn);

            //2.) oszlopok kialakítása: statikus típusként a DataGridViewColumn típust használjuk fel, amibe
            //a konkrét megjelenítési képességgel rendelkező oszlopot példányosítunk.
            DataGridViewColumn NameColumn = new DataGridViewTextBoxColumn();

            NameColumn.Name = "Name"; //indexelve a dgv-t fogom elérni az oszlopot
            NameColumn.HeaderText = "Név"; //ez az oszlop fejléce

            //szélesség beállítása: dgv esetén használhatunk dinamikus méretezést, azonban ez költséges lehet.
            //ahol lehet kerüljük a költséges számításokat.

            NameColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;

            //ha nincs autosize mód, akkor be kell állítanunk a szélességet a width propertyben.
            //az oszlopot hozzáadom a dgv-hez
            dataGridView_students.Columns.Add(NameColumn);



            DataGridViewColumn BirthCityColumn = new DataGridViewTextBoxColumn();
            BirthCityColumn.Name = "birthCity";
            BirthCityColumn.HeaderText = "Szül.Hely";
            //a header + cellák szélességét dinamikusan vizsgálja, és ennek maximumát állítja be
            BirthCityColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView_students.Columns.Add(BirthCityColumn);

            DataGridViewColumn BirthDateColumn = new DataGridViewTextBoxColumn();
            BirthDateColumn.Name = "birthDate";
            BirthDateColumn.HeaderText = "Szül.idő";
            BirthDateColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(BirthDateColumn);

            DataGridViewColumn TaxColumn = new DataGridViewTextBoxColumn();
            TaxColumn.Name = "TAX";
            TaxColumn.HeaderText = "Adó";
            TaxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(TaxColumn);

            DataGridViewColumn SSNColumn = new DataGridViewTextBoxColumn();
            SSNColumn.Name = "SSN";
            SSNColumn.HeaderText = "SZemély.ig.";
            SSNColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(SSNColumn);

            DataGridViewColumn AddressColumn = new DataGridViewTextBoxColumn();
            AddressColumn.Name = "Address";
            AddressColumn.HeaderText = "Cím";
            AddressColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(AddressColumn);

            DataGridViewColumn SexColumn = new DataGridViewTextBoxColumn();
            SexColumn.Name = "sex";
            SexColumn.HeaderText = "Nem";
            SexColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(SexColumn);

            DataGridViewColumn check_in = new DataGridViewTextBoxColumn();
            check_in.Name = "Check_in";
            check_in.HeaderText = "Érkezés";
            check_in.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(check_in);

            DataGridViewColumn check_out = new DataGridViewTextBoxColumn();
            check_out.Name = "Check_out";
            check_out.HeaderText = "Távozás";
            check_out.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            dataGridView_students.Columns.Add(check_out);




        }


        
        // a form egészen bizosan meg fog jelenni (valaki meghívta a Show/ShowDialog metódusát*/
        // az első megjelenítés előtt, még a Form megjelenítése előtt lefut
        private void ListForm_Load(object sender, EventArgs e)
        {

            Login login = new Login();
            login.Hide();
            login.Close();
            // loadRecords(); javaslat 2: továbbra is kifagy 

            // feliratkozom a bgWorker megfelelő eseményeire, beállítom az alap tulj. 
            /*
             *  Amennyiben a háttérszálon megkezedődött egy feladat végrehajtása, 
             *  akkor az megszakítható-e. 
             *  
             *   IsBusy property: végrehajtás van-e a szálon éppen 
             *    if(bgWorker_studentsList.IsBusy)
                    {
                        bgWorker_studentsList.CancelAsync();
                        // a feladat befejezése aszinkront módon 
                    }
             */
            bgWorker_studentsList.WorkerSupportsCancellation = true;
            // a hattérben végrehajtandó feladat leírása 
            bgWorker_studentsList.DoWork += bgWorker_studentsList_DoWork;
            // mi történjen a háttérbeli szál végrehajtása után
            bgWorker_studentsList.RunWorkerCompleted += bgWorker_studentsList_RunWorkerCompleted;



            //Mire megjelenik a form, szeretném ha bennelennének a dgv oszlopai
            initDataGridView_students();

        }


        private void filldataGridView_students2()
        {
            //létrehozok egy segédváltozót amiben gyűjtöm a sorokat.
            DataGridViewRow[] rows = new DataGridViewRow[records_studentsList.Count];

            //ciklussal bejárom a listát
            for (int i = 0; i < records_studentsList.Count; i++)
            {


                


                //létrekell hozni egy egy sort
                DataGridViewRow row = new DataGridViewRow();

                DataGridViewCell ID = new DataGridViewTextBoxCell();
                ID.Value = records_studentsList[i].Id;
                row.Cells.Add(ID);

                DataGridViewCell Room = new DataGridViewTextBoxCell();
                Room.Value = records_studentsList[i].Room;
                row.Cells.Add(Room);

                //Egy egy sor cellákból épül fel. létrehozom ezeket is
                DataGridViewCell NameCell = new DataGridViewTextBoxCell();
                //beállítom a cella értékét
                NameCell.Value = records_studentsList[i].Name;
                //A cellát a sorhoz adom

                row.Cells.Add(NameCell);

                

                DataGridViewCell BirthCity = new DataGridViewTextBoxCell();
                BirthCity.Value = records_studentsList[i].BirthCity;
                row.Cells.Add(BirthCity);

                DataGridViewCell BirthDate = new DataGridViewTextBoxCell();
                BirthDate.Value = records_studentsList[i].BirthDate;
                row.Cells.Add(BirthDate);


                DataGridViewCell Tax = new DataGridViewTextBoxCell();
                Tax.Value = records_studentsList[i].Tin;
                row.Cells.Add(Tax);

                DataGridViewCell SSN = new DataGridViewTextBoxCell();
                SSN.Value = records_studentsList[i].SSN;
                row.Cells.Add(SSN);

                DataGridViewCell ADDRESS = new DataGridViewTextBoxCell();
                ADDRESS.Value = records_studentsList[i].Address;
                row.Cells.Add(ADDRESS);

                DataGridViewCell Sex = new DataGridViewTextBoxCell();
                Sex.Value = records_studentsList[i].Sex;
                row.Cells.Add(Sex);

                DataGridViewCell Check_in = new DataGridViewTextBoxCell();
                Check_in.Value = records_studentsList[i].Check_IN;
                row.Cells.Add(Check_in);

                DataGridViewCell Check_out = new DataGridViewTextBoxCell();
                Check_out.Value = records_studentsList[i].Check_OUT;
                row.Cells.Add(Check_out);
                /*
                DataGridViewCell firstNameCell = new DataGridViewTextBoxCell();
                firstNameCell.Value = records_studentsList[i].FirstName;
                row.Cells.Add(firstNameCell);*/


                //a kész sort a tömbhöz adom
                rows[i] = row;
            }

            dataGridView_students.Rows.Clear();
            //A tömböt átadom a feltöltő metódusnak
            dataGridView_students.Rows.AddRange(rows);
            listBox_rooms.Items.Clear();
           
            fillList();
        }


        void fillList()
        {
            
            for (int i = 0; i < szobak.Count; i++)
            {
                bool contain = false;
                foreach (Person student in records_studentsList)
                {
                    if (szobak[i]==student.Room)
                    {
                        contain = true;
                    }
                }
                if (!contain)
                {
                    listBox_rooms.Items.Add(szobak[i]);
                }
            }
        }

        /*
         * A DoWork befejeződése után, a főszálon kerül végrehajtásra. 
         */
        void bgWorker_studentsList_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Text = string.Format("Hallgatók ({0} rekord)", records_studentsList.Count);
            filldataGridView_students2();
        }

        // háttérben kerül végrehajtásra
        void bgWorker_studentsList_DoWork(object sender, DoWorkEventArgs e)
        {
            records_studentsList = manager_studentsTable.Select();
        }

        private void ListForm_Shown(object sender, EventArgs e)
        {
            // loadRecords(); javaslat 3: továbbra is kifagy 
            /* DE HA EBBEN A BLOKKBAN EGY MÁSIK SZÁLON LE TUDOM 
             * KÉRDEZNI A REKORDOKAT, AKKOR ARRA JÓ LESZ, HOGY 
             * INNEN HÍVJAM MEG
             * 
             */

            // javaslat 4: nem jó, mivel egy másik szálról 
            // nem férek hozzá a főszálon létrehozott elemekhez 
            /*Thread thread = new Thread(loadRecords);
            thread.Start();*/

            // loadRecords();

            // bgWorker hívása 
            bgWorker_studentsList.RunWorkerAsync();
            // 1) háttérszálon: DoWork()
            // 2) főszálon: RunWorkerCompleted()
        }

        private void ButtonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonLogout_Click(object sender, EventArgs e)
        {
            
            
        }

        private void Button_Delete_Click(object sender, EventArgs e)
        {
            Person dperson = new Person();
            foreach (Person person in records_studentsList)
            {
                if (int.Parse(textBox_ID.Text)==person.Id)
                {
                    dperson = person;
                }
            }

                manager_studentsTable.Delete(dperson);
            manager_studentsTable = new PersonTable();

            Button_view_Click(sender, e);

        }

        private void Button_insert_Click(object sender, EventArgs e)
        {
            Person person = new Person("Zsolti", "2132213", "4651", "fsdf", "1997-10-12", "St", "F", "2019-05-05", "2020-05-05", 4);
            manager_studentsTable.Insert(person);
            Button_view_Click(sender, e);
        }

        private void Button_view_Click(object sender, EventArgs e)
        {
            manager_studentsTable = new PersonTable();
            // loadRecords(); javaslat 1: rossz, mivel kifagyasztja a programot 

            bgWorker_studentsList = new BackgroundWorker();
            ListForm_Load(sender, e);
          
            
            filldataGridView_students2();
            ListForm_Shown(sender,e);
            
        }
    }
}
