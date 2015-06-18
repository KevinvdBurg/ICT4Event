using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ICT4Event.Classes;

namespace ICT4Event
{
    public partial class Upload : System.Web.UI.Page
    {
        private Administration ad = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StartPosition();
            }
        }

        protected void lbCategorie_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMap.Text += lbCategorie.SelectedValue + "\\";
            string catnaam = lbCategorie.SelectedValue;
           
            lbCategorie.Items.Clear();
            foreach (var s in ad.SubCategories(catnaam))
            {
                lbCategorie.Items.Add(s);
            }
            
        }

        private void StartPosition()
        {
            Clear();

            foreach (var s in ad.MainCategories())
            {
                lbCategorie.Items.Add(s);
            }
            

            
        }

        private void Clear()
        {
            /*tbComments.Visible = false;
            tbInhoud.Visible = false;
            btnDownload.Visible = false;
            lbCategorie.Items.Clear();
            lbItems.Items.Clear();
            */
        }
    }
}