using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Reserve
    {
        public Reserve(Person person, DateTime dateIn, DateTime dateOut, double price)
        {
            this.Person = person;
            this.DateIn = dateIn;
            this.DateOut = dateOut;
            this.Price = price;
        }

        public Reserve(int ID, Person person, DateTime dateIn, DateTime dateOut, double price)
        {
            this.ReserveID = ID;
            this.Person = person;
            this.DateIn = dateIn;
            this.DateOut = dateOut;
            this.Price = price;
        }

        public int ReserveID { get; set; }

        public Person Person { get; set; }

        public DateTime DateIn { get; set; }

        public DateTime DateOut { get; set; }

        public double Price { get; set; }

    }
}