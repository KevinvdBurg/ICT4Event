using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Location
    {
        DBAddress dbAddress = new DBAddress();
        public Address Address
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }



        public Location(Address Address, string Name)
        {
            this.Address = Address;
            this.Name = Name;
        }

        public void UpdateLocation(Location location)
        {
            dbAddress.Update(location);
        }
        public void AddLocation(Location location)
        {
            dbAddress.Insert(location);
        }

        public void DeleteAddress(Address address)
        {
            dbAddress.Delete(address);
        }

        public void FindAddress(string zipcode, string housenumber)
        {
            dbAddress.Select(zipcode, housenumber);
        }

    }
}