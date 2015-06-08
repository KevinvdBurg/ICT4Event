using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
    using System.Windows.Forms;

    public partial class EventsWijzigen : System.Web.UI.Page
    {
        Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<Event> events = new List<Event>();
                events = administration.FindEventAll();
                foreach (Event eventje in events)
                {
                    ddlEvents.Items.Add(eventje.Name);
                }
                 /*
                ddlEvents.DataSource = null;
                ddlEvents.DataSource = administration.FindEventAll();
                ddlEvents.DataTextField = "Name";
                 */
            }
        }
        protected void btnLaadEvent_Click1(object sender, EventArgs e)
        {
            Event eventje = new Event();
            eventje = (administration.FindEvent(ddlEvents.SelectedItem.Text));
            tbNaam.Text = eventje.Name;
            tbAdres.Text = eventje.Location.Address.City.ToString();
            tbNummer.Text = eventje.EventID.ToString();
            tbBezoekers.Text = eventje.MaxPerson.ToString();
            tbHuisnummer.Text = eventje.Location.Address.Number.ToString();
            tbLocatienaam.Text = eventje.Location.Name.ToString();
            tbPostcode.Text = eventje.Location.Address.ZipCode.ToString();
            tbStad.Text = eventje.Location.Address.City.ToString();
            calDatumBegin.SelectedDate = Convert.ToDateTime(eventje.BeginTime.ToString());
            calDatumEind.SelectedDate = Convert.ToDateTime(eventje.EndTime);
        }

        protected void btnEvent_Click(object sender, EventArgs e)
        {
            if (tbNaam.Text == String.Empty && tbAdres.Text == String.Empty && tbBezoekers.Text == String.Empty
                && tbHuisnummer.Text == String.Empty && tbLocatienaam.Text == String.Empty
                && tbNummer.Text == String.Empty && tbPostcode.Text == String.Empty && tbStad.Text == String.Empty
                && calDatumBegin.SelectedDate.ToString("dd-MMMM-yy") == String.Empty && calDatumEind.SelectedDate.ToString("dd-MMMM-yy") == String.Empty)
            {
                MessageBox.Show("Alle velden moeten ingevuld zijn.");
            }
            else
            {
                Address adres = new Address(tbStad.Text, tbHuisnummer.Text, tbPostcode.Text);
                Location location = new Location(adres, tbNaam.Text);
                location.UpdateLocation(location);
                Event newEvent = new Event(
                    location,
                    Convert.ToInt32(tbBezoekers.Text),
                    tbNaam.Text,
                    Convert.ToInt32(tbNummer.Text),
                    calDatumBegin.SelectedDate.ToString("dd-MMMM-yy"),
                    calDatumEind.SelectedDate.ToString("dd-MMMM-yy"));
                administration.UpdateEvent(newEvent);
                MessageBox.Show("Het event is aangepast!");
                ddlEvents.Items.Clear();
                List<Event> events = new List<Event>();
                events = administration.FindEventAll();
                foreach (Event eventje in events)
                {
                    ddlEvents.Items.Add(eventje.Name);
                }
            }
        }
    }
}