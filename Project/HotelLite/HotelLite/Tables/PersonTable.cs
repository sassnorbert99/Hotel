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
            string connectionString = @"Data Source=193.225.33.71;User Id=KBROMP;Password=1234;";

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
            command.CommandText = "SELECT neptun_code, first_name FROM students ORDER BY last_name"; //parancs szövege

            OracleConnection connection = getOracleConnection(); //egy kapcsolatot kérek a metóduson keresztül
            connection.Open(); //kapcsolat megnyitása

            command.Connection = connection; //a parancs a nyitott DB kapcsolaton keresztül legyen végrehajtva

            OracleDataReader reader = command.ExecuteReader(); //ezzel tudja végrehajtani

            while (reader.Read()) //olvasom a rekordokat, amíg végéhez nem ér
            {
                //readeren soronként végig iterálok
                Person record = new Person();
                record.Name = reader["name"].ToString();
                record.Address = reader["address"].ToString();
                record.BirthDate = reader["birth_date"].ToString();
                record.Identity = reader["identity"].ToString();
                record.Nationality = reader["nationality"].ToString();
                record.Tin = reader["tin"].ToString();

                records.Add(record);
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
            oracleCommand.CommandText = "DELETE FROM person WHERE name = :name";
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
            oracleCommand.CommandText = "UPDATE person WHERE name = :name";
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
    }
}
