// --------------------------------------------------------------------------------------------------------------------
// <copyright file="inloggen.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The inloggen.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event.pages
{
    using System;
    using System.Text.RegularExpressions;
    using System.Web.UI;

    /// <summary>
    /// The inloggen.
    /// </summary>
    public partial class Inloggen : Page
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
        }

        /// <summary>
        /// The btn_inloggen_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
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
                var logincheck = this.administration.LoginCheck(username, password);
                if (logincheck == "Succes")
                {
                    this.administration.Login(username, password);
                    var detailsAccount = this.administration.GetDetails(username);

                    this.Session[MyKeys.KeyAccountId] = detailsAccount.GebruikerId;
                    this.Session[MyKeys.KeyEmail] = detailsAccount.Email;
                    this.Session[MyKeys.KeyUsername] = detailsAccount.Gebruiksersnaam;

                    this.Show("Inloggen gelukt!");
                    this.Response.Redirect("/index.aspx");
                }
                else
                {
                    this.Page.Show(logincheck);
                }
            }
        }
    }
}