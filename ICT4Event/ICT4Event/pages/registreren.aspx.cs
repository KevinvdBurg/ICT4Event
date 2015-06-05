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
            string email = regi_gebruikersnaam.Text;
            string heremail = regi_gebruikersnaam.Text;
            string wachtwoord = regi_gebruikersnaam.Text;
            string herwachtwoord = regi_gebruikersnaam.Text;

            bool suc = administration.FindGebruikersnaam(gebruikersnaam);
            if (!suc)
            {
                MessageBox.Show(this, "Gebruikersnaam is al ingebruik");
            }
            else if (email != heremail|| wachtwoord != herwachtwoord)
            {
                MessageBox.Show(this, "Email of wachtwoord zijn niet correct");
            }
            else
            {

                Account newAccount = new Account(gebruikersnaam, email, wachtwoord, false, this.GetHashCode(), false);
                this.administration.Add(newAccount);
                MessageBox.Show(this, "Alles ok!");
            }
        }

        protected void btn_actieveren_Click(object sender, EventArgs e)
        {

        }
    }  
}