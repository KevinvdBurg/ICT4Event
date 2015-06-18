// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Address.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The address.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    /// <summary>
    /// The address.
    /// </summary>
    public class Address
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="City">
        /// The city.
        /// </param>
        /// <param name="Number">
        /// The number.
        /// </param>
        /// <param name="ZipCode">
        /// The zip code.
        /// </param>
        /// <param name="Street">
        /// The street.
        /// </param>
        public Address(string City, string Number, string ZipCode, string Street)
        {
            this.City = City;
            this.Number = Number;
            this.ZipCode = ZipCode;
            this.Street = Street;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Address"/> class.
        /// </summary>
        /// <param name="City">
        /// The city.
        /// </param>
        /// <param name="Number">
        /// The number.
        /// </param>
        /// <param name="ZipCode">
        /// The zip code.
        /// </param>
        public Address(string City, string Number, string ZipCode)
        {
            this.City = City;
            this.Number = Number;
            this.ZipCode = ZipCode;
        }

        /// <summary>
        /// Gets or sets the zip code.
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the number.
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        public string Street { get; set; }
    }
}