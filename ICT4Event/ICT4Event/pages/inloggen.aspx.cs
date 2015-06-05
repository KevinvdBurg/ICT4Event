using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    using System.Text.RegularExpressions;

    public partial class inloggen : System.Web.UI.Page
    {
        private Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_inloggen_Click(object sender, EventArgs e)
        {
            string username = Regex.Replace(Convert.ToString(inlog_gebruikersnaam.Text), @"\s+", "");
            string password = Regex.Replace(Convert.ToString(inlog_wachtwoord.Text), @"\s+", "");

            if (username == "" || password == "")
            {
                MessageBox.Show(this, "vul gegevens in!");   
            }
            else
            {
                this.administration.Login(username, password);
            }
            
        }
    }
}