// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EventsWijzigen.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The events wijzigen.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Web.UI;
    using System.Windows.Forms;

    /// <summary>
    /// The events wijzigen.
    /// </summary>
    public partial class EventsWijzigen : Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private readonly Administration administration = new Administration();

        /// <summary>
        /// Dropdownlist vullen met events uit de DB.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                var events = new List<Event>();
                events = this.administration.FindEventAll();
                foreach (var eventje in events)
                {
                    this.ddlEvents.Items.Add(eventje.Name);
                }
            }
        }

        /// <summary>
        /// Vul de textboxen met informatie uit de DB.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnLaadEvent_Click1(object sender, EventArgs e)
        {
            var eventje = new Event();
            eventje = this.administration.FindEvent(this.ddlEvents.SelectedItem.Text);
            this.tbNaam.Text = eventje.Name;
            this.tbAdres.Text = eventje.Location.Address.Street;
            this.tbNummer.Text = eventje.EventID.ToString();
            this.tbBezoekers.Text = eventje.MaxPerson.ToString();
            this.tbHuisnummer.Text = eventje.Location.Address.Number;
            this.tbLocatienaam.Text = eventje.Location.Name;
            this.tbPostcode.Text = eventje.Location.Address.ZipCode;
            this.tbStad.Text = eventje.Location.Address.City;
            this.calDatumBegin.SelectedDate = Convert.ToDateTime(eventje.BeginTime);
            this.calDatumEind.SelectedDate = Convert.ToDateTime(eventje.EndTime);
        }

        /// <summary>
        /// Update het event in de DB met de ingevulde informatie..
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnEvent_Click(object sender, EventArgs e)
        {
            if (this.tbNaam.Text == string.Empty && this.tbAdres.Text == string.Empty
                && this.tbBezoekers.Text == string.Empty && this.tbHuisnummer.Text == string.Empty
                && this.tbLocatienaam.Text == string.Empty && this.tbNummer.Text == string.Empty
                && this.tbPostcode.Text == string.Empty && this.tbStad.Text == string.Empty
                && this.calDatumBegin.SelectedDate.ToString("dd-MMMM-yy") == string.Empty
                && this.calDatumEind.SelectedDate.ToString("dd-MMMM-yy") == string.Empty)
            {
                Classes.MessageBox.Show(this.Page, "Alle velden moeten ingevuld zijn.");
            }
            else
            {
                var adres = new Address(
                    this.tbStad.Text, 
                    this.tbHuisnummer.Text, 
                    this.tbPostcode.Text, 
                    this.tbAdres.Text);
                var location = new Location(adres, this.tbLocatienaam.Text);
                this.administration.UpdateLocation(location);
                var newEvent = new Event(
                    location, 
                    Convert.ToInt32(this.tbBezoekers.Text), 
                    this.tbNaam.Text, 
                    Convert.ToInt32(this.tbNummer.Text), 
                    this.calDatumBegin.SelectedDate.ToString("dd-MMMM-yy"), 
                    this.calDatumEind.SelectedDate.ToString("dd-MMMM-yy"));
                this.administration.UpdateEvent(newEvent);
                Classes.MessageBox.Show(this.Page, "Het event is aangepast!");
                this.ddlEvents.Items.Clear();
                var events = new List<Event>();
                events = this.administration.FindEventAll();
                foreach (var eventje in events)
                {
                    this.ddlEvents.Items.Add(eventje.Name);
                }
            }
        }
    }
}