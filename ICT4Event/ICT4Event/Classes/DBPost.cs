using System;
using System.Collections.Generic;
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
            sql = "select * from bericht b where b.\"bijdrage_id\" IN (select \"bijdrage_id\" from bijdrage_bericht)";

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

    }
}