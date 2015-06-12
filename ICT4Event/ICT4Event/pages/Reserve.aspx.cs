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
                foreach (var item in administration.FindAllFreeCampingSpots())
                {
                    ddlSpot.Items.Add(Convert.ToString(item.ID));
                }
            }
            tbInfo.Text = administration.FindInfoSpot(Convert.ToInt32(ddlSpot.SelectedItem.Value));
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            if (tbInsertion != null)
            {
                Person newPerson = new Person(
                    tbFirstName.Text,
                    tbLastName.Text,
                    tbStreet.Text,
                    Convert.ToInt32(tbHouseNumber.Text),
                    tbCity.Text,
                    tbBank.Text);
            }
            else
            {
                Person newPerson = new Person(
                    tbFirstName.Text,
                    tbInsertion.Text,
                    tbLastName.Text,
                    tbStreet.Text,
                    Convert.ToInt32(tbHouseNumber.Text),
                    tbCity.Text,
                    tbBank.Text);
            }

        }
    }
}