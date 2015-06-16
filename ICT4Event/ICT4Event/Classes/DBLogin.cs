using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;
    using System.DirectoryServices;

    public class DBLogin:Database
    {

        public string loginCheck(string email, string password)
        {
            string resultaat = "Geen Connectie";
            string sql;
            sql = "select * from gebruiker where emailadres = :email and wachtwoord = :password";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("email", email));
                cmd.Parameters.Add(new OracleParameter("password", password));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    int geactiveerd = Convert.ToInt32(reader["geactiveerd"]);
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
                connection.Close();
            }
            return resultaat;
        }

        //public Account returnLoggedinAccount(string email)
        //{

        //    Account account = new Account();
        //    string lastName = "";
        //    string name = "";
        //    string type = "";
        //    string rfid = "";
        //    int gebruikerid = 0;

        //    string sql;
        //    sql = "select * from gebruiker where emailadres = :email";

        //    try
        //    {
        //        Connect();

        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("email", email));
        //        //cmd.Parameters.Add(new OracleParameter("password", password));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        while (reader.Read())
        //        {

        //            name = Convert.ToString(reader["voornaam"]);
        //            lastName = Convert.ToString(reader["achternaam"]);
        //            rfid = Convert.ToString(reader["rfid"]);
        //            gebruikerid = Convert.ToInt32(reader["gebruikerid"]);
        //            if (Convert.ToInt32(reader["isAdmin"]) > 0)
        //            {
        //                type = "admin";
        //            }
        //            else
        //            {
        //                type = "bezoeker";
        //            }
        //        }

        //        account = new Account(new Person(email, lastName, name), type, rfid, gebruikerid);



        //    }
        //    catch (OracleException e)
        //    {

        //    }
        //    finally
        //    {
        //        connection.Close();
        //    }
        //    return account;
        //}
        /*public void getAllPersons()
        {
            List<Person> resultaat = new List<Person>();
            
            string sql;
            sql = "select *from gebruiker;";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    resultaat = true;
                }
            }
            catch (OracleException e)
            {

            }
            finally
            {
                connection.Close();
            }
            
        }*/
    }
}