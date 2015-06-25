// --------------------------------------------------------------------------------------------------------------------
// <copyright file="registreren.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   In deze klasse worden alle registaties afgehandeld.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event.pages
{
    using System;
    using System.Web.UI;

    using ICT4Event.Classes;

    /// <summary>
    /// De registeer klasse
    /// </summary>
    public partial class Registreren : Page
    {
        /// <summary>
        /// Een instanitie van de administration klasse
        /// </summary>
        private readonly Administration administration = new Administration();

        /// <summary>
        /// Als er op de button is geklikt wordt deze method aangeroepen
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btn_registeren_Click(object sender, EventArgs e)
        {
            
        }

        /// <summary>
        /// Bij het klikken op deze knop word er gecontroleerd of de activatie code bestaat en of hij geactiveerd kan worden.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnActieverenClick(object sender, EventArgs e)
        {
           
        }


        protected void btn_actieveren_Click(object sender, EventArgs e)
        {
            // Controleerd of het activatie bestaat
            if (this.administration.ActivateAccount(this.tbActivatiecode.Text))
            {
                this.Page.Show("Account is geactiveerd");
                this.Response.Redirect("/index.aspx");
            }
            else
            {
                this.Page.Show("Activatie code is niet gevonden");
            }
        }

        protected void btn_registeren_Click1(object sender, EventArgs e)
        {
            var gebruikersnaam = this.regi_gebruikersnaam.Text;
            var email = this.regi_email.Text;
            var heremail = this.regi_email.Text;
            var wachtwoord = this.regi_wachtwoord.Text;
            var herwachtwoord = this.regi_wachtwoord.Text;

            // Controleert of het gebruikersnaam al is gebruikt
            if (!this.administration.FindGebruikersnaam(gebruikersnaam))
            {
                this.Show("Gebruikersnaam is al ingebruik");
            }

            // wordt gecontroleerd of de email valide is en of de emails gelijk zijn
            else if (email != heremail || !this.administration.IsValid(email))
            {
                this.Show("Email is incorrect");
            }

            // Controleerd of het wachtwoord overeenkomt en of het wachtwoord groter is dan 5
            else if (wachtwoord != herwachtwoord || wachtwoord.Length < 5)
            {
                this.Show("Wachtwoord is incorrect");
            }

            // Controleerd of het email al is gebruikt
            else if (!this.administration.FindEmail(email))
            {
                this.Show("Email is al ingebruik");
            }
            else
            {
                // Maakt een nieuwe Hash aan, voor het activeren van het account
                var g = Guid.NewGuid();
                var guidString = Convert.ToBase64String(g.ToByteArray());
                guidString = guidString.Replace("=", string.Empty);
                guidString = guidString.Replace("+", string.Empty);

                // Maakt een nieuw account aan
                var newAccount = new Account(gebruikersnaam, email, wachtwoord, false, guidString, false);
                this.administration.Add(newAccount);
                this.administration.SendEmail(newAccount);
                this.Show("Account is aangemaakt, Controleer uw email");
            }
        }
    }
}