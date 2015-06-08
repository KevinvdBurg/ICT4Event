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

        protected void Page_Load(object sender, EventArgs e)
        {
            //Je kan eerst kiezen uit berichten en bestanden
            if (!IsPostBack)
            {
                lbCategorie.Items.Add("bericht");
                lbCategorie.Items.Add("bestand");
            }
            
        }

        protected void lbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Eerst lb clearen
            lbItems.Items.Clear();

            //refill lbCategorie indien van toepassing
            /*bericht: show berichten
             * categorie: haal categorieid op
             * zoek categorienen met parentcategorieid
             */

            //Als er op berichten word geklikt laat hij gewoon berichten zien
            //Als er op bestand word geklikt worden er categorieën getoond, of bestanden zonder categorie
            if (lbCategorie.SelectedValue == "bestand")
            {
                isBericht = false;
                lbCategorie.Items.Clear();
                tbInhoud.Visible = false;
                foreach (var s in ad.MainCategories())
                {
                    lbCategorie.Items.Add(s);
                }
            }
            else if (lbCategorie.SelectedValue == "bericht")
            {
                isBericht = true;
                foreach (String s in ad.Posts())
                {
                    lbItems.Items.Add((s));
                }
                lbItems.Items.Add("Bericht1");
                lbItems.Items.Add("Bericht2");
            }

            else if(lbCategorie.SelectedValue != "bestand" && lbCategorie.SelectedValue != "bericht")
            {
                isBericht = false;
                string catnaam = lbCategorie.SelectedValue;
                foreach (String s in ad.CategoryFilesList(catnaam))
                {
                    lbItems.Items.Add(s);
                }
                lbCategorie.Items.Clear();
                foreach (var s in ad.SubCategories(catnaam))
                {
                    lbCategorie.Items.Add(s);   
                }
            }
            
            
        }

        protected void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isBericht)
            {
                tbInhoud.Text = "Inhoud van bericht1";
                tbInhoud.Visible = true;  
            }
            else
            {
                btnDownload.Visible = true;
            }
            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            lbCategorie.Items.Clear();
            lbItems.Items.Clear();
            tbInhoud.Visible = false;
            btnDownload.Visible = false;
            lbCategorie.Items.Add("bericht");
            lbCategorie.Items.Add("bestand");
        }
    }
}