// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Upload.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The upload.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

using ICT4Event.Classes;

namespace ICT4Event
{
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
            if (!IsPostBack)
            {
                StartPosition();
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
            HFcategory.Value = lbCategorie.SelectedValue;
            lblMap.Text += lbCategorie.SelectedValue + "\\";
            string catnaam = lbCategorie.SelectedValue;

            lbCategorie.Items.Clear();
            foreach (var s in ad.SubCategories(catnaam))
            {
                lbCategorie.Items.Add(s);
            }
        }

        /// <summary>
        /// The start position.
        /// </summary>
        private void StartPosition()
        {
            Clear();

            foreach (var s in ad.MainCategories())
            {
                lbCategorie.Items.Add(s);
            }
        }

        /// <summary>
        /// The clear.
        /// </summary>
        private void Clear()
        {
            lbCategorie.Items.Clear();
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
            lblMap.Text = "Home\\";
            StartPosition();
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
            fileUpload.SaveAs(Server.MapPath("~/Uploads/" + fileUpload.FileName));
            ftpt.UploadFileToFtp(
                lblMap.Text, 
                Server.MapPath("~/Uploads/") + fileUpload.FileName, 
                "Administrator", 
                "Admin123");
            ad.InsertFile(1, fileUpload.FileName, HFcategory.Value);
        }
    }
}