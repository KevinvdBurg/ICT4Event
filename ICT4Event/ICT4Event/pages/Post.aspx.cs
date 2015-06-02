using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    public partial class Post : System.Web.UI.Page
    {
        
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

            //Als er op berichten word geklikt laat hij gewoon berichten zien
            //Als er op bestand word geklikt worden er categorieën getoond, of bestanden zonder categorie
            lbItems.Items.Add("Bericht1");
            lbItems.Items.Add("Bericht2");
            
        }

        protected void lbItems_SelectedIndexChanged(object sender, EventArgs e)
        {

            tbInhoud.Text = "Inhoud van bericht1";
            tbInhoud.Visible = true;
        }
    }
}