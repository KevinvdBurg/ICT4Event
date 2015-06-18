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
        protected OracleConnection Connection = new OracleConnection();

        /// <summary>
        /// The connection string.
        /// </summary>
        protected string ConnectionString = "DATA SOURCE=//ict4events.bb:1521/xe;PASSWORD=hallo;USER ID=hallo";

        /// <summary>
        /// The connect.
        /// </summary>
        /// <exception cref="Exception">
        /// Exception.
        /// </exception>
        public void Connect()
        {
            try
            {
                this.Connection = new OracleConnection();
                this.Connection.ConnectionString = this.ConnectionString;
                this.Connection.Open();
            }
            catch (Exception exp)
            {
                throw exp;
                this.Connection.Close();
            }
        }

        /// <summary>
        /// The dis connect.
        /// </summary>
        public void DisConnect()
        {
            this.Connection.Close();
        }
    }
}