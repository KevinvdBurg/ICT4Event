// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBItem.cs" company="">
//   
// </copyright>
// <summary>
//   The db item.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ICT4Event
{
    using System.Data;
    using System.Data.OracleClient;
    using System.Net.Sockets;
    using System.Text.RegularExpressions;
    using System.Xml.Linq;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// The db item.
    /// </summary>
    public class DBItem : Database
    {
        /// <summary>
        /// The find free items list.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Item> FindFreeItemsList()
        {
            List<Item> resultaat = new List<Item>();
            int Exemplaar_ID;
            string Merk;
            string Serie;
            int TypeNummer;
            int prijs;
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand("BESCHIKBARE_ITEMS", this.Connection);
                cmd.CommandType = CommandType.StoredProcedure;

                // cmd.Parameters.Add("P_ID", OracleType.Int32).Direction = ParameterDirection.Output;
                OracleParameter returnParameter = cmd.Parameters.Add("CURSOR_ITEMS", OracleType.Cursor);
                returnParameter.Direction = ParameterDirection.Output;

                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Exemplaar_ID = Convert.ToInt32(reader["ID"]);
                        Merk = Convert.ToString(reader["merk"]);
                        Serie = Convert.ToString(reader["serie"]);
                        TypeNummer = Convert.ToInt32(reader["typenummer"]);
                        prijs = Convert.ToInt32(reader["prijs"]);
                        Item item = new Item(Exemplaar_ID, Merk, Serie, TypeNummer, prijs);
                        resultaat.Add(item);
                    }
                }
            }
            catch (OracleException
                e)
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
        /// The new item reservation.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool NewItemReservation(Item item)
        {
            var resultaat = false;
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand("ITEM_RESERVEREN", this.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("productexemplaarid_in", item.ExemplaarID);
                cmd.Parameters.Add("prijs_in", item.Prijs);
                cmd.ExecuteNonQuery();
            }
            catch (OracleException
                e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
            finally
            {
                this.DisConnect();
            }

            resultaat = true;
            return resultaat;
        }




        /*public List<Item> SelectAllItems()
        {
            List<CampingSpot> result = new List<CampingSpot>();
            //string sql = "SELECT * FROM plek WHERE id NOT IN (SELECT plek_id FROM plek_reservering)";
            string sql = "SELECT * FROM Productexemplaar";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        int ID = Convert.ToInt32(reader["id"]);
                        int LocationID = Convert.ToInt32(reader["locatie_id"]);
                        string Number = Convert.ToString(reader["nummer"]);
                        int Capticity = Convert.ToInt32(reader["capaciteit"]);

                        CampingSpot campingSpot = new CampingSpot(ID, LocationID, Number, Capticity);
                        result.Add(campingSpot);
                    }
                }
            }
        */

            // public int ItemID (stringnaam)
            // {
            // int itemID = -1;
            // string sql = "SELECT itemid FROM item i WHERE naam = :naam";
            // try
            // {
            // Connect();
            // OracleCommand cmd = new OracleCommand(sql, connection);
            // cmd.Parameters.Add(new OracleParameter("email", naam));
            // OracleDataReader reader = cmd.ExecuteReader();
            // if (reader.HasRows)
            // {
            // while (reader.Read())
            // {
            // itemID = Convert.ToInt32(reader["itemid"]);

            // }
            // return itemID;
            // }
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
            // return itemID;

            // }
        }
    }