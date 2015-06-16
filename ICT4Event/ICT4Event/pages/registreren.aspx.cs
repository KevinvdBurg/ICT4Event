using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    public partial class registreren : System.Web.UI.Page
    {
        private Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(this, "hoi");           
        }

        protected void btn_registeren_Click(object sender, EventArgs e)
        {
            string gebruikersnaam = regi_gebruikersnaam.Text;
            string email = regi_email.Text;
            string heremail = regi_email.Text;
            string wachtwoord = regi_wachtwoord.Text;
            string herwachtwoord = regi_wachtwoord.Text;

            //bool suc = administration.FindGebruikersnaam(gebruikersnaam);
            //if (!suc)
            //{
            //    MessageBox.Show(this, "Gebruikersnaam is al ingebruik");
            //}
            //else if (email != heremail|| wachtwoord != herwachtwoord)
            //{
            //    MessageBox.Show(this, "Email of wachtwoord zijn niet correct");
            //}
            //else
            //{
                Guid g = Guid.NewGuid();
                string GuidString = Convert.ToBase64String(g.ToByteArray());
                GuidString = GuidString.Replace("=", "");
                GuidString = GuidString.Replace("+", "");

                Account newAccount = new Account(gebruikersnaam, email, wachtwoord, false, GuidString, false);
                //this.administration.Add(newAccount);
                this.administration.SendEmail(newAccount);
                
                MessageBox.Show(this, "Alles ok!?");
            //}
        }

        protected void btn_actieveren_Click(object sender, EventArgs e)
        {

        }
    }  
}