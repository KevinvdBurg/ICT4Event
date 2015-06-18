using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
    using System.Text.RegularExpressions;

    using ICT4Event.Classes;

    public partial class index : System.Web.UI.Page
    {

        private readonly Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnInloggenClick(object sender, EventArgs e)
        {
            var username = Regex.Replace(Convert.ToString(this.inlog_gebruikersnaam.Text), @"\s+", string.Empty);
            var password = Regex.Replace(Convert.ToString(this.inlog_wachtwoord.Text), @"\s+", string.Empty);

            if (username == string.Empty || password == string.Empty)
            {
                this.Show("vul gegevens in!");
            }
            else
            {
                if (this.administration.LoginCheck(username))
                {

                    if (this.administration.Login(username, password))
                    {
                        var detailsAccount = this.administration.GetDetails(username);

                        this.Session[MyKeys.KeyAccountId] = detailsAccount.GebruikerId;
                        this.Session[MyKeys.KeyEmail] = detailsAccount.Email;
                        this.Session[MyKeys.KeyUsername] = detailsAccount.Gebruiksersnaam;

                        this.Response.Redirect("/pages/wijziggegevens.aspx");
                    }
                    else
                    {
                        this.Page.Show("Wachtwoord incorrect");
                    }
                    
                }
                else
                {
                    this.Page.Show("Een geactiveerd account gevonden");
                }
            }
        }

        protected void btn_to_registeren_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/wijziggegevens.aspx");
        }
    }
}