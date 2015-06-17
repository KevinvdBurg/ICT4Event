// --------------------------------------------------------------------------------------------------------------------
// <copyright file="registreren.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The registreren.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event.pages
{
    using System;
    using System.Web.UI;

    /// <summary>
    /// The registreren.
    /// </summary>
    public partial class Registreren : Page
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private readonly Administration administration = new Administration();

        /// <summary>
        /// The page_ load.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Page_Load(object sender, EventArgs e)
        {
            // MessageBox.Show(this, "hoi");           
        }

        /// <summary>
        /// The btn_registeren_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnRegisterenClick(object sender, EventArgs e)
        {
            var gebruikersnaam = this.regi_gebruikersnaam.Text;
            var email = this.regi_email.Text;
            var heremail = this.regi_email.Text;
            var wachtwoord = this.regi_wachtwoord.Text;
            var herwachtwoord = this.regi_wachtwoord.Text;

            if (!this.administration.FindGebruikersnaam(gebruikersnaam))
            {
                this.Show("Gebruikersnaam is al ingebruik");
            }
            else if (email != heremail || wachtwoord != herwachtwoord)
            {
                this.Show("Email of wachtwoord zijn niet correct");
            }
            else if (!this.administration.FindEmail(email))
            {
                this.Show("Email is al ingebruik");
            }
            else
            {
                var g = Guid.NewGuid();
                var guidString = Convert.ToBase64String(g.ToByteArray());
                guidString = guidString.Replace("=", string.Empty);
                guidString = guidString.Replace("+", string.Empty);

                var newAccount = new Account(gebruikersnaam, email, wachtwoord, false, guidString, false);
                this.administration.Add(newAccount);
                this.administration.SendEmail(newAccount);
                this.Show("Alles ok!?");
            }
        }

        /// <summary>
        /// The btn_actieveren_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnActieverenClick(object sender, EventArgs e)
        {
            if (this.administration.ActivateAccount(this.tbActivatiecode.Text))
            {
                this.Page.Show("Account is geactiveerd");
                this.Response.Redirect("/inloggen.aspx");
            }
            else
            {
                this.Page.Show("Activatie code is niet gevonden");
            }
        }
    }
}