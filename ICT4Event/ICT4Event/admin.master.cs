// --------------------------------------------------------------------------------------------------------------------
// <copyright file="admin.master.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The admin.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    using System.Web;
    using System.Web.UI;

    using ICT4Event.Classes;

    /// <summary>
    /// The admin.
    /// </summary>
    public partial class Admin : MasterPage
    {
        /// <summary>
        /// The administration.
        /// </summary>
        private readonly Administration administration = new Administration();
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
            string value = Session[MyKeys.KeyAccountId] + string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                string urlSting = Regex.Replace(HttpContext.Current.Request.Url.AbsolutePath, @"\s+", string.Empty);
                if (urlSting == "/index.aspx" || urlSting == "/pages/registreren.aspx")
                {
                    Response.Write("Gelijk");
                }
                else
                {
                    Response.Redirect("/index.aspx");
                }
            }
            else
            {
                List<string> groupsList =
                    this.administration.GetAccountGroups(Convert.ToString(this.Session[MyKeys.KeyUsername]));
                this.administration.GetAccountGroups(Convert.ToString(this.Session[MyKeys.KeyUsername]));
                bool admin = false;
                foreach (string group in groupsList)
                {
                    if (group == "Web-Admin")
                    {
                        admin = true;
                    }
                }

                if (admin)
                {
                    //MessageBox.Show(this.Page, "Web-Admin");
                }
                else
                {
                   // MessageBox.Show(this.Page, "Web-Gebruiker");
                    Response.Redirect("index.aspx");
                }
            }
        }

        /// <summary>
        /// The btn_ uitloggen_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void BtnUitloggenClick(object sender, EventArgs e)
        {
            this.Uitloggen();
            Response.Redirect("/index.aspx");
        }

        /// <summary>
        /// The uitloggen function.
        /// </summary>
        public void Uitloggen()
        {
            this.Session.Clear();
            this.Session.Abandon();
            this.Session.RemoveAll();
        }
    }
}