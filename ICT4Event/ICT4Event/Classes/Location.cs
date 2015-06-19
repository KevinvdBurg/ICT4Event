// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Location.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The location.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    /// <summary>
    /// The location.
    /// </summary>
    public class Location
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="Address">
        /// The address.
        /// </param>
        /// <param name="Name">
        /// The name.
        /// </param>
        public Location(Address Address, string Name)
        {
            this.Address = Address;
            this.Name = Name;
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        public Address Address { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        
    }
}