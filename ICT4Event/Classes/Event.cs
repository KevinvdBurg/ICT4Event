// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The event.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    /// <summary>
    /// The event.
    /// </summary>
    public class Event
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        /// <param name="Location">
        /// The location.
        /// </param>
        /// <param name="MaxPerson">
        /// The max person.
        /// </param>
        /// <param name="Name">
        /// The name.
        /// </param>
        /// <param name="EventID">
        /// The event id.
        /// </param>
        /// <param name="BeginTime">
        /// The begin time.
        /// </param>
        /// <param name="EndTime">
        /// The end time.
        /// </param>
        public Event(Location Location, int MaxPerson, string Name, int EventID, string BeginTime, string EndTime)
        {
            this.Location = Location;
            this.MaxPerson = MaxPerson;
            this.Name = Name;
            this.EventID = EventID;
            this.BeginTime = BeginTime;
            this.EndTime = EndTime;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Event"/> class.
        /// </summary>
        public Event()
        {
        }

        /// <summary>
        /// Gets or sets the max person.
        /// </summary>
        public int MaxPerson { get; set; }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        public Location Location { get; set; }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the event id.
        /// </summary>
        public int EventID { get; set; }

        /// <summary>
        /// Gets or sets the begin time.
        /// </summary>
        public string BeginTime { get; set; }

        /// <summary>
        /// Gets or sets the end time.
        /// </summary>
        public string EndTime { get; set; }
    }
}