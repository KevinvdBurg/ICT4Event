using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    
    public partial class Reserve : System.Web.UI.Page
    {
        Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var item in this.administration.FindAllFreeCampingSpots())
                {
                    this.ddlSpot.Items.Add(Convert.ToString(item.ID));
                }
            }
            this.tbInfo.Text = this.administration.FindInfoSpot(Convert.ToInt32(ddlSpot.SelectedItem.Value));
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            Person newPerson;
            if (this.tbInsertion.Text != null)
            {
                 newPerson = new Person(
                    this.tbFirstName.Text,
                    this.tbLastName.Text,
                    this.tbStreet.Text,
                    Convert.ToInt32(this.tbHouseNumber.Text),
                    this.tbCity.Text,
                    this.tbBank.Text);
            }
            else
            {
                 newPerson = new Person(
                    this.tbFirstName.Text,
                    this.tbInsertion.Text,
                    this.tbLastName.Text,
                    this.tbStreet.Text,
                    Convert.ToInt32(this.tbHouseNumber.Text),
                    this.tbCity.Text,
                    this.tbBank.Text);
            }

            int id = this.administration.NewPerson(newPerson);
            
            this.administration.NewReservation();
        }
    }
}