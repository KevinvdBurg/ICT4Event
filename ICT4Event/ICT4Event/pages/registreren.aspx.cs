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
            MessageBox.Show(this, "hoi");           
        }

        protected void btn_registeren_Click(object sender, EventArgs e)
        {
            string gebruikersnaam = regi_gebruikersnaam.Text;
            string email = regi_gebruikersnaam.Text;
            string heremail = regi_gebruikersnaam.Text;
            string wachtwoord = regi_gebruikersnaam.Text;
            string herwachtwoord = regi_gebruikersnaam.Text;

            bool suc = administration.FindGebruikersnaam();
            if ()
            {
                
            }
            else if (email != heremail|| this.regi_wachtwoord.Text != this.regi_herwachtwoord.Text)
            {
                MessageBox.Show(this, "er is iets foute gedaan");
            }
            else
            {

            }
        }

        protected void btn_actieveren_Click(object sender, EventArgs e)
        {

        }

        
    }
   
}