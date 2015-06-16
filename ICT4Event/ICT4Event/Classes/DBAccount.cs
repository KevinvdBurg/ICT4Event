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

        // Zoekt op het oude email en geeft hem een nieuw email
        // public  bool Update(Account Account, string oldemail)
        // {
        // bool resultaat = false;
        // string sql;
        // int gebruikersID = FindAccountID(oldemail);
        // sql = "UPDATE GEBRUIKER SET EMAILADRES = :email, WACHTWOORD = :wachtwoord, PLAATS = :plaats, POSTCODE = :postcode, HUISNUMMER = :huisnummer, VOORNAAM = :voornaam, ACHTERNAAM = :achternaam WHERE GEBRUIKERID = :gebruikerID";

        // try
        // {
        // Connect();
        // OracleCommand cmd = new OracleCommand(sql, connection);

        // if (Account.Person.Email == null || Regex.Replace(Account.Person.Email, @"\s+", "") == "")
        // {
        // cmd.Parameters.Add(new OracleParameter("email", oldemail));
        // }
        // else
        // {
        // cmd.Parameters.Add(new OracleParameter("email", Account.Person.Email));
        // }
        // cmd.Parameters.Add(new OracleParameter("wachtwoord", Account.Wachtwoord));
        // cmd.Parameters.Add(new OracleParameter("plaats", Account.Person.Address.City));
        // cmd.Parameters.Add(new OracleParameter("postcode", Account.Person.Address.ZipCode));
        // cmd.Parameters.Add(new OracleParameter("huisnummer", Account.Person.Address.Number));
        // cmd.Parameters.Add(new OracleParameter("voornaam", Account.Person.Name));
        // cmd.Parameters.Add(new OracleParameter("achternaam", Account.Person.LastName));
        // cmd.Parameters.Add(new OracleParameter("gebruikerID", gebruikersID));
        // cmd.ExecuteNonQuery();
        // resultaat = true;
        // }
        // catch (OracleException e)
        // {
        // throw;
        // }
        // finally
        // {
        // DisConnect();
        // }
        // return resultaat;
        // }

        // public  bool Delete(Account account)
        // {
        // bool resultaat = false;
        // string sql = "DELETE FROM Gebruiker WHERE EMAILADRES = :email";

        // try
        // {
        // Connect();
        // OracleCommand cmd = new OracleCommand(sql, connection);
        // cmd.Parameters.Add(new OracleParameter("email", account.Person.Email));
        // //MessageBox.Show(cmd.ExecuteNonQueryAsync());
        // cmd.ExecuteNonQueryAsync();

        // resultaat = true;
        // }
        // catch (OracleException e)
        // {
        // Console.WriteLine(e.Message);
        // throw;
        // }
        // finally
        // {
        // DisConnect();
        // }
        // return resultaat;
        // }

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

        // internal Account Select(string email)
        // {
        // Account resultaat = null;
        // string sql = "select * from gebruiker where EMAILadres = :email";
        // string lastName = "";
        // string name = "";
        // string type = "";
        // string rfid = "";
        // string city = "";
        // string nr = "";
        // string zipcode = "";
        // //string email = "";
        // string wachtwoord = "";

        // try
        // {
        // Connect();
        // OracleCommand cmd = new OracleCommand(sql, connection);
        // cmd.Parameters.Add(new OracleParameter("EMAIL", email));
        // OracleDataReader reader = cmd.ExecuteReader();
        // if (reader.HasRows)
        // {
        // while (reader.Read())
        // {
        // name = Convert.ToString(reader["voornaam"]);
        // lastName = Convert.ToString(reader["achternaam"]);
        // rfid = Convert.ToString(reader["rfid"]);
        // city = Convert.ToString(reader["plaats"]);
        // nr = Convert.ToString(reader["huisnummer"]);
        // zipcode = Convert.ToString(reader["postcode"]);
        // email = Convert.ToString(reader["emailadres"]);
        // wachtwoord = Convert.ToString(reader["wachtwoord"]);

        // if (Convert.ToInt32(reader["isAdmin"]) > 0)
        // {
        // type = "admin";
        // }
        // else
        // {
        // type = "bezoeker";
        // }
        // }
        // resultaat = new Account(new Person(new Address(city, nr, zipcode), email, name, lastName), type, rfid, wachtwoord);
        // }
        // }
        // catch (OracleException e)
        // {
        // throw;
        // }
        // finally
        // {
        // DisConnect();
        // }
        // return resultaat;
        // }

        // public int FindAccountID(string email)
        // {
        // int accountID = -1;
        // string sql = "select GEBRUIKERID from gebruiker where Emailadres = :email";

        // try
        // {
        // Connect();
        // OracleCommand cmd = new OracleCommand(sql, connection);
        // cmd.Parameters.Add(new OracleParameter("email", email));
        // OracleDataReader reader = cmd.ExecuteReader();
        // if (reader.HasRows)
        // {
        // while (reader.Read())
        // {
        // accountID = Convert.ToInt32(reader["gebruikerID"]);

        // }
        // return accountID;
        // }
        // }
        // catch (OracleException e)
        // {
        // throw;
        // }
        // finally
        // {
        // DisConnect();
        // }
        // return accountID;
        // }
    }
}