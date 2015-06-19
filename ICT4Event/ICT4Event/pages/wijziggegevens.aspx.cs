using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    using System.Text.RegularExpressions;

    using ICT4Event.Classes;

    public partial class wijziggegevens : System.Web.UI.Page
    {
        private readonly Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            huidige_email.Text = Convert.ToString(Session[MyKeys.KeyEmail]);


        }

        protected void Btn(object sender, EventArgs e)
        {
            string currentemail = this.huidige_email.Text;
            string email = Regex.Replace(this.wijzig_email.Text, @"\s+", string.Empty);
            string heremail = Regex.Replace(this.her_wijzig_email.Text, @"\s+", string.Empty);

            string wachtwoord = wijzig_wachtwoord.Text;
            string herwachtwoord = her_wijzig_wachtwoord.Text;

            string updateemail = currentemail;

            string updatewachtwoord = wachtwoord;

            if (email != string.Empty || wachtwoord != string.Empty)
            {
                if (this.administration.IsValid(email) && email == heremail)
                {
                    updateemail = email;
                }
                else
                {
                    this.Page.Show("Email komt niet overeen of is niet valide");
                    return;
                }
                    
                if (wachtwoord == herwachtwoord && wachtwoord.Length > 5)
                {
                    updatewachtwoord = wachtwoord;
                }
                else
                {
                    this.Page.Show("Wachtwoord is niet complex genoeg of komen niet overeen");
                    return;
                }
                if (this.administration.UpdateAccountDB(Convert.ToInt32(Session[MyKeys.KeyAccountId]), updateemail))
                {
                    this.Page.Show("DB Gelukt");
                }
                if (this.administration.UpdateAccountAD(Convert.ToString(Session[MyKeys.KeyUsername]), updateemail, updatewachtwoord))
                {
                    this.Page.Show("AD Gelukt");
                }

                var detailsAccount = this.administration.GetDetails(Convert.ToString(Session[MyKeys.KeyUsername]));
                this.Session[MyKeys.KeyAccountId] = detailsAccount.GebruikerId;
                this.Session[MyKeys.KeyEmail] = detailsAccount.Email;
                
            }
            else
            {
                this.Page.Show("Niets is ingevultd");
            }
            
        }
    }
}