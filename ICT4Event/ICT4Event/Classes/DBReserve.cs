// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBReserve.cs" company="">
//   
// </copyright>
// <summary>
//   The db reserve.
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
    /// The db reserve.
    /// </summary>
    public class DBReserve : Database
    {
        /// <summary>
        /// The new person.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NewPerson(Person person)
        {
            int id = 0;
            string voornaam = person.FirstName;
            string achternaam = person.LastName;
            string straat = person.Street;
            string huis = person.HouseNumber;
            string woon = person.City;
            string bank = person.Banknumber;
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand("REGISTREERHOOFDBOEKER", this.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("P_Voornaam", voornaam);
                cmd.Parameters.Add("P_Tussenvoegsel", person.Insertion);
                cmd.Parameters.Add("P_Achternaam", achternaam);
                cmd.Parameters.Add("P_Straat", straat);
                cmd.Parameters.Add("P_Huisnr", huis);
                cmd.Parameters.Add("P_Woonplaats", woon);
                cmd.Parameters.Add("P_Banknr", bank);

                // cmd.Parameters.Add("P_ID", OracleType.Int32).Direction = ParameterDirection.Output;
                OracleParameter returnParameter = cmd.Parameters.Add("P_ID", OracleType.Number);
                returnParameter.Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                id = Convert.ToInt32(cmd.Parameters[7].Value);
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

            return id;
        }

        /// <summary>
        /// The new reservation.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="plekid">
        /// The plekid.
        /// </param>
        public void NewReservation(Person person, string plekid)
        {
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand("RESERVEERPLEK", this.Connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("R_ID", person.PersonID);
                cmd.Parameters.Add("R_PLEKID", Convert.ToInt32(plekid));
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
        }
    }
}