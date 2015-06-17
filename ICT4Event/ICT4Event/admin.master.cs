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
    using System.Web.UI;

    /// <summary>
    /// The admin.
    /// </summary>
    public partial class Admin : MasterPage
    {
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