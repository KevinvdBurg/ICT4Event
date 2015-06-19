// --------------------------------------------------------------------------------------------------------------------
// <copyright file="index.aspx.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The index
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Text.RegularExpressions;
    using ICT4Event.Classes;
    using System.Text.RegularExpressions;
    using ICT4Event.Classes;
    using System.Web.UI;

    /// <summary>
    /// The index
    /// </summary>
    public partial class Index : Page
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
        /// The btn inloggen click.
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

        /// <summary>
        /// The btn_to_registeren_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btn_to_registeren_Click(object sender, EventArgs e)
        {
            Response.Redirect("/pages/registreren.aspx");
        }
    }
}