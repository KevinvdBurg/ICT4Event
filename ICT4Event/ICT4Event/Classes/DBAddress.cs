// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBAddress.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The db address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Data.OracleClient;

    /// <summary>
    /// The db address.
    /// </summary>
    public class DBAddress : Database
    {
        /// <summary>
        /// Voegt het gegeven adres toe aan de database
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Insert(Location location)
        {
            var resultaat = false;
            var sql =
                "INSERT INTO LOCATIE (\"plaats\", \"postcode\", \"nr\", \"naam\", \"straat\") VALUES (:plaats, :postcode, :nr, :naam, :straat)";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("plaats", location.Address.City));
                cmd.Parameters.Add(new OracleParameter("postcode", location.Address.ZipCode));
                cmd.Parameters.Add(new OracleParameter("nr", location.Address.Number));
                cmd.Parameters.Add(new OracleParameter("naam", location.Name));
                cmd.Parameters.Add(new OracleParameter("straat", location.Address.Street));
                cmd.ExecuteNonQuery();
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
        /// The update.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Update(Location location)
        {
            var administration = new Administration();
            var locatieid = administration.FindAddressID(location.Address.ZipCode, location.Address.Number);
            var resultaat = false;
            var sql =
                "UPDATE LOCATIE SET \"plaats\" = :plaats, \"postcode\" = :postcode, \"nr\" = :nr , \"naam\" = :naam , \"straat\" = :straat WHERE \"ID\" = :locatieid";
            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("plaats", location.Address.City));
                cmd.Parameters.Add(new OracleParameter("postcode", location.Address.ZipCode));
                cmd.Parameters.Add(new OracleParameter("nr", location.Address.Number));
                cmd.Parameters.Add(new OracleParameter("naam", location.Name));
                cmd.Parameters.Add(new OracleParameter("locatieid", locatieid));
                cmd.Parameters.Add(new OracleParameter("straat", location.Address.Street));
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
        /// Retouneert het adresid waarvan het adres een passend postcode en huisnummer heeft
        /// </summary>
        /// <param name="zipcode">
        /// Zipcode.
        /// </param>
        /// <param name="number">
        /// Number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int FindAdressID(string zipcode, string number)
        {
            string sql;
            sql = "Select \"ID\" From LOCATIE WHERE \"postcode\" = :postcode AND \"nr\" = :huisnummer";
            var ADRESID = -1;

            try
            {
                this.Connect();
                var cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("postcode", zipcode));
                cmd.Parameters.Add(new OracleParameter("huisnummer", number));
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ADRESID = Convert.ToInt32(reader["ID"]);
                    }

                    return ADRESID;
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

            return ADRESID;
        }
    }
}