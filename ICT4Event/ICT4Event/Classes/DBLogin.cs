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
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string LoginCheck(string email, string password)
        {
            var resultaat = "Geen Connectie";
            string sql;
            sql = "select * from gebruiker where emailadres = :email and wachtwoord = :password";

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("email", email));
                cmd.Parameters.Add(new OracleParameter("password", password));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    var geactiveerd = Convert.ToInt32(reader["geactiveerd"]);
                    if (geactiveerd == 0)
                    {
                        resultaat = "Activeer eerst uw account";
                    }
                    else
                    {
                        resultaat = "true";
                    }
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }
    }
}