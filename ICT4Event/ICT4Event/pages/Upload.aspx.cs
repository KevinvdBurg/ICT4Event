// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Upload.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The upload.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using System.Windows.Forms;
    using ICT4Event.Classes;

    /// <summary>
    /// The upload.
    /// </summary>
    public partial class Upload : System.Web.UI.Page
    {
        /// <summary>
        /// The ad.
        /// </summary>
        private Administration ad = new Administration();

        /// <summary>
        /// The ftpt.
        /// </summary>
        private Ftpverbinding ftpt = new Ftpverbinding();

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
                this.StartPosition();
            }
        }

        /// <summary>
        /// The lb categorie_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void lbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.HFcategory.Value = this.lbCategorie.SelectedValue;
            this.lblMap.Text += this.lbCategorie.SelectedValue + "\\";
            string catnaam = this.lbCategorie.SelectedValue;

            this.lbCategorie.Items.Clear();
            foreach (var s in this.ad.SubCategories(catnaam))
            {
                this.lbCategorie.Items.Add(s);
            }
        }

        /// <summary>
        /// The start position.
        /// </summary>
        private void StartPosition()
        {
            this.Clear();

            foreach (var s in this.ad.MainCategories())
            {
                this.lbCategorie.Items.Add(s);
            }
        }

        /// <summary>
        /// The clear.
        /// </summary>
        private void Clear()
        {
            this.lbCategorie.Items.Clear();
        }

        /// <summary>
        /// The btn return_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.lblMap.Text = "Home\\";
            this.StartPosition();
        }

        /// <summary>
        /// The btn upload_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnUpload_Click(object sender, EventArgs e)
        {
            this.fileUpload.SaveAs(this.Server.MapPath("~/Uploads" + lblMap.Text + this.fileUpload.FileName));
            /*this.ftpt.UploadFileToFtp(
                this.lblMap.Text,
               this.Server.MapPath("~/Uploads/") + this.fileUpload.FileName, 
                "Administrator", 
                "Admin123");*/
            this.ad.InsertFile(1, this.fileUpload.FileName, this.HFcategory.Value);
        }
    }
}