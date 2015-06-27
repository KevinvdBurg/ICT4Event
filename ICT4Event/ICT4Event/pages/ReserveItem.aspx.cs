// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ReserveItem.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The web form 1.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event.pages
{
    using System.Windows.Forms;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using ICT4Event.Classes;
    /// <summary>
    /// The web form 1.
    /// </summary>
    public partial class WebForm1 : System.Web.UI.Page
    {
        /// <summary>
        /// The items.
        /// </summary>
        List<Item> items;

        /// <summary>
        /// The administration.
        /// </summary>
        Administration administration = new Administration();

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
            if (!this.IsPostBack)
            {
                this.RefreshItems();
            }

            this.RefreshItems();
        }

        /// <summary>
        /// Reserveer een item.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnReserve_Click(object sender, EventArgs e)
        {
            this.items = this.Session["items"] as List<Item>;
            if (this.administration.NewItemReservation(this.items[this.lbFreeItems.SelectedIndex + 1]))
            {
                this.Page.Show("Item is gereserveerd");
            }
            else
            {
                this.Page.Show("Item is niet gereserveerd");
            }
        }

        /// <summary>
        /// Refresh de listboxes.
        /// </summary>
        private void RefreshItems()
        {
            lbFreeItems.Items.Clear();
            this.items = this.administration.GetFreeItemsList();
            this.Session["items"] = this.items;
            foreach (var item in this.items)
            {
                this.lbFreeItems.Items.Add(item.ToString());
            }
        }
    }
}