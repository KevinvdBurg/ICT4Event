using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Person
    {
        public Person(string firstName, string insertion, string lastName, string street, int houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.Insertion = insertion;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
        }

        public Person(string firstName, string lastName, string street, int houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
        }

        public Person(int personID, string firstName, string insertion, string lastName, string street, int houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.Insertion = insertion;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
            this.PersonID = personID;
        }

        public Person(int personID, string firstName, string lastName, string street, int houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
            this.PersonID = personID;
        }

        public int PersonID { get; set; }

        public string FirstName { get; set; }

        public string Insertion { get; set; }

        public string LastName { get; set; }

        public string Street { get; set; }

        public int HouseNumber { get; set; }

        public string City { get; set; }

        public string Banknumber { get; set; }
    }
}