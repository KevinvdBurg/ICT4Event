using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
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
            tbAdres.Text = eventje.Location.Address.ToString();
        }
    }
}