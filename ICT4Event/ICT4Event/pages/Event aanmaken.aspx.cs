using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
    using System.Windows.Forms;

    public partial class Event_aanmaken : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        Administration administration = new Administration();
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
                location.AddLocation(location);
                Event newEvent = new Event(
                    location,
                    Convert.ToInt32(tbBezoekers.Text),
                    tbNaam.Text,
                    Convert.ToInt32(tbNummer.Text),
                    calDatumBegin.SelectedDate.ToString("dd-MMMM-yy"),
                    calDatumEind.SelectedDate.ToString("dd-MMMM-yy"));
                administration.AddEvent(newEvent);
                MessageBox.Show("Het event is aangemaakt!");
            }
        }

        protected void btnLaadEvent_Click1(object sender, EventArgs e)
        {

        }
    }
}