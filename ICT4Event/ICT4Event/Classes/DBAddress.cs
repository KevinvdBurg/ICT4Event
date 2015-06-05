using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBAddress : Database
    {

        /// <summary>
        /// Voegt het gegeven adres toe aan de database
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        //public bool Insert(Address address)
        //{
        //    bool resultaat = false;
        //    string sql = "INSERT INTO LOCATIE (PLAATS, POSTCODE, HUISNUMMER) VALUES (:plaats, :postcode, :nr)";
        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("plaats", address.City));
        //        cmd.Parameters.Add(new OracleParameter("postcode", address.ZipCode));
        //        cmd.Parameters.Add(new OracleParameter("nr", address.Number));
        //        cmd.ExecuteNonQuery();
        //        //OracleDataReader reader = cmd.ExecuteReader();
        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {

        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Verwijderd het gegeven adres uit de database
        ///// </summary>
        ///// <param name="address"></param>
        ///// <returns></returns>
        //public bool Delete(Address address)
        //{
        //    Administration administration = new Administration();
        //    bool resultaat = false;
        //    string sql = "DELETE FROM LOCATIE WHERE LOCATIEID = :AddressID";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("AddressID", administration.FindAddressID(address.ZipCode, address.Number)));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        resultaat = true;
        //    }
        //    catch (OracleException e)
        //    {
        //        Console.WriteLine(e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Haalt en retouneert het adres met de juiste postcode en huisnummer
        ///// </summary>
        ///// <param name="zipcode"></param>
        ///// <param name="housenumber"></param>
        ///// <returns></returns>
        //internal Address Select(string zipcode, string housenumber)
        //{
        //    Administration administration = new Administration();
        //    Address resultaat = null;
        //    string sql;
        //    sql = "Select * From Locatie WHERE LOCATIEID = :LOCATIEID";
        //    string PLAATS = "";
        //    string POSTCODE = "";
        //    string HUISNUMMER = "";
        //    string COUNTRY = "";

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("LOCATIEID", administration.FindAddressID(zipcode, housenumber)));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                PLAATS = Convert.ToString(reader["PLAATS"]);
        //                POSTCODE = Convert.ToString(reader["POSTCODE"]);
        //                HUISNUMMER = Convert.ToString(reader["HUISNUMMER"]);

        //            }

        //            resultaat = new Address(PLAATS, HUISNUMMER, POSTCODE);
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return resultaat;
        //}

        ///// <summary>
        ///// Retouneert het adresid waarvan het adres een passend postcode en huisnummer heeft
        ///// </summary>
        ///// <param name="zipcode"></param>
        ///// <param name="number"></param>
        ///// <returns></returns>
        //public int FindAdressID(string zipcode, string number)
        //{

        //    string sql;
        //    sql = "Select LOCATIEID From Locatie WHERE POSTCODE = :postcode AND HUISNUMMER = :huisnummer";
        //    int ADRESID = -1;

        //    try
        //    {
        //        Connect();
        //        OracleCommand cmd = new OracleCommand(sql, connection);
        //        cmd.Parameters.Add(new OracleParameter("postcode", zipcode));
        //        cmd.Parameters.Add(new OracleParameter("huisnummer", number));
        //        OracleDataReader reader = cmd.ExecuteReader();
        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                ADRESID = Convert.ToInt32(reader["LOCATIEID"]);
        //            }
        //            return ADRESID;
        //        }
        //    }
        //    catch (OracleException e)
        //    {
        //        throw;
        //    }
        //    finally
        //    {
        //        DisConnect();
        //    }
        //    return ADRESID;
        //}
    }
}