using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;
    using System.Text.RegularExpressions;

    public class DBAccount : Database
    {
        //Zoekt op het oude email en geeft hem een nieuw email
	public  bool Update(Account Account, string oldemail)
	{
	    bool resultaat = false;
        string sql;
        int gebruikersID = FindAccountID(oldemail);
        sql = "UPDATE GEBRUIKER SET EMAILADRES = :email, WACHTWOORD = :wachtwoord, PLAATS = :plaats, POSTCODE = :postcode, HUISNUMMER = :huisnummer, VOORNAAM = :voornaam, ACHTERNAAM = :achternaam WHERE GEBRUIKERID = :gebruikerID";

        
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            
            if (Account.Person.Email == null || Regex.Replace(Account.Person.Email, @"\s+", "") == "")
            {
                cmd.Parameters.Add(new OracleParameter("email", oldemail));
            }
            else
            {
                cmd.Parameters.Add(new OracleParameter("email", Account.Person.Email));
            }
            cmd.Parameters.Add(new OracleParameter("wachtwoord", Account.Wachtwoord));
            cmd.Parameters.Add(new OracleParameter("plaats", Account.Person.Address.City));
            cmd.Parameters.Add(new OracleParameter("postcode", Account.Person.Address.ZipCode));
            cmd.Parameters.Add(new OracleParameter("huisnummer", Account.Person.Address.Number));
            cmd.Parameters.Add(new OracleParameter("voornaam", Account.Person.Name));
            cmd.Parameters.Add(new OracleParameter("achternaam", Account.Person.LastName));
            cmd.Parameters.Add(new OracleParameter("gebruikerID", gebruikersID));
            cmd.ExecuteNonQuery();
            resultaat = true;
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

    public bool Insert(AccountEvent accountEvent)
    {
        bool resultaat = false;
        int present = 0;
        if (accountEvent.Present)
        {
            present = 1;
        }
        string sql = "INSERT INTO gebruikerevent (GEBRUIKERID, EVENTID, AANWEZIG) VALUES (:gebruikerid, :eventid, :aanwezig)";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("gebruikerid", accountEvent.AccountID));
            cmd.Parameters.Add(new OracleParameter("eventid", accountEvent.EventID));
            cmd.Parameters.Add(new OracleParameter("aanwezig", present));
            cmd.ExecuteNonQuery();
            //OracleDataReader reader = cmd.ExecuteReader();
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

	public  bool Delete(Account account)
	{
        bool resultaat = false;
        string sql = "DELETE FROM Gebruiker WHERE EMAILADRES = :email";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("email", account.Person.Email));
            //MessageBox.Show(cmd.ExecuteNonQueryAsync());
            cmd.ExecuteNonQueryAsync();
            
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


	public  bool Insert(Account account)
	{
        bool resultaat = false;
        string sql = "INSERT INTO GEBRUIKER(RFID, EMAILADRES, WACHTWOORD, PLAATS, POSTCODE, HUISNUMMER, ISADMIN, VOORNAAM, ACHTERNAAM) VALUES (:RFID, :emailadres, :wachtwoord, :plaats, :postcode, :huisnummer, :isadmin, :voornaam, :achternaam)";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("RFID", null));
            cmd.Parameters.Add(new OracleParameter("email", account.Person.Email));
            cmd.Parameters.Add(new OracleParameter("wachtwoord", account.Wachtwoord));
            cmd.Parameters.Add(new OracleParameter("plaats", account.Person.Address.City));
            cmd.Parameters.Add(new OracleParameter("postcode", account.Person.Address.ZipCode));
            cmd.Parameters.Add(new OracleParameter("huisnummer", account.Person.Address.Number));
            cmd.Parameters.Add(new OracleParameter("isadmin", "0"));
            cmd.Parameters.Add(new OracleParameter("voornaam", account.Person.Name));
            cmd.Parameters.Add(new OracleParameter("achternaam", account.Person.LastName));
            cmd.ExecuteNonQuery();
            //OracleDataReader reader = cmd.ExecuteReader();
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

	public  void Select()
	{
	}


    internal Account Select(string email)
    {
        Account resultaat = null;
        string sql = "select * from gebruiker where EMAILadres = :email";
            string lastName = "";
            string name = "";
            string type = "";
            string rfid = "";
            string city = "";
            string nr = "";
            string zipcode = "";
            //string email = "";
            string wachtwoord = "";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("EMAIL", email));
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    name = Convert.ToString(reader["voornaam"]);
                    lastName = Convert.ToString(reader["achternaam"]);
                    rfid = Convert.ToString(reader["rfid"]);
                    city = Convert.ToString(reader["plaats"]);
                    nr = Convert.ToString(reader["huisnummer"]);
                    zipcode = Convert.ToString(reader["postcode"]);
                    email = Convert.ToString(reader["emailadres"]);
                    wachtwoord = Convert.ToString(reader["wachtwoord"]);

                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }
                }
                resultaat = new Account(new Person(new Address(city, nr, zipcode), email, name, lastName), type, rfid, wachtwoord);
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
        
    public int FindAccountID(string email)
    {
        int accountID = -1;
        string sql = "select GEBRUIKERID from gebruiker where Emailadres = :email";

        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("email", email));
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    accountID = Convert.ToInt32(reader["gebruikerID"]);
                   
                }
                return accountID;
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
        return accountID;
    }

    internal List<Account> SelectAll()
    {
        List<Account> resultaat = new List<Account>();
        string sql = "select * from gebruiker";
        string type = "";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            OracleDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string name = Convert.ToString(reader["voornaam"]);
                    string lastName = Convert.ToString(reader["achternaam"]);
                    string rfid = Convert.ToString(reader["rfid"]);
                    string city = Convert.ToString(reader["plaats"]);
                    string nr = Convert.ToString(reader["huisnummer"]);
                    string zipcode = Convert.ToString(reader["postcode"]);
                    string email = Convert.ToString(reader["emailadres"]);
                    string wachtwoord = Convert.ToString(reader["wachtwoord"]);
                    if (Convert.ToInt32(reader["isAdmin"]) > 0)
                    {
                        type = "admin";
                    }
                    else
                    {
                        type = "bezoeker";
                    }

                    Account tempAccount = new Account(new Person(new Address(city, nr, zipcode), email, name, lastName), type, rfid, wachtwoord);
                    
                    resultaat.Add(tempAccount);

                }
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

    //rfid koppelen aan een account
    public bool ChainRFID(string email, string rfid)
    {
        string ReplaceEmail = "'" + email + "'";
        string ReplaceRFID = "'" + rfid + "'";
        bool resultaat = false;
        string sql;
        string testsql = "UPDATE GEBRUIKER SET RFID =" + ReplaceRFID + " WHERE EMAILADRES =" + ReplaceEmail;
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(testsql, connection);
            cmd.Parameters.Add(new OracleParameter("EMAIL", ReplaceEmail));
            cmd.Parameters.Add(new OracleParameter("rfid", ReplaceRFID));
            cmd.ExecuteNonQuery();
            resultaat = true;
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

    public void UpdateAccountEvent(int pressent)
    {
        return; 
    }

    //zet een gebruiker op aanwezig
    public bool UpdateAccountEvent(AccountEvent accountEvent)
    {
        bool resultaat = false;
        string sql = "UPDATE GEBRUIKEREVENT SET AANWEZIG = '1'  WHERE GEBRUIKERID = :GEBRUIKERID";
        try
        {
            Connect();
            OracleCommand cmd = new OracleCommand(sql, connection);
            cmd.Parameters.Add(new OracleParameter("GEBRUIKERID", accountEvent.AccountID));
            cmd.ExecuteNonQuery();
            resultaat = true;
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

    //kijkt of een gebruiker aanwezig is
        public AccountEvent FindAccountEvent(int accountId, int eventId)
        {
            AccountEvent accountEvent = null;
            string sql =
                "SELECT AANWEZIG, GEBRUIKERID, EVENTID FROM GEBRUIKEREVENT WHERE GEBRUIKERID = :accountId AND EVENTID = :eventId";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);

                cmd.Parameters.Add(new OracleParameter("accountId", accountId));
                cmd.Parameters.Add(new OracleParameter("eventId", eventId));

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        accountEvent = new AccountEvent(
                            Convert.ToBoolean(reader["AANWEZIG"]),
                            Convert.ToInt32(reader["GEBRUIKERID"]),
                            Convert.ToInt32(reader["EVENTID"]));
                    }
                    return accountEvent;
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
            return accountEvent;
        }
    }
}