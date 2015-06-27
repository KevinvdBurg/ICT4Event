// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Event aanmaken.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The event_aanmaken.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Web.UI;
    using System.Windows.Forms;

    /// <summary>
    /// The Event_aanmaken.
    /// </summary>
    public partial class Event_aanmaken : Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private readonly Administration administration = new Administration();

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this.tbNummer.Text = (this.administration.GetHoogsteEventID() + 1).ToString();
        }

        /// <summary>
        /// The btn event_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnEvent_Click(object sender, EventArgs e)
        {
            ////Checken of alles in is gevuld.
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
                //// Maak een nieuw adres aan en Event en vul ze in de DB.
                var adres = new Address(
                    this.tbStad.Text, 
                    this.tbHuisnummer.Text, 
                    this.tbPostcode.Text, 
                    this.tbAdres.Text);
                var location = new Location(adres, this.tbLocatienaam.Text);
                this.administration.AddLocation(location);
                var newEvent = new Event(
                    location, 
                    Convert.ToInt32(this.tbBezoekers.Text), 
                    this.tbNaam.Text, 
                    Convert.ToInt32(this.tbNummer.Text), 
                    this.calDatumBegin.SelectedDate.ToString("dd-MMMM-yy"), 
                    this.calDatumEind.SelectedDate.ToString("dd-MMMM-yy"));
                this.administration.AddEvent(newEvent);
                Classes.MessageBox.Show(this.Page, "Het event is aangemaakt!");
            }
        }
    }
}