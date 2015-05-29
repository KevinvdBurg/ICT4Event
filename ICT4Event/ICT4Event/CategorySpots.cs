using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class CategorySpots:Category
    {
        public int MaxPerson
        {
            get;
            set;
        }

        public CategorySpots(int MaxPerson, string Details, decimal Price, string Type)
            : base(Details, Price)
        {
            this.MaxPerson = MaxPerson;
        }

        public CategorySpots(int MaxPerson, string Details, decimal Price)
            : base(Details, Price)
        {
            this.MaxPerson = MaxPerson;
        }
    }
}