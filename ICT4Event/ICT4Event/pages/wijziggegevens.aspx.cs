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

        protected void btn(object sender, EventArgs e)
        {
            string currentemail = huidige_email.Text;
            string email = Regex.Replace(wijzig_email.Text, @"\s+", "");
            string heremail = Regex.Replace(her_wijzig_email.Text, @"\s+", "");

            string wachtwoord = wijzig_wachtwoord.Text;
            string herwachtwoord = her_wijzig_wachtwoord.Text;

            string updateemail = currentemail;

            string updatewachtwoord = wachtwoord;

            if (email != "" || wachtwoord != "")
            {
                if (email != "" && administration.IsValid(email) && email == heremail)
                {
                    updateemail = email;
                }
                else
                {
                    this.Page.Show("Email komt niet overeen of is niet valide");
                }
                    
                if (wachtwoord != "" && wachtwoord == herwachtwoord && wachtwoord.Length > 5)
                {
                    updatewachtwoord = wachtwoord;
                }
                else
                {
                    this.Page.Show("Wachtwoord is niet complex genoeg of komen niet overeen");
                }

                bool AD = administration.UpdateAccountAD(Convert.ToString(Session[MyKeys.KeyUsername]), email, wachtwoord);
                bool DB = administration.UpdateAccountDB(Convert.ToInt32(MyKeys.KeyAccountId), email);
            }
            else
            {
                this.Page.Show("Niets is ingevultd");
            }
            
        }
    }
}