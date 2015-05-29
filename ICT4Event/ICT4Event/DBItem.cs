using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBItem : Database
    {
        public List<Item> SelectAllItems()
        {
            List<Item> resultaat = new List<Item>();
            string sql =
                "SELECT i.merk, i.naam, i.details, i.prijs, ic.naam as icnaam FROM item i INNER JOIN itemcategorie ic ON i.itemcategorieid = ic.itemcategorieid";
            string TYPE = "";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        string BRAND = Convert.ToString(reader["MERK"]);
                        string ITEMNAAM = Convert.ToString(reader["NAAM"]);
                        string DETAILS = Convert.ToString(reader["DETAILS"]);
                        Decimal PRICE = Convert.ToDecimal(reader["PRIJS"]);
                        string icnaam = Convert.ToString(reader["icnaam"]);


                        Item item = new Item(new CategoryItems(icnaam, DETAILS, PRICE), BRAND, ITEMNAAM);

                        resultaat.Add(item);

                    }
                }


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
        /// selecteerd een item op basis van de naam van het item
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public int ItemID(string naam)
        {
            int itemID = -1;
            string sql = "SELECT itemid FROM item i WHERE naam = :naam";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("email", naam));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        itemID = Convert.ToInt32(reader["itemid"]);

                    }
                    return itemID;
                }
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
            return itemID;

        }
    }


}