// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBAccount.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The db account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Data.OracleClient;

    /// <summary>
    ///     The db account.
    /// </summary>
    public class DbAccount : Database
    {
        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Insert(Account account)
        {
            var resultaat = false;
            var geactiveerd = 0;

            // string sql = "INSERT INTO GEBRUIKER(RFID, EMAILADRES, WACHTWOORD, PLAATS, POSTCODE, HUISNUMMER, ISADMIN, VOORNAAM, ACHTERNAAM) VALUES (:RFID, :emailadres, :wachtwoord, :plaats, :postcode, :huisnummer, :isadmin, :voornaam, :achternaam)";
            var sql =
                "INSERT INTO ACCOUNT(\"gebruikersnaam\", \"email\", \"activatiehash\") VALUES(:gebruikersnaam, :email, :activatiehash)";

            if (account.Geactiveerd)
            {
                geactiveerd = 1;
            }

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("gebruikersnaam", account.Gebruiksersnaam));
                cmd.Parameters.Add(new OracleParameter("email", account.Email));
                cmd.Parameters.Add(new OracleParameter("activatiehash", account.Hash));
                cmd.ExecuteNonQuery();

                // OracleDataReader reader = cmd.ExecuteReader();
                resultaat = true;
            }
            catch (OracleException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// The select.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>.
        /// </returns>
        public Account Select(string username)
        {
            Account resultaat = null;
            var sql =
                "select \"ID\", \"gebruikersnaam\", \"email\" from account where \"gebruikersnaam\" = :gebruikersnaam";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("gebruikersnaam", username));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var returnedAccount = new Account(
                            Convert.ToInt32(reader["ID"]), 
                            Convert.ToString(reader["gebruikersnaam"]), 
                            Convert.ToString(reader["email"]));
                        resultaat = returnedAccount;
                    }
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// The select gebruikersnaam.
        /// </summary>
        /// <param name="gebruikersnaam">
        /// The gebruikersnaam.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SelectGebruikersnaam(string gebruikersnaam)
        {
            var resultaat = false;
            int count;
            var sql = "select \"gebruikersnaam\" as aantal from account where \"gebruikersnaam\" = :gebruikersnaam";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("gebruikersnaam", gebruikersnaam));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    resultaat = true;
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="gebruikersnaam">
        /// The gebruikersnaam.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Update(string gebruikersnaam, string email)
        {
            return true;
        }

        /// <summary>
        /// The select email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool SelectEmail(string email)
        {
            var resultaat = false;
            var sql = "select \"email\" as aantal from account where \"email\" = :email";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("email", email));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    resultaat = true;
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// The activate account.
        /// </summary>
        /// <param name="hash">
        /// The hash.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ActivateAccount(string hash)
        {
            var resultaat = false;
            var sql = "Update ACCOUNT SET \"geactiveerd\" = 1 WHERE \"activatiehash\" = :hash ";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("hash", hash));
                cmd.ExecuteNonQuery();
                resultaat = true;
            }
            catch (OracleException e)
            {
                Console.WriteLine("Activatie code niet gevonden: " + e.Message);
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }

        /// <summary>
        /// The update user account.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool UpdateUserAccount(int id, string email)
        {
            var resultaat = false;
            var sql = "UPDATE ACCOUNT SET \"email\"=:email WHERE \"ID\" = :id";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("id", id));
                cmd.Parameters.Add(new OracleParameter("email", email));
                cmd.ExecuteNonQuery();
                resultaat = true;
            }
            catch (OracleException e)
            {
                Console.WriteLine("Account niet gevonden: " + e.Message);
            }
            finally
            {
                this.DisConnect();
            }

            return resultaat;
        }
    }
}