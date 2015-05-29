using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Item
    {
        public string Brand
        {
            get;
            set;
        }

        public string Name { get; set; }

        public CategoryItems category { get; set; }

        public Item(string Brand)
        {
            this.Brand = Brand;
        }

        public Item(CategoryItems category, string Brand, string Name)
        {
            this.Brand = Brand;
            this.Name = Name;
            this.category = category;
        }
    }
}