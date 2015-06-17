using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    public class DBPost : Database
    {

        public List<String>  GetMainCategories()//Zonder parent categorie
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select \"naam\" from categorie where \"categorie_id\" is null";
            
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString((reader["naam"])));
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

        public int GetCategorieID(string categorieNaam)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\"  from categorie where \"naam\" = :catnaam";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("catnaam", categorieNaam));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32((reader["bijdrage_id"]));
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

        public List<String> GetSubCategories(int categorieID)//Zonder parent categorie
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select * from categorie where \"categorie_id\" = :catid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("catid", categorieID));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString((reader["naam"])));
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

        public List<String> CategoryFiles(int categoryid)
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select \"bestandslocatie\" from bestand where \"categorie_id\" = :catid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("catid", categoryid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString((reader["bestandslocatie"])));
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

        public List<String> MainMessages()//Zonder parentpost
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select \"titel\" from bericht where \"bijdrage_id\" not in (select \"bericht_id\" from BIJDRAGE_BERICHT)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString((reader["titel"])));
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

        public int GetMessageID(string titel)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\" from bericht where \"titel\" = :titel";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("titel", titel));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32((reader["bijdrage_id"]));
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


        public string GetMessage(int id)
        {
            string resultaat = "";
            string sql;
            sql = "select \"inhoud\" from bericht where \"bijdrage_id\" = :id";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("id", id));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString((reader["inhoud"]));
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

        public List<String> GetComments(int id)
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select \"inhoud\", \"gebruikersnaam\" from account a, account_bijdrage ab, bijdrage b, bericht be, bijdrage_bericht bb where a.ID = ab.\"account_id\" and ab.\"bijdrage_id\" = b.ID and b.ID = be.\"bijdrage_id\" and be.\"bijdrage_id\" = bb.\"bericht_id\" and bb.\"bijdrage_id\" = :id";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("id", id));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string comment = "";
                    comment+= Convert.ToString((reader["inhoud"]));
                    comment += " - ";
                    comment += Convert.ToString((reader["gebruikersnaam"]));
                    resultaat.Add(comment);
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

        public List<String> CatMessages(int catid)//Zonder parentpost
        {
            List<String> resultaat = new List<String>();
            string sql;
            sql = "select \"titel\" from bericht where \"bijdrage_id\" in (select \"bericht_id\" from BIJDRAGE_BERICHT where \"bijdrage_id\" = :catid)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("catid", catid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(Convert.ToString((reader["titel"])));
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

        public void InsetMainMessage(int accountid, string titel, string inhoud)//Zonder parentpost
        {
            string sql;
            sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 = "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 = "insert into bericht(\"bijdrage_id\", \"titel\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :titel, :inhoud)";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleCommand cmd2 = new OracleCommand(sql2, connection);
                OracleCommand cmd3 = new OracleCommand(sql3, connection);
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
                connection.Close();
            }
        }

        public void InsertCatMessage(int accountid, string titel, string inhoud, int catid)//Zonder parentpost
        {
            string sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 = "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 = "insert into bericht(\"bijdrage_id\", \"titel\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :titel, :inhoud)";
            string sql4 ="insert into bijdrage_bericht (\"bijdrage_id\", \"bericht_id\") values (:catid, (select max(\"ID\") from bijdrage))";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleCommand cmd2 = new OracleCommand(sql2, connection);
                OracleCommand cmd3 = new OracleCommand(sql3, connection);
                OracleCommand cmd4 = new OracleCommand(sql4, connection);
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
                connection.Close();
            }
        }

        public int GetCatId(string catnaam)
        {
            int resultaat = 0;
            string sql;
            sql = "select \"bijdrage_id\" from categorie where \"naam\" = :catnaam";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("catnaam", catnaam));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32((reader["bijdrage_id"]));
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

        public void InsertReply(int accountid, string inhoud, int postid)//Zonder parentpost
        {
            string sql = "insert into bijdrage (\"account_id\", \"soort\") values (:accountid, 'bericht')";
            string sql2 = "insert into account_bijdrage (\"account_id\", \"bijdrage_id\") values (:accountid, (select max(\"ID\") from bijdrage))";
            string sql3 = "insert into bericht(\"bijdrage_id\", \"inhoud\") values ((select max(\"ID\") from bijdrage), :inhoud)";
            string sql4 = "insert into bijdrage_bericht (\"bijdrage_id\", \"bericht_id\") values (:postid, (select max(\"ID\") from bijdrage))";
            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleCommand cmd2 = new OracleCommand(sql2, connection);
                OracleCommand cmd3 = new OracleCommand(sql3, connection);
                OracleCommand cmd4 = new OracleCommand(sql4, connection);
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
                connection.Close();
            }
        }




    }
}