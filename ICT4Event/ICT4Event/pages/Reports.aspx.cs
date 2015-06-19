using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    public partial class Reports : System.Web.UI.Page
    {
        private Administration ad = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (string s in ad.ReportedPosts())
                {
                    lbPosts.Items.Add(s);
                }
            }
        }
    }
}