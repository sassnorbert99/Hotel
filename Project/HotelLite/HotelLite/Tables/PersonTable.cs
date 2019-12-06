using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;



namespace HotelLite.Tables
{
    class PersonTable
    {
        private OracleConnection getOracleConnection()
        {
            //létrehozok egy új oracleconnection példányt
            OracleConnection oc = new OracleConnection();

            //beállítom a kapcsolat tulajdonságait
            string connectionString = @"Data Source=193.225.33.71;User Id=JIQ9DC;Password=aA123456;";

            oc.ConnectionString = connectionString;
            return oc;
        }





        public List<Person> Select()
        {
            //lista létrehozása a lekérdezett elemeknek
            List<Person> records = new List<Person>();

            //SQL parancs kiadása: OracleCommand

            OracleCommand command = new OracleCommand();
            command.CommandType = System.Data.CommandType.Text; //SQL utasítás: szöveges
            command.CommandText = "SELECT * FROM GUEST ORDER BY NAME"; //parancs szövege

            OracleConnection connection = getOracleConnection(); //egy kapcsolatot kérek a metóduson keresztül
            connection.Open(); //kapcsolat megnyitása

            command.Connection = connection; //a parancs a nyitott DB kapcsolaton keresztül legyen végrehajtva

            OracleDataReader reader = command.ExecuteReader(); //ezzel tudja végrehajtani

            while (reader.Read()) //olvasom a rekordokat, amíg végéhez nem ér
            {
                //readeren soronként végig iterálok
                Person record = new Person();
                record.Id = int.Parse(reader["ID"].ToString());
                record.Name = reader["NAME"].ToString();
                record.Address = reader["ADDRESS"].ToString();
                record.BirthDate = reader["BIRTH_DATE"].ToString().Substring(0,13);
                record.SSN = reader["SSN"].ToString();
                record.Tin = reader["TAX_NUMBER"].ToString();
                record.BirthCity = reader["BIRTH_CITY"].ToString();
                record.Sex = reader["SEX"].ToString();
                record.Room = int.Parse(reader["ROOM"].ToString());
                record.Check_IN = reader["CHECK_IN"].ToString().Substring(0, 13);
                record.Check_OUT = reader["CHECK_OUT"].ToString().Substring(0, 13);




                records.Add(record);

                //Person a = new Person()
                //{
                //    Name = reader["name"].ToString(),
                //    Address = reader["address"].ToString(),
                //    BirthDate = reader["birth_date"].ToString(),
                //    Identity = reader["identity"].ToString(),
                //    Nationality = reader["nationality"].ToString(),
                //    Tin = reader["tin"].ToString()
                //};
            }
            connection.Close();
            return records;
        }





        public int Delete(Person record)
        {
            //kérek egy adatbázis kapcsolatot
            OracleConnection oracleConnection = getOracleConnection();
            oracleConnection.Open();
            //mivel dml művelet lesz, létrehozok egy lokális tranzakciót, melyet a végén commit-olok
            OracleTransaction oracleTransaction = oracleConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.CommandType = System.Data.CommandType.Text;
            oracleCommand.CommandText = "DELETE FROM GUEST WHERE ID = :ID";
            //:neptuncode= dinamikus paraméter
            OracleParameter nameParameter = new OracleParameter();
            nameParameter.DbType = System.Data.DbType.String;
            nameParameter.ParameterName = ":ID";
            nameParameter.Direction = System.Data.ParameterDirection.Input;
            nameParameter.Value = record.Id;
            oracleCommand.Parameters.Add(nameParameter);
            //odaadjuk a parancsnak a kapcsolatot
            oracleCommand.Connection = oracleConnection;
            //odaadjuk a tranzakciót is
            oracleCommand.Transaction = oracleTransaction;

            int affectedRows = 0;
            try
            {
                affectedRows = oracleCommand.ExecuteNonQuery(); //futtatom a delete-t
                oracleTransaction.Commit();
            }
            catch (Exception e)
            {
                oracleTransaction.Rollback(); //ha gond van, visszapörgetem
                //semmissé teszem a tranzakcióban végzett műveletet
            }
            return affectedRows;
        }





        public int Update(Person record)
        {
            //kérek egy adatbázis kapcsolatot
            OracleConnection oracleConnection = getOracleConnection();
            oracleConnection.Open();
            //mivel dml művelet lesz, létrehozok egy lokális tranzakciót, melyet a végén commit-olok
            OracleTransaction oracleTransaction = oracleConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            OracleCommand oracleCommand = new OracleCommand();
            oracleCommand.CommandType = System.Data.CommandType.Text;
            oracleCommand.CommandText = "UPDATE quest WHERE name = :name";
            //:neptuncode= dinamikus paraméter
            OracleParameter nameParameter = new OracleParameter();
            nameParameter.DbType = System.Data.DbType.String;
            nameParameter.ParameterName = ":name";
            nameParameter.Direction = System.Data.ParameterDirection.Input;
            nameParameter.Value = record.Name;
            oracleCommand.Parameters.Add(nameParameter);
            //odaadjuk a parancsnak a kapcsolatot
            oracleCommand.Connection = oracleConnection;
            //odaadjuk a tranzakciót is
            oracleCommand.Transaction = oracleTransaction;

            int affectedRows = 0;
            try
            {
                affectedRows = oracleCommand.ExecuteNonQuery(); //futtatom a update-t
                oracleTransaction.Commit();
            }
            catch (Exception e)
            {
                oracleTransaction.Rollback(); //ha gond van, visszapörgetem
                //semmissé teszem a tranzakcióban végzett műveletet
            }
            return affectedRows;
        }

        
        public int Insert(Person record)
        {
            //kérek egy adatbázis kapcsolatot
            OracleConnection oracleConnection = getOracleConnection();
            oracleConnection.Open();
            //mivel dml művelet lesz, létrehozok egy lokális tranzakciót, melyet a végén commit-olok
            OracleTransaction oracleTransaction = oracleConnection.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);
            OracleCommand command = new OracleCommand();
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = "Insert into GUEST(NAME,BIRTH_DATE,BIRTH_CITY,TAX_NUMBER,SSN,ADDRESS,SEX,ROOM,CHECK_IN,CHECK_OUT) values(:NAME,:BIRTHD , :BIRTH_CITY, :TAX, :SSN,:ADDR,:SEX,:ROOM,:CHECK_IN,:CHECK_OUT)";
            ////:neptuncode= dinamikus paraméter
            //OracleParameter nameParameter = new OracleParameter();
            //nameParameter.DbType = System.Data.DbType.String;
            //nameParameter.ParameterName = ":NAME";
            //nameParameter.Direction = System.Data.ParameterDirection.Input;
            //nameParameter.Value = record.Name;
            //command.Parameters.Add(nameParameter);

