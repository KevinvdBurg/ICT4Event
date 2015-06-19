// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Person.cs" company="">
//   
// </copyright>
// <summary>
//   The person.
// </summary>
// --------------------------------------------------------------------------------------------------------------------


namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    /// <summary>
    /// The person.
    /// </summary>
    public class Person
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="insertion">
        /// The insertion.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="street">
        /// The street.
        /// </param>
        /// <param name="houseNumber">
        /// The house number.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="bankNumber">
        /// The bank number.
        /// </param>
        public Person(string firstName, string insertion, string lastName, string street, string houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.Insertion = insertion;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Person"/> class.
        /// </summary>
        /// <param name="firstName">
        /// The first name.
        /// </param>
        /// <param name="lastName">
        /// The last name.
        /// </param>
        /// <param name="street">
        /// The street.
        /// </param>
        /// <param name="houseNumber">
        /// The house number.
        /// </param>
        /// <param name="city">
        /// The city.
        /// </param>
        /// <param name="bankNumber">
        /// The bank number.
        /// </param>
        public Person(string firstName, string lastName, string street, string houseNumber, string city, string bankNumber)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Street = street;
            this.HouseNumber = houseNumber;
            this.City = city;
            this.Banknumber = bankNumber;
        }

        /// <summary>
        /// Gets or sets the person id.
        /// </summary>
        public int PersonID { get; set; }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the insertion.
        /// </summary>
        public string Insertion { get; set; }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the house number.
        /// </summary>
        public string HouseNumber { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the banknumber.
        /// </summary>
        public string Banknumber { get; set; }
    }
}