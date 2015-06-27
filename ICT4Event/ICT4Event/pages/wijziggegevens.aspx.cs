// --------------------------------------------------------------------------------------------------------------------
// <copyright file="registreren.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   Al het wijzigen van de gegevens wordt in deze klasse afgehandled
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event.pages
{
    using System.Text.RegularExpressions;
    using ICT4Event.Classes;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    /// <summary>
    /// 
    /// </summary>
    public partial class wijziggegevens : System.Web.UI.Page
    {
        /// <summary>
        /// Een instanitie van de administration klasse
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
            huidige_email.Text = Convert.ToString(Session[MyKeys.KeyEmail]);
        }

        /// <summary>
        /// Update account gegevens.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void Btn(object sender, EventArgs e)
        {
            string currentemail = this.huidige_email.Text;
            string email = Regex.Replace(this.wijzig_email.Text, @"\s+", string.Empty);
            string heremail = Regex.Replace(this.her_wijzig_email.Text, @"\s+", string.Empty);

            string wachtwoord = this.wijzig_wachtwoord.Text;
            string herwachtwoord = this.her_wijzig_wachtwoord.Text;

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

                if (this.administration.UpdateAccountDB(Convert.ToInt32(this.Session[MyKeys.KeyAccountId]), updateemail))
                {
                    this.Page.Show("DB - Update Gelukt");
                }

                if (this.administration.UpdateAccountAD(
                    Convert.ToString(this.Session[MyKeys.KeyUsername]), 
                    updateemail, 
                    updatewachtwoord))
                {
                    this.Page.Show("AD - Update Gelukt");
                }

                var detailsAccount = this.administration.GetDetails(Convert.ToString(this.Session[MyKeys.KeyUsername]));
                this.Session.Clear();
                this.Session.Abandon();
                this.Session.RemoveAll();
                this.Session[MyKeys.KeyUsername] = detailsAccount.Gebruiksersnaam;
                this.Session[MyKeys.KeyAccountId] = detailsAccount.GebruikerId;
                this.Session[MyKeys.KeyEmail] = detailsAccount.Email;
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                this.Page.Show("Niets is ingevuld");
            }
        }
    }
}