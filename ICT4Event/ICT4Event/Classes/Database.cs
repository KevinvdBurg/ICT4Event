// --------------------------------------------------------------------------------------------------------------------
<<<<<<< HEAD
// <copyright file="Database.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
=======
// <copyright file="Database.cs" company="">
//   
>>>>>>> origin/Reserve
// </copyright>
// <summary>
//   The database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
<<<<<<< HEAD
namespace ICT4Event
{
    using System;
=======



namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
>>>>>>> origin/Reserve
    using System.Data.OracleClient;
    using System.Linq;
    using System.Web;

    /// <summary>
    /// The database.
    /// </summary>
<<<<<<< HEAD
    public abstract class Database
=======
    public class Database
>>>>>>> origin/Reserve
    {
        /// <summary>
        /// The connection.
        /// </summary>
<<<<<<< HEAD
        protected OracleConnection Connection = new OracleConnection();

        /// <summary>
        /// The connection string.
        /// </summary>
        protected string ConnectionString = "DATA SOURCE=//ict4events.bb:1521/xe;PASSWORD=hallo;USER ID=hallo";
=======
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
>>>>>>> origin/Reserve

        /// <summary>
        /// The connect.
        /// </summary>
        public void Connect()
        {
            try
            {
<<<<<<< HEAD
                this.Connection = new OracleConnection();
                this.Connection.ConnectionString = this.ConnectionString;
                this.Connection.Open();
=======
                this.connection = new OracleConnection();
                this.connection.ConnectionString = this.connectionString;
                this.connection.Open();
>>>>>>> origin/Reserve
            }
            catch (Exception exp)
            {
<<<<<<< HEAD
                throw exp;
                this.Connection.Close();
=======
                this.connection.Close();
>>>>>>> origin/Reserve
            }
        }

        /// <summary>
        /// The dis connect.
        /// </summary>
        public void DisConnect()
        {
<<<<<<< HEAD
            this.Connection.Close();
        }
=======
            this.connection.Close();
        } 
>>>>>>> origin/Reserve
    }
}