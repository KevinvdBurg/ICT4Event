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
    }
}