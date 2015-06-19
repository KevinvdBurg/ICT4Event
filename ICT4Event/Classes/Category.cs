using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Category
    {
        public string MediaKind
        {
            get;
            set;
        }
        public string Type
        {
            get;
            set;
        }

        public decimal Price
        {
            get;
            set;
        }

        public string Details
        {
            get;
            set;
        }


        public Category(string Type, string MediaKind)
        {
            this.Type = Type;
            this.MediaKind = MediaKind;
        }
        public Category(string Details, decimal Price)
        {
            this.Price = Price;
            this.Details = Details;
        }
    }
}