            //OracleParameter birth_date = new OracleParameter();
            //birth_date.DbType = System.Data.DbType.String;
            //birth_date.ParameterName = ":BIRTHD";
            //birth_date.Direction = System.Data.ParameterDirection.Input;
            //birth_date.Value = record.BirthDate;
            //command.Parameters.Add(birth_date);


            //OracleParameter birth_city = new OracleParameter();
            //birth_city.DbType = System.Data.DbType.String;
            //birth_city.ParameterName = ":BIRTH_CITY";
            //birth_city.Direction = System.Data.ParameterDirection.Input;
            //birth_city.Value = record.BirthCity;
            //command.Parameters.Add(birth_city);

            //OracleParameter tax = new OracleParameter();
            //tax.DbType = System.Data.DbType.String;
            //tax.ParameterName = ":TAX";
            //tax.Direction = System.Data.ParameterDirection.Input;
            //tax.Value = int.Parse(record.Tin);
            //command.Parameters.Add(tax);


            //OracleParameter ssn = new OracleParameter();
            //ssn.DbType = System.Data.DbType.String;
            //ssn.ParameterName = ":SSN";
            //ssn.Direction = System.Data.ParameterDirection.Input;
            //ssn.Value = record.SSN;
            //command.Parameters.Add(ssn);

            //OracleParameter addr = new OracleParameter();
            //addr.DbType = System.Data.DbType.String;
            //addr.ParameterName = ":ADDR";
            //addr.Direction = System.Data.ParameterDirection.Input;
            //addr.Value = record.Address;
            //command.Parameters.Add(addr);


            //OracleParameter sex = new OracleParameter();
            //sex.DbType = System.Data.DbType.String;
            //sex.ParameterName = ":SEX";
            //sex.Direction = System.Data.ParameterDirection.Input;
            //sex.Value = Convert.ToChar(record.Sex);
            //command.Parameters.Add(sex);

            //OracleParameter room = new OracleParameter();
            //room.DbType = System.Data.DbType.String;
            //room.ParameterName = ":ROOM";
            //room.Direction = System.Data.ParameterDirection.Input;
            //room.Value = record.Room;
            //command.Parameters.Add(room);


            //OracleParameter check_in = new OracleParameter();
            //check_in.DbType = System.Data.DbType.String;
            //check_in.ParameterName = ":CHECK_IN";
            //check_in.Direction = System.Data.ParameterDirection.Input;
            //check_in.Value = record.Check_IN;
            //command.Parameters.Add(check_in);

            //OracleParameter check_out = new OracleParameter();
            //check_out.DbType = System.Data.DbType.String;
            //check_out.ParameterName = ":CHECK_OUT";
            //check_out.Direction = System.Data.ParameterDirection.Input;
            //check_out.Value = record.Check_OUT;
            //command.Parameters.Add(check_out);

            //odaadjuk a parancsnak a kapcsolatot
            command.Connection = oracleConnection;
            //odaadjuk a tranzakciót is
            command.Transaction = oracleTransaction;

            command.Parameters.Add(new OracleParameter(":NAME", "Zsolti"));
            command.Parameters.Add(new OracleParameter(":BIRTHD", OracleDbType.Date)).Value=DateTime.Now;
            command.Parameters.Add(new OracleParameter(":BIRTH_CITY", "Eger"));
            command.Parameters.Add(new OracleParameter(":TAX", 655695));
            command.Parameters.Add(new OracleParameter(":SSN", "541355"));
            command.Parameters.Add(new OracleParameter(":ADDR", "fdsdfsd"));
            command.Parameters.Add(new OracleParameter(":SEX", Char.Parse("F")));
            command.Parameters.Add(new OracleParameter(":ROOM", 1));
            command.Parameters.Add(new OracleParameter(":CHECK_IN", OracleDbType.Date)).Value= DateTime.Now;
            command.Parameters.Add(new OracleParameter(":CHECK_OUT", OracleDbType.Date)).Value= DateTime.Now;

            int affectedRows = 0;
            try
            {
                affectedRows = command.ExecuteNonQuery(); //futtatom a delete-t
                oracleTransaction.Commit();
            }
            catch (Exception e)
            {
                oracleTransaction.Rollback(); //ha gond van, visszapörgetem
                //semmissé teszem a tranzakcióban végzett műveletet
            }
            return affectedRows;
        }
        

    }
}
