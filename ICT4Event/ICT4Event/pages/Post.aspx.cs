using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Event.Classes;

namespace ICT4Event.pages
{
    public partial class Post : System.Web.UI.Page
    {
        private Administration ad = new Administration();
        private bool isBericht;
        private Ftpverbinding ftptj = new Ftpverbinding();

        protected void Page_Load(object sender, EventArgs e)
        {
            //Je kan eerst kiezen uit berichten en bestanden
            if (!IsPostBack)
            {
                StartPosition();
            }
            
        }

        protected void lbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Eerst lb clearen
            lbItems.Items.Clear();
            tbInhoud.Visible = false;
            tbComments.Visible = false;
            btnDownload.Visible = false;
            //refill lbCategorie indien van toepassing
            /*bericht: show berichten
             * categorie: haal categorieid op
             * zoek categorienen met parentcategorieid
             */

            //Als er op berichten word geklikt laat hij gewoon berichten zien
            //Als er op bestand word geklikt worden er categorieën getoond, of bestanden zonder categorie


            lblMap.Text += lbCategorie.SelectedValue + "\\";
            string catnaam = lbCategorie.SelectedValue;
            foreach (String s in ad.CategoryFilesList(catnaam))
            {
                lbItems.Items.Add(ad.testContains(s));
            }
            lbCategorie.Items.Clear();
            foreach (var s in ad.SubCategories(catnaam))
            {
                lbCategorie.Items.Add(s);
            }
            foreach (var s in ad.CategoryMessages(catnaam))
            {
                lbItems.Items.Add(ad.testContains(s));
            }
            
            
            
        }

        protected void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbComments.Text = "";
     
            if (!lbItems.SelectedValue.Contains("."))
            {
                tbInhoud.Text = ad.postTekst(lbItems.SelectedValue);
                foreach (string s in ad.GetComments(lbItems.SelectedValue))
                {
                    tbComments.Text += s + Environment.NewLine;
                }
                
                tbComments.Visible = true;
                tbInhoud.Visible = true;
                btnDownload.Visible = false;
            }
            else
            {
                tbComments.Visible = false;
                tbInhoud.Visible = false;
                btnDownload.Visible = true;
            }
            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            lblMap.Text = "Home\\";
            StartPosition();
        }


        private void StartPosition()
        {
            Clear();

            foreach (var s in ad.MainCategories())
            {
                lbCategorie.Items.Add(s);
            }
            foreach (var s in ad.Posts())
            {
                lbItems.Items.Add(ad.testContains(s));
            }

            //lbItems.Items.Add(ad.testContains());
        }

        private void Clear()
        {
            tbComments.Visible = false;
            tbInhoud.Visible = false;
            btnDownload.Visible = false;
            lbCategorie.Items.Clear();
            lbItems.Items.Clear();
        }

        protected void btnNewPost_Click(object sender, EventArgs e)
        {
            //SME De Valkenhof 2014ftptj.UploadFileToFtp("C:\\Users\\ASUS\\Desktop\\Hoi.txt", "Administrator", "Admin123");
            btnSavePost.Visible = true;
            tbNewTitle.Visible = true;
            tbNewContent.Visible = true;
            Label2.Visible = true;
            Label3.Visible = true;
        }

        protected void btnSavePost_Click(object sender, EventArgs e)
        {
            //Kijken of een Post is geselecteerd DUS EEN REPLY
            if (lbItems.SelectedIndex != -1)
            {
                 ad.InsertReply(1, tbNewContent.Text, lbItems.SelectedValue);
                
            }
            else
            {
                //Mainpost
                if (lblMap.Text == "Home\\")
                {
                    ad.InsertMainMessage(1, tbNewTitle.Text, tbNewContent.Text);
                }
                //Post in een categorie
                else
                {
                    ad.InsertCatMessage(1,tbNewTitle.Text,tbNewContent.Text, lblMap.Text);
                }
            }
           
            btnSavePost.Visible = false;
            tbNewTitle.Visible = false;
            tbNewTitle.Text = "";
            tbNewContent.Visible = false;
            tbNewContent.Text = "";
            Label2.Visible = false;
            Label3.Visible = false;
        }

        protected void btnComment_Click(object sender, EventArgs e)
        {
            btnSavePost.Visible = true;
            tbNewContent.Visible = true;
            Label2.Visible = true;
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/Upload.aspx");
        }

        protected void btnDownload_Click(object sender, EventArgs e)
        {
            ftptj.DownloadFtpFile(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), lbItems.SelectedValue, lblMap.Text);
        }
    }
}