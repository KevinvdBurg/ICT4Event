using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class Database
    {
        protected OracleConnection connection = new OracleConnection();
        protected string connectionString = "DATA SOURCE=//ict4events.bb:1521/fhictora;PASSWORD=hallo;USER ID=hallo";

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