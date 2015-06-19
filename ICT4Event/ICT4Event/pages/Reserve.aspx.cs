// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Reserve.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The reserve.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



namespace ICT4Event.pages
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    /// <summary>
    /// The reserve.
    /// </summary>
    public partial class Reserve : System.Web.UI.Page
    {
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
                foreach (var item in this.administration.FindAllFreeCampingSpots())
                {
                    this.ddlSpot.Items.Add(Convert.ToString(item.ID));
                }
            }
            
            // this.tbInfo.Text = this.administration.FindInfoSpot(Convert.ToInt32(ddlSpot.SelectedItem.Value));
        }

        /// <summary>
        /// The btn reserve_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnReserve_Click(object sender, EventArgs e)
        {
            Person newPerson;
            if (this.tbInsertion.Text != null)
            {
                 newPerson = new Person(
                    this.tbFirstName.Text, 
                    this.tbInsertion.Text, 
                    this.tbLastName.Text, 
                    this.tbStreet.Text, 
                    this.tbHouseNumber.Text, 
                    this.tbCity.Text, 
                    this.tbBank.Text);
            }
            else
            {
                 newPerson = new Person(
                    this.tbFirstName.Text, 
                    this.tbLastName.Text, 
                    this.tbStreet.Text, 
                    this.tbHouseNumber.Text, 
                    this.tbCity.Text, 
                    this.tbBank.Text);
            }

            newPerson.PersonID = this.administration.NewPerson(newPerson);
            
            this.administration.NewReservation(newPerson, this.ddlSpot.SelectedValue.ToString());


        }

        /// <summary>
        /// The btn specificaties_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnSpecificaties_Click(object sender, EventArgs e)
        {
            this.lbSpecificaties.Items.Clear();
            List<string> specificatieList = this.administration.GetSpecificationsList(Convert.ToInt32(this.ddlSpot.SelectedItem.Value));
            foreach (string item in specificatieList)
            {
                this.lbSpecificaties.Items.Add(item);
            }
        }
    }
}