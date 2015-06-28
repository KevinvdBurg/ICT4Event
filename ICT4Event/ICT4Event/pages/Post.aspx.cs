// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Post.aspx.cs" company="">
//   
// </copyright>
// <summary>
//   The post.
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
    using ICT4Event.Classes;

    /// <summary>
    /// The post.
    /// </summary>
    public partial class Post : System.Web.UI.Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private Administration ad = new Administration();

        /// <summary>
        /// The is bericht.
        /// </summary>
        private bool isBericht;

        /// <summary>
        /// The ftptj.
        /// </summary>
        private Ftpverbinding ftptj = new Ftpverbinding();

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
            // Je kan eerst kiezen uit berichten en bestanden
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
            // Eerst lb clearen
            this.lbItems.Items.Clear();
            this.tbInhoud.Visible = false;
            this.tbComments.Visible = false;
            this.btnDownload.Visible = false;

            // refill lbCategorie indien van toepassing
            /*bericht: show berichten
             * categorie: haal categorieid op
             * zoek categorienen met parentcategorieid
             */

            // Als er op berichten word geklikt laat hij gewoon berichten zien
            // Als er op bestand word geklikt worden er categorieën getoond, of bestanden zonder categorie
            this.lblMap.Text += this.lbCategorie.SelectedValue + "\\";
            string catnaam = this.lbCategorie.SelectedValue;
            foreach (string s in this.ad.CategoryFilesList(catnaam))
            {
                this.lbItems.Items.Add(this.ad.testContains(s));
            }

            this.lbCategorie.Items.Clear();
            foreach (var s in this.ad.SubCategories(catnaam))
            {
                this.lbCategorie.Items.Add(s);
            }

            foreach (var s in this.ad.CategoryMessages(catnaam))
            {
                this.lbItems.Items.Add(this.ad.testContains(s));
            }
        }

        /// <summary>
        /// The lb items_ selected index changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.tbComments.Text = string.Empty;

            if (!this.lbItems.SelectedValue.Contains("."))
            {
                this.tbInhoud.Text = this.ad.postTekst(this.lbItems.SelectedValue);
                foreach (string s in this.ad.GetComments(this.lbItems.SelectedValue))
                {
                    this.tbComments.Text += s + Environment.NewLine;
                }

                this.tbComments.Visible = true;
                this.tbInhoud.Visible = true;
                this.btnDownload.Visible = false;
            }
            else
            {
                this.tbComments.Visible = false;
                this.tbInhoud.Visible = false;
                this.btnDownload.Visible = true;
            }
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
        /// The start position.
        /// </summary>
        private void StartPosition()
        {
            this.Clear();

            foreach (var s in this.ad.MainCategories())
            {
                this.lbCategorie.Items.Add(s);
            }

            foreach (var s in this.ad.Posts())
            {
                this.lbItems.Items.Add(this.ad.testContains(s));
            }

            // lbItems.Items.Add(ad.testContains());
        }

        /// <summary>
        /// The clear.
        /// </summary>
        private void Clear()
        {
            this.tbComments.Visible = false;
            this.tbInhoud.Visible = false;
            this.btnDownload.Visible = false;
            this.lbCategorie.Items.Clear();
            this.lbItems.Items.Clear();
        }

        /// <summary>
        /// The btn new post_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnNewPost_Click(object sender, EventArgs e)
        {
            this.btnSavePost.Visible = true;
            this.tbNewTitle.Visible = true;
            this.tbNewContent.Visible = true;
            this.Label2.Visible = true;
            this.Label3.Visible = true;
        }

        /// <summary>
        /// The btn save post_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnSavePost_Click(object sender, EventArgs e)
        {
            // Kijken of een Post is geselecteerd DUS EEN REPLY
            if (this.lbItems.SelectedIndex != -1)
            {
                this.ad.InsertReply(Convert.ToInt32(this.Session[MyKeys.KeyAccountId]), this.tbNewContent.Text, this.lbItems.SelectedValue);
            }
            else
            {
                // Mainpost
                if (this.lblMap.Text == "Home\\")
                {
                    this.ad.InsertMainMessage(
                        Convert.ToInt32(this.Session[MyKeys.KeyAccountId]),
                        this.tbNewTitle.Text,
                        this.tbNewContent.Text);
                }
                //// Post in een categorie
                else
                {
                    this.ad.InsertCatMessage(
                        Convert.ToInt32(this.Session[MyKeys.KeyAccountId]),
                        this.tbNewTitle.Text,
                        this.tbNewContent.Text,
                        this.lblMap.Text);
                }
            }

            this.btnSavePost.Visible = false;
            this.tbNewTitle.Visible = false;
            this.tbNewTitle.Text = string.Empty;
            this.tbNewContent.Visible = false;
            this.tbNewContent.Text = string.Empty;
            this.Label2.Visible = false;
            this.Label3.Visible = false;
        }

        /// <summary>
        /// The btn comment_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnComment_Click(object sender, EventArgs e)
        {
            this.btnSavePost.Visible = true;
            this.tbNewContent.Visible = true;
            this.Label2.Visible = true;
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
            this.Response.Redirect("/pages/Upload.aspx");
        }

        /// <summary>
        /// The btn download_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btnDownload_Click(object sender, EventArgs e)
        {
            //this.ftptj.DownloadFtpFile(
            //    Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            //    this.lbItems.SelectedValue,
            //    this.lblMap.Text);
        }

        protected void btnLike_Click(object sender, EventArgs e)
        {
            ad.LikePost(lbItems.SelectedValue);
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            ad.ReportPost(lbItems.SelectedValue);
        }
    }
}