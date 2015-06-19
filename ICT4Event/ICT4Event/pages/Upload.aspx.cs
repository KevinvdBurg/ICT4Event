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
    public partial class Upload : System.Web.UI.Page
    {
        private Administration ad = new Administration();
        private Ftpverbinding ftpt = new Ftpverbinding();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StartPosition();
            }
        }

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
            
            lbCategorie.Items.Clear();
            
            
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            lblMap.Text = "Home\\";
            StartPosition();
        }

        protected void btnUpload_Click(object sender, EventArgs e)
        {
            fileUpload.SaveAs(Server.MapPath("~/Uploads/" + fileUpload.FileName));
            ftpt.UploadFileToFtp(lblMap.Text, Server.MapPath("~/Uploads/") + fileUpload.FileName, "Administrator", "Admin123");
            ad.InsertFile(1, fileUpload.FileName, HFcategory.Value);

        }
    }
}