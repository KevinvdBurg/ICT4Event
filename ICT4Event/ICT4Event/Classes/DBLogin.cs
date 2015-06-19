// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBLogin.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The db login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Data.OracleClient;

    /// <summary>
    /// The db login.
    /// </summary>
    public class DbLogin : Database
    {
        /// <summary>
        /// The login check.
        /// </summary>
        /// <param name="username">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public bool LoginActivatieCheck(string username)
        {
            bool resultaat = false;
            string sql;
            sql = "select * from ACCOUNT where \"gebruikersnaam\" = :username";

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("username", username));
                var reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int geactiveerd = Convert.ToInt32(reader["geactiveerd"]);
                        if (geactiveerd != 0)
                        {
                            resultaat = true;
                        }
                    }
                }
            }
            catch (OracleException e)
            {
                throw e;
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }
    }
}