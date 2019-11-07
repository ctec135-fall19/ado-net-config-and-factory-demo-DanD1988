using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;  // requires reference update
using System.Data.Common;
using System.Data.SqlClient;
using static System.Console;


namespace FactoryExample
{
    class Program
    {
        static void Main(string[] args)
        {
            #region get app config info
            string dataProvider = ConfigurationManager.AppSettings["provider"];
            WriteLine("   Provider: {0}", dataProvider);

            // alternate see p.833

            var cnStringBuilder = new SqlConnectionStringBuilder
            {
                InitialCatolog = "NorthWood",
                DataSource = (localdb)\mssqllocaldb,
                ConnectTimeout = 30,
                IntegerSecurity = true

            };

            WriteLine($"\tBuilt Connection String: + );
        }
        #endregion

        DbProviderFactories factory = DbProviderFactories.GetFactory(DataProvider);

        using (DbConnection connection = factory.CreateConnection()) 
        {
            if(ConnectionStringSettings == null) 
            {
                WriteLine("There was an issue creating connection");
                return;
            }
            else WriteLine("-> Connection Created");
               
            connection.ConnectionString = cnStringBuilder.ConnectionString;
            connection.Open();
            
            DbCommand myCommand = factory.CreateCommand();
            if(myCommand == null)
            {
                WriteLine("There is an issue");
                
            }
            else WriteLine($"Your command object is a " + $"");
            
            myCommand.Connection = connection;
            myCommand.CommandText = "Select * from Shippers";

            using (DbDataReader dataReader = myCommand.ExecuteReader())
            {
                while(dataReader.Read())
                {
                    WriteLine($"-> shipper # {dataReader["shipperId"]}" + $"is a {dataReader[2]}")
                }
            }

        }

        

    }
}
