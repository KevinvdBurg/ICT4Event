// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Database.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The database.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Data.OracleClient;

    /// <summary>
    /// The database.
    /// </summary>
    public class Database
    {
        /// <summary>
        /// The connection.
        /// </summary>
<<<<<<< HEAD
        protected OracleConnection Connection = new OracleConnection();
=======
        protected OracleConnection connection = new OracleConnection();
>>>>>>> origin/Event-aanmaken

        /// <summary>
        /// The connection string.
        /// </summary>
<<<<<<< HEAD
        protected string ConnectionString = "DATA SOURCE=//ict4events.bb:1521/xe;PASSWORD=hallo;USER ID=hallo";
=======
        protected string connectionString = "DATA SOURCE=//ict4events.bb:1521;PASSWORD=hallo;USER ID=hallo";
>>>>>>> origin/Event-aanmaken

        /// <summary>
        /// The connect.
        /// </summary>
<<<<<<< HEAD
        /// <exception cref="Exception">
        /// Exception.
        /// </exception>
=======
>>>>>>> origin/Event-aanmaken
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
>>>>>>> origin/Event-aanmaken
            }
            catch (Exception exp)
            {
<<<<<<< HEAD
                throw exp;
                this.Connection.Close();
=======
                this.connection.Close();
>>>>>>> origin/Event-aanmaken
            }
        }

        /// <summary>
        /// The dis connect.
        /// </summary>
        public void DisConnect()
        {
<<<<<<< HEAD
            this.Connection.Close();
=======
            this.connection.Close();
>>>>>>> origin/Event-aanmaken
        }
    }
}