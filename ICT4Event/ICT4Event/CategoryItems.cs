using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class CategoryItems:Category
    {
        public string Name
        {
            get;
            set;
        }

        public CategoryItems(string Name, string Details, decimal Price, string Type)
            : base(Details, Price)
        {
            this.Name = Name;
        }

        public CategoryItems(string Name, string Details, decimal Price)
            : base(Details, Price)
        {
            this.Name = Name;
        }
    }
}