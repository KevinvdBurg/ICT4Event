using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Address
    {
        public string ZipCode
        {
            get;
            set;
        }

        public string City
        {
            get;
            set;
        }

        public string Number
        {
            get;
            set;
        }



        public Address(string City, string Number, string ZipCode)
        {
            this.City = City;
            this.Number = Number;
            this.ZipCode = ZipCode;
        }
    }
}