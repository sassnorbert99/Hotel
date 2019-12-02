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
            command.CommandText = "SELECT name FROM GUEST ORDER BY last_name"; //parancs szövege

            OracleConnection connection = getOracleConnection(); //egy kapcsolatot kérek a metóduson keresztül
            connection.Open(); //kapcsolat megnyitása

            command.Connection = connection; //a parancs a nyitott DB kapcsolaton keresztül legyen végrehajtva

            OracleDataReader reader = command.ExecuteReader(); //ezzel tudja végrehajtani

            while (reader.Read()) //olvasom a rekordokat, amíg végéhez nem ér
            {
                //readeren soronként végig iterálok
                Person record = new Person();
                record.Name = reader["NAME"].ToString();
                record.Address = reader["ADDRESS"].ToString();
                record.BirthDate = reader["BIRTH_DATE"].ToString();
                record.SSN = reader["SSN"].ToString();
                record.Tin = reader["TAX_NUMBER"].ToString();
                record.BirthCity = reader["BIRTH_CITY"].ToString();


                 

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
            oracleCommand.CommandText = "DELETE FROM quest WHERE name = :name";
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

        /*
        public int Insert(StudentRecord record)
        {
            // adatbázis kapcsolat megszerzése
            OracleConnection oc = GetOracleConnection();
            oc.Open();

            OracleTransaction ot = oc.BeginTransaction(System.Data.IsolationLevel.ReadCommitted);

            OracleCommand oracleCommand = oc.CreateCommand(); // egy lépésben példányosít és odaadja a kapcsolatot
            oracleCommand.CommandType = System.Data.CommandType.StoredProcedure; // tárolt eljárást szeretnék hívni
            oracleCommand.CommandText = "spInsert_person";

            // paraméterek létrehozása
            OracleParameter neptunCodeParameter = new OracleParameter();
            neptunCodeParameter.DbType = System.Data.DbType.String;
            neptunCodeParameter.ParameterName = "p_name"; // név szerinti kötés van, fontos, hogy mi a neve
            neptunCodeParameter.Direction = System.Data.ParameterDirection.Input;
            neptunCodeParameter.Value = record.Name;
            oracleCommand.Parameters.Add(nameCodeParameter);

            OracleParameter addressParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_address",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Address
            };
            oracleCommand.Parameters.Add(addressParameter);

            OracleParameter tinParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_tax_in",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.TIN
            };
            oracleCommand.Parameters.Add(tinParameter);

            OracleParameter nationalityParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_nationality_in",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Nationality
            };
            oracleCommand.Parameters.Add(nationalityParameter);

            OracleParameter identityParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_identity_in",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Identity
            };
            oracleCommand.Parameters.Add(identityParameter);

            OracleParameter ssnParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_social_sn",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.SSN
            };
            oracleCommand.Parameters.Add(ssnParameter);

            OracleParameter birthDateParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Date,
                ParameterName = "p_birth_date",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.BirthDate
            };
            oracleCommand.Parameters.Add(birthDateParameter);

            OracleParameter birthCityParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_birth_city",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.BirthCity
            };
            oracleCommand.Parameters.Add(birthCityParameter);

            OracleParameter sexParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.String,
                ParameterName = "p_sex",
                Direction = System.Data.ParameterDirection.Input,
                Value = record.Sex
            };
            oracleCommand.Parameters.Add(sexParameter);

            OracleParameter rowCountParameter = new OracleParameter()
            {
                DbType = System.Data.DbType.Int32,
                ParameterName = "p_out_rowcnt",
                Direction = System.Data.ParameterDirection.Output, // kimenő paraméter
                // kifelé közvetít adatot
            };
            oracleCommand.Parameters.Add(rowCountParameter);

            try
            {
                oracleCommand.ExecuteNonQuery();
                int affectedRows = int.Parse(rowCountParameter.Value.ToString());

                ot.Commit();
                return affectedRows;
            }
            catch (Exception e)
            {
                ot.Rollback();
                return 0;
            }
        }
        */

    }
}
