﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
    using System.Text.RegularExpressions;

    using ICT4Event.Classes;

    public partial class index : System.Web.UI.Page
    {

        private readonly Administration administration = new Administration();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

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