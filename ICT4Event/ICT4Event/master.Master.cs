// --------------------------------------------------------------------------------------------------------------------
<<<<<<< HEAD
// <copyright file="master.Master.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
=======
// <copyright file="master.Master.cs" company="">
//   
>>>>>>> origin/Reserve
// </copyright>
// <summary>
//   The master.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
<<<<<<< HEAD
namespace ICT4Event
{
    using System;
    using System.Web.UI;

    /// <summary>
    /// The master.
    /// </summary>
    public partial class Master : MasterPage
=======



namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    /// <summary>
    /// The master.
    /// </summary>
    public partial class master : System.Web.UI.MasterPage
>>>>>>> origin/Reserve
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