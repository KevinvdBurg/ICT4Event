using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Database
    {
        protected OracleConnection connection = new OracleConnection();
        protected string connectionString = "DATA SOURCE=//192.168.15.50:1521/fhictora;PASSWORD=XAWdDJtZWV;USER ID=dbi314159";
        protected string connectionString2 = "Data Source=localhost:1521/xe; PASSWORD=hallo;USER ID =bryan";


        public Database()
        {

        }

        public void Connect()
        {
            try
            {
                connection = new OracleConnection();
                connection.ConnectionString = connectionString;
                connection.Open();
            }
            catch
            {
                connection.Close();
            }
        }

        public void DisConnect()
        {
            connection.Close();
        }
    

    
    }
}