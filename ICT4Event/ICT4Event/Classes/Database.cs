// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" company="">
//   
// </copyright>
// <summary>
//   The database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Data.OracleClient;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The database.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The connection.
        /// </summary>
        protected OracleConnection connection = new OracleConnection();

        /// <summary>
        /// The connection string.
        /// </summary>
        protected string connectionString = "DATA SOURCE=//ict4events.bb:1521;PASSWORD=hallo;USER ID=hallo";

        /// <summary>
        /// Initializes a new instance of the <see cref="Database"/> class.
        /// </summary>
        public Database()
        {

        }

        /// <summary>
        /// The connect.
        /// </summary>
        public void Connect()
        {
            try
            {
                this.connection = new OracleConnection();
                this.connection.ConnectionString = this.connectionString;
                this.connection.Open();
            }
            catch
            {
                this.connection.Close();
            }
        }

        /// <summary>
        /// The dis connect.
        /// </summary>
        public void DisConnect()
        {
            this.connection.Close();
        } 
    }
}