using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Data.OracleClient;

    public class DBPost:Database
    {
        public bool LikePost(int postid)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            sql = "update post set aantallikes = aantallikes + 1 where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                //OracleDataReader reader = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public bool ReportPost(int postid)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            sql = "update post set aantalreports = aantalreports + 1 where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                //OracleDataReader reader = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }


        public bool Delete(string postid)
        {
            //throw new System.NotImplementedException();
            bool resultaat = false;
            string sql;
            sql = "DELETE * from post where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                cmd.ExecuteNonQuery();
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
        public string GetTitel(int postid)
        {
            string resultaat = "";
            string sql;
            sql = "select titel from post where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString(reader["titel"]);
                }
                /*if (reader.HasRows)
                {
                
                }*/


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

        public string GetPostAuteur(int postid)
        {
            string resultaat = "";
            string sql;
            sql = "select voornaam, achternaam from gebruiker, post where gebruiker.gebruikerid = post.gebruikerid and post.postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString(reader["voornaam"]) + " " + Convert.ToString(reader["achternaam"]);
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

        public int numberOfReplies(int postid)
        {
            int resultaat = 0;
            string sql;
            sql = "select count(postid) as aantal from post where parentpostid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["aantal"]);
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

        public string GetText(int postid)
        {
            string resultaat = "";
            string sql;
            sql = "select inhoud from bericht where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString(reader["inhoud"]);
                }
                /*if (reader.HasRows)
                {
                
                }*/


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

        // public bool isBericht(int postid);
        public List<Post> allReplies(int postid)//dus met parent post
        {
            List<Post> resultaat = new List<Post>();
            string sql;
            sql = "select * from post where parentpostid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(new Post(Convert.ToInt32(reader["postid"]), Convert.ToInt32(reader["aantallikes"]), Convert.ToInt32(reader["aantalreports"]), Convert.ToString(reader["titel"])));

                }
            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public bool isBestand(int postid)
        {
            bool resultaat = false;
            string sql;
            sql = "select * from post where  soort = 'Bestand' and postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
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
            return resultaat;
        }


        public bool isBericht(int postid)
        {
            bool resultaat = false;
            string sql;
            sql = "select * from post where  soort = 'Bericht' and postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
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
            return resultaat;
        }

        public int FindPostId(Post findPost)
        {
            //throw new System.NotImplementedException();
            int resultaat = 0;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "SELECT postid FROM post WHERE GebruikerID = :accountje AND mapid = :map AND Soort = :type AND titel = :title";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("accountje", findPost.Account.GebruikerID));
                cmd.Parameters.Add(new OracleParameter("map", findPost.Map));
                cmd.Parameters.Add(new OracleParameter("type", findPost.Type));
                cmd.Parameters.Add(new OracleParameter("title", findPost.Title));
                /*cmd.Parameters.Add(new OracleParameter("reports", findPost.Reports));
                cmd.Parameters.Add(new OracleParameter("likes", findPost.Likes));
                cmd.Parameters.Add(new OracleParameter("datum", findPost.Date.ToString("dd/MMMM/yy")));*/
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["postid"]);
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

        public int FindPostId(Post findPost, Account account)
        {
            //throw new System.NotImplementedException();
            int resultaat = 0;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "SELECT postid FROM post WHERE GebruikerID = :accountje AND mapid = :map AND Soort = :type AND titel = :title";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("accountje", account.GebruikerID));
                cmd.Parameters.Add(new OracleParameter("map", findPost.Map));
                cmd.Parameters.Add(new OracleParameter("type", findPost.Type));
                cmd.Parameters.Add(new OracleParameter("title", findPost.Title));
                /*cmd.Parameters.Add(new OracleParameter("reports", findPost.Reports));
                cmd.Parameters.Add(new OracleParameter("likes", findPost.Likes));
                cmd.Parameters.Add(new OracleParameter("datum", findPost.Date.ToString("dd/MMMM/yy")));*/
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["postid"]);
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

        public bool InsertMessage(Post postinsert, string inhoud)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into post(GEBRUIKERID, MAPID, SOORT, TITEL, AANTALREPORTS, AANTALLIKES, DATUM) values (:accountje, :map, :type, :title, :reports, :likes, :datum)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("accountje", postinsert.Account.GebruikerID));
                cmd.Parameters.Add(new OracleParameter("map", postinsert.Map));
                cmd.Parameters.Add(new OracleParameter("type", postinsert.Type));
                cmd.Parameters.Add(new OracleParameter("title", postinsert.Title));
                cmd.Parameters.Add(new OracleParameter("reports", postinsert.Reports));
                cmd.Parameters.Add(new OracleParameter("likes", postinsert.Likes));
                cmd.Parameters.Add(new OracleParameter("datum", postinsert.Date.ToString("dd/MMMM/yy")));
                cmd.ExecuteNonQuery();
                int postid = FindPostId((postinsert));
                if (isBericht(postid))
                {
                    InsertMessage(postid, inhoud);
                }
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public bool InsertFile(File file, Account account)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into post(GEBRUIKERID, MAPID, SOORT, TITEL, AANTALREPORTS, AANTALLIKES, DATUM) values (:accountje, :map, :type, :title, :reports, :likes, :datum)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("accountje", account.GebruikerID));
                cmd.Parameters.Add(new OracleParameter("map", file.Map));
                cmd.Parameters.Add(new OracleParameter("type", file.Type));
                cmd.Parameters.Add(new OracleParameter("title", file.Title.ToString()));
                cmd.Parameters.Add(new OracleParameter("reports", file.Reports));
                cmd.Parameters.Add(new OracleParameter("likes", file.Likes));
                cmd.Parameters.Add(new OracleParameter("datum", file.Date.ToString("dd/MMMM/yy")));
                cmd.ExecuteNonQuery();
                int postid = FindPostId(file, account);
                if (isBestand(postid))
                {
                    InsertBestand(postid, file);
                }
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public bool InsertBestand(int postid, File file)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into Bestand(postid, typeid, bestandslocatie) values (:postid, :typeid, :bestandslocattie)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                cmd.Parameters.Add(new OracleParameter("typeid", file.TypeBestand));
                cmd.Parameters.Add(new OracleParameter("bestandslocatie", file.FileLocation));
                //cmd.Parameters.Add(new OracleParameter("grootte", file.Size.ToString()));
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;

        }

        public bool InsertMessage(int postid, string inhoud)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into bericht(postid, inhoud) values (:postid, :inhoud)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                cmd.Parameters.Add(new OracleParameter("inhoud", inhoud));
                cmd.ExecuteNonQuery();
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;

        }
        public bool Insert(Map map)
        {
            //throw new System.NotImplementedException();
            bool resultaat = false;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into map (PARENTMAPID, NAAM)" +
                  "values (:parentmapid, :naam)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("parentmapid", map.ParentMap));
                cmd.Parameters.Add(new OracleParameter("naam", map.Name));
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
            return resultaat;
        }

        public List<Post> allPosts()//zonder parent post
        {
            List<Post> resultaat = new List<Post>();
            string sql;
            sql = "select * from post";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!hasParentPost(Convert.ToInt32(reader["postid"])))
                    {
                        /*if(Convert.ToString(reader["soort"]) == "bericht")
                        {
                            resultaat.Add(new Message(Convert.ToDateTime(reader["datum"]), Convert.ToInt32(reader["aantallikes"]),Convert.ToInt32(reader["mapid"]), Convert.ToInt32(reader["aantaldislikes"]), Convert.ToString(reader["titel"]), "bericht", Convert.ToString(reader[");
                        }*/
                        resultaat.Add(new Post(Convert.ToInt32(reader["postid"]), Convert.ToInt32(reader["aantallikes"]), Convert.ToInt32(reader["aantalreports"]), Convert.ToString(reader["titel"])));
                    }
                }
            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public bool hasParentPost(int postid)
        {
            bool resultaat = true;
            string sql;
            sql = "select postid from post where parentpostid is null and postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    resultaat = false;
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

        public int returnParentPost(int postid)
        {
            int resultaat = 0;
            string sql;
            sql = "select parentpostid from post where postid = :postid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("postid", postid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToInt32(reader["parentpostid"]);
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

        public bool InsertReply(Post postinsert, string inhoud)
        {
            //throw new System.NotImplementedException();
            bool resultaat = true;
            string sql;
            //CHECKEN OF DIE GOED IS?
            sql = "insert into post(GEBRUIKERID, MAPID, PARENTPOSTID, SOORT, TITEL, AANTALREPORTS, AANTALLIKES, DATUM) values (:accountje, :map, :parentpost, :type, :title, :reports, :likes, :datum)";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("accountje", postinsert.Account.GebruikerID));
                cmd.Parameters.Add(new OracleParameter("map", postinsert.Map));
                cmd.Parameters.Add(new OracleParameter("parentpost", postinsert.ParentPost));
                cmd.Parameters.Add(new OracleParameter("type", postinsert.Type));
                cmd.Parameters.Add(new OracleParameter("title", postinsert.Title));
                cmd.Parameters.Add(new OracleParameter("reports", postinsert.Reports));
                cmd.Parameters.Add(new OracleParameter("likes", postinsert.Likes));
                cmd.Parameters.Add(new OracleParameter("datum", postinsert.Date.ToString("dd/MMMM/yy")));
                cmd.ExecuteNonQuery();
                int postid = FindPostId((postinsert));
                if (isBericht(postid))
                {
                    InsertMessage(postid, inhoud);
                }
            }
            catch (OracleException e)
            {
                resultaat = false;
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        // public bool isBericht(int postid);

        public List<Map> allMaps()//zonder parent map
        {
            List<Map> resultaat = new List<Map>();
            string sql;
            sql = "select * from map where parentmapid is null";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(new Map(Convert.ToInt32(reader["mapid"]), Convert.ToString(reader["naam"])));
                }
            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }
        public List<Map> allMaps(int parentmap)//met parent map
        {
            List<Map> resultaat = new List<Map>();
            string sql;
            sql = "select * from map where parentmapid = :parentmap";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("parentmap", parentmap));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat.Add(new Map(Convert.ToInt32(reader["mapid"]), Convert.ToString(reader["naam"]), Convert.ToInt32(reader["parentmapid"])));
                }
            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public List<Post> allPosts(int currentmap)//met parentmap
        {
            List<Post> resultaat = new List<Post>();
            string sql;
            sql = "select * from post where mapid = :currentmap";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("current", currentmap));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (!hasParentPost(Convert.ToInt32(reader["postid"])))
                    {
                        /*if(Convert.ToString(reader["soort"]) == "bericht")
                        {
                            resultaat.Add(new Message(Convert.ToDateTime(reader["datum"]), Convert.ToInt32(reader["aantallikes"]),Convert.ToInt32(reader["mapid"]), Convert.ToInt32(reader["aantaldislikes"]), Convert.ToString(reader["titel"]), "bericht", Convert.ToString(reader[");
                        }*/
                        resultaat.Add(new Post(Convert.ToInt32(reader["postid"]), Convert.ToInt32(reader["aantallikes"]), Convert.ToInt32(reader["aantalreports"]), Convert.ToString(reader["titel"])));
                    }
                }
            }
            catch (OracleException e)
            {
                // The connection failed. Display an error message            
            }
            finally
            {
                connection.Close();
            }
            return resultaat;
        }

        public string parentMapNaam(int parentmapid)
        {
            string resultaat = "";
            string sql;
            sql = "select naam from map where mapid = :parentmapid";

            try
            {
                Connect();
                OracleCommand cmd = new OracleCommand(sql, connection);
                cmd.Parameters.Add(new OracleParameter("parentmapid", parentmapid));
                OracleDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    resultaat = Convert.ToString(reader["naam"]);
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