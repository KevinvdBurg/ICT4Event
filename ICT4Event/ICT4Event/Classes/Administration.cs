using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    public class Administration
    {
        private DBPost db;

        public Administration()
        {
                db = new DBPost();
        }

        public List<String> MainCategories()
        {
            return db.GetMainCategories();
        }

        public List<String> SubCategories(string catnaam)
        {
            return db.GetSubCategories(db.GetCategorieID((catnaam)));
        }

        public List<String> CategoryFilesList(string catnaam)
        {
            return db.CategoryFiles(db.GetCategorieID(catnaam));
        }

        public List<String> Posts()
        {
            return db.MainMessages();
        }

        public string postTekst(string titel)
        {
            return db.GetMessage(db.GetMessageID(titel));
        }

        public List<String> GetComments(string titel)
        {
            return db.GetComments(db.GetMessageID(titel));
        }

        public string testContains(string str)
        {
            string s = "/Jij/ e/n ik/01 - Mooier dan ik dacht.mp3";
            string s2 = "hallo";
            
            /*if (s.IndexOf("/") != -1)
            {
                //s = s.Substring(s.IndexOf())
                if (s.IndexOf("/") != -1)
                {
                    return s.Substring(index);
                }
                return s;
            }*/
            while (str.IndexOf("/") != -1)
            {
                str = str.Substring(str.IndexOf("/")+1);
            }
            return str;
            

        }

        public List<String> CategoryMessages(string catnaam)
        {
            return db.CatMessages(db.GetCategorieID(catnaam));
        }

        public void InsertMainMessage(int accountid, string titel, string inhoud)
        {
            db.InsetMainMessage(accountid, titel, inhoud);
        
        
        }

        public void InsertCatMessage(int accountid, string titel, string inhoud, string catnaam)
        {
            db.InsertCatMessage(accountid, titel, inhoud, db.GetCatId(catnaam));
        }

        public void InsertReply(int accountid, string inhoud, string postTitel)
        {
            db.InsertReply(accountid, inhoud, db.GetMessageID(postTitel));
        }
    }
}