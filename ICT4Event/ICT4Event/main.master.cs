// --------------------------------------------------------------------------------------------------------------------
// <copyright file="main.master.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The main.
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
    /// The main.
    /// </summary>
    public partial class Main : MasterPage
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
                    this.administration.GetAccountGroups(Convert.ToString(Session[MyKeys.KeyUsername]));
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
                    this.admin_opties.Text = "<li class=\"sub-flex-item\"><a href=\"/pages/Toegang.aspx\">Admin</a></li'>";
                }
                else
                {
                    // MessageBox.Show(this.Page, "Web-Gebruiker");
                    //this.Page.Show(
                    //    this.Session[MyKeys.KeyUsername] + " - " + this.Session[MyKeys.KeyEmail] + " - "
                    //    + this.Session[MyKeys.KeyAccountId]);

                    // Response.Redirect("to user page");
                }

                this.btn_inuitlog.Text = "Uitloggen";
            }
        }

        /// <summary>
        /// The btn_inuitlog_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        protected void btn_inuitlog_Click(object sender, EventArgs e)
        {
            string value = Session[MyKeys.KeyAccountId] + string.Empty;
            if (string.IsNullOrEmpty(value))
            {
                Response.Redirect("/index.aspx");
            }
            else
            {
                this.Uitloggen();
                Response.Redirect("index.aspx");
            }
        }

        /// <summary>
        /// The uitloggen.
        /// </summary>
        public void Uitloggen()
        {
            this.Session.Clear();
            this.Session.Abandon();
            this.Session.RemoveAll();
        }
    }
}