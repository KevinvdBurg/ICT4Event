// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBAccount.cs" company="">
//   
// </copyright>
// <summary>
//   The db account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;
    using System.Text.RegularExpressions;

    /// <summary>
    /// The db account.
    /// </summary>
    public class DBAccount : Database
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DBAccount"/> class.
        /// </summary>
        public DBAccount()
        {
        }

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
            bool resultaat = false;
            int geactiveerd = 0;

            // string sql = "INSERT INTO GEBRUIKER(RFID, EMAILADRES, WACHTWOORD, PLAATS, POSTCODE, HUISNUMMER, ISADMIN, VOORNAAM, ACHTERNAAM) VALUES (:RFID, :emailadres, :wachtwoord, :plaats, :postcode, :huisnummer, :isadmin, :voornaam, :achternaam)";
            string sql =
                "INSERT INTO ACCOUNT(\"gebruikersnaam\", \"email\", \"activatiehash\") VALUES(:gebruikersnaam, :email, :activatiehash)";

            if (account.Geactiveerd)
            {
                geactiveerd = 1;
            }

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
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
                DisConnect();
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
            string sql =
                "select \"id\", \"gebruikersnaam\", \"email\" as aantal from account where \"gebruikersnaam\" = :gebruikersnaam";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("gebruikersnaam", username));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    Account returnedAccount = new Account(
                        Convert.ToInt32(reader["id"]), 
                        Convert.ToString(reader["gebruikersnaam"]), 
                        Convert.ToString(reader["email"]));
                    resultaat = returnedAccount;
                }
            }
            catch (OracleException e)
            {
                throw;
            }
            finally
            {
                DisConnect();
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
            bool resultaat = false;
            int count;
            string sql = "select \"gebruikersnaam\" as aantal from account where \"gebruikersnaam\" = :gebruikersnaam";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("gebruikersnaam", gebruikersnaam));
                OracleDataReader reader = cmd.ExecuteReader();
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
                DisConnect();
            }

            return resultaat;
        }

        public bool SelectEmail(string email)
        {
            bool resultaat = false;
            string sql = "select \"email\" as aantal from account where \"email\" = :email";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("email", email));
                OracleDataReader reader = cmd.ExecuteReader();
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
                DisConnect();
            }
            return resultaat;
        }

        public bool ActivateAccount(string hash)
        {
            bool resultaat = false;
            string sql = "Update ACCOUNT SET \"geactiveerd\" = 1 WHERE \"activatiehash\" = :hash ";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
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
                DisConnect();
            }
            return resultaat;
        }
    }
}