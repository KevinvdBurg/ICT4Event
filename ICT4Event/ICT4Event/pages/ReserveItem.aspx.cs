using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    using System.Windows.Forms;

    public partial class WebForm1 : System.Web.UI.Page
    {
        List<Item> items;
        Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.IsPostBack)
            {
                this.RefreshItems();
            }
            this.RefreshItems();
        }

        private void RefreshItems()
        {
            this.items = this.administration.GetFreeItemsList();
            Session["items"] = this.items;
            foreach (var item in this.items)
            {
                this.lbFreeItems.Items.Add(item.ToString());
            }
        }

        protected void btnReserve_Click(object sender, EventArgs e)
        {
            items = this.Session["items"] as List<Item>;
            if (this.administration.NewItemReservation(this.items[this.lbFreeItems.SelectedIndex]))
            {
                MessageBox.Show("Item is gereserveerd");
                // Page.Response.Redirect();
            }
            else
            {
                MessageBox.Show("Item is niet gereserveerd");

                // Page.Response.Redirect();
            }
        }
    }
}