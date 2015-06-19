// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DBPost.cs" company="">
//   
// </copyright>
// <summary>
//   The db post.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    /// <summary>
    /// The db post.
    /// </summary>
    public class DBPost : Database
    {
        /// <summary>
        /// The get main categories.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetMainCategories()
        {
            // Zonder parent categorie
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select \"naam\" from categorie where \"categorie_id\" is null";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["naam"]));
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The get categorie id.
        /// </summary>
        /// <param name="categorieNaam">
        /// The categorie naam.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCategorieID(string categorieNaam)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\"  from categorie where \"naam\" = :catnaam";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("catnaam", categorieNaam));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["bijdrage_id"]);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The get sub categories.
        /// </summary>
        /// <param name="categorieID">
        /// The categorie id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetSubCategories(int categorieID)
        {
            // Zonder parent categorie
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select * from categorie where \"categorie_id\" = :catid";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("catid", categorieID));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["naam"]));
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The category files.
        /// </summary>
        /// <param name="categoryid">
        /// The categoryid.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> CategoryFiles(int categoryid)
        {
            List<string> resultaat = new List<string>();
            string sql;
            sql = "select \"bestandslocatie\" from bestand where \"categorie_id\" = :catid";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("catid", categoryid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["bestandslocatie"]));
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The main messages.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> MainMessages()
        {
            // Zonder parentpost
            List<string> resultaat = new List<string>();
            string sql;
            sql =
                "select \"titel\" from bericht where \"bijdrage_id\" not in (select \"bericht_id\" from BIJDRAGE_BERICHT)";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);

                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["titel"]));
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The get message id.
        /// </summary>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetMessageID(string titel)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\" from bericht where \"titel\" = :titel";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("titel", titel));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["bijdrage_id"]);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The get message.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string GetMessage(int id)
        {
            string resultaat = string.Empty;
            string sql;
            sql = "select \"inhoud\" from bericht where \"bijdrage_id\" = :id";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("id", id));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString(reader["inhoud"]);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The get comments.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetComments(int id)
        {
            List<string> resultaat = new List<string>();
            string sql;
            sql =
                "select \"inhoud\", \"gebruikersnaam\" from account a, account_bijdrage ab, bijdrage b, bericht be, bijdrage_bericht bb where a.ID = ab.\"account_id\" and ab.\"bijdrage_id\" = b.ID and b.ID = be.\"bijdrage_id\" and be.\"bijdrage_id\" = bb.\"bericht_id\" and bb.\"bijdrage_id\" = :id";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("id", id));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string comment = string.Empty;
                    comment += Convert.ToString(reader["inhoud"]);
                    comment += " - ";
                    comment += Convert.ToString(reader["gebruikersnaam"]);
                    resultaat.Add(comment);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The cat messages.
        /// </summary>
        /// <param name="catid">
        /// The catid.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> CatMessages(int catid)
        {
            // Zonder parentpost
            List<string> resultaat = new List<string>();
            string sql;
            sql =
                "select \"titel\" from bericht where \"bijdrage_id\" in (select \"bericht_id\" from BIJDRAGE_BERICHT where \"bijdrage_id\" = :catid)";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("catid", catid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString(reader["titel"]));
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The inset main message.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        public void InsetMainMessage(int accountid, string titel, string inhoud)
        {
            // Zonder parentpost
            string sql;
            sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 =
                "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 =
                "insert into bericht(\"bijdrage_id\", \"titel\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :titel, :inhoud)";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleCommand cmd2 = new OracleCommand(sql2, this.Connection);
                OracleCommand cmd3 = new OracleCommand(sql3, this.Connection);
                cmd.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd2.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd3.Parameters.Add(new OracleParameter("titel", titel));
                cmd3.Parameters.Add(new OracleParameter("inhoud", inhoud));

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }

        /// <summary>
        /// The insert cat message.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        /// <param name="catid">
        /// The catid.
        /// </param>
        public void InsertCatMessage(int accountid, string titel, string inhoud, int catid)
        {
            // Zonder parentpost
            string sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 =
                "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 =
                "insert into bericht(\"bijdrage_id\", \"titel\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :titel, :inhoud)";
            string sql4 =
                "insert into bijdrage_bericht (\"bijdrage_id\", \"bericht_id\") values (:catid, (select max(\"ID\") from bijdrage))";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleCommand cmd2 = new OracleCommand(sql2, this.Connection);
                OracleCommand cmd3 = new OracleCommand(sql3, this.Connection);
                OracleCommand cmd4 = new OracleCommand(sql4, this.Connection);
                cmd.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd2.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd3.Parameters.Add(new OracleParameter("titel", titel));
                cmd3.Parameters.Add(new OracleParameter("inhoud", inhoud));
                cmd4.Parameters.Add(new OracleParameter("catid", catid));

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }

        /// <summary>
        /// The get cat id.
        /// </summary>
        /// <param name="catnaam">
        /// The catnaam.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetCatId(string catnaam)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\" from categorie where \"naam\" = :catnaam";

            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                cmd.Parameters.Add(new OracleParameter("catnaam", catnaam));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["bijdrage_id"]);
                }
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }

            return resultaat;
        }

        /// <summary>
        /// The insert reply.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        /// <param name="postid">
        /// The postid.
        /// </param>
        public void InsertReply(int accountid, string inhoud, int postid)
        {
            // Zonder parentpost
            string sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 =
                "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 =
                "insert into bericht(\"bijdrage_id\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :inhoud)";
            string sql4 =
                "insert into bijdrage_bericht (\"bijdrage_id\", \"bericht_id\") values (:postid, (select max(\"ID\") from bijdrage))";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleCommand cmd2 = new OracleCommand(sql2, this.Connection);
                OracleCommand cmd3 = new OracleCommand(sql3, this.Connection);
                OracleCommand cmd4 = new OracleCommand(sql4, this.Connection);
                cmd.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd2.Parameters.Add(new OracleParameter("accountid", accountid));

                cmd3.Parameters.Add(new OracleParameter("inhoud", inhoud));
                cmd4.Parameters.Add(new OracleParameter("postid", postid));

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
                cmd4.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }

        /// <summary>
        /// The insert bestand.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="bestand">
        /// The bestand.
        /// </param>
        /// <param name="catid">
        /// The catid.
        /// </param>
        public void InsertBestand(int accountid, string bestand, int catid)
        {
            // Zonder parentpost
            string sql;
            sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bestand')";
            string sql2 =
                "INSERT INTO bestand(\"bijdrage_id\",\"categorie_id\",\"bestandslocatie\") values ((select max(ID) from bijdrage), :catid, :bestand)";
            string sql3 =
                "insert into account_bijdrage(\"account_id\", \"bijdrage_id\") values (:accountid, (select max(ID) from bijdrage))";
            try
            {
                this.Connect();
                OracleCommand cmd = new OracleCommand(sql, this.Connection);
                OracleCommand cmd2 = new OracleCommand(sql2, this.Connection);
                OracleCommand cmd3 = new OracleCommand(sql3, this.Connection);
                cmd.Parameters.Add(new OracleParameter("accountid", accountid));
                cmd2.Parameters.Add(new OracleParameter("catid", catid));
                cmd2.Parameters.Add(new OracleParameter("bestand", bestand));
                cmd3.Parameters.Add(new OracleParameter("accountid", accountid));

                cmd.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                cmd3.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
            }
            finally
            {
                this.Connection.Close();
            }
        }
    }
}