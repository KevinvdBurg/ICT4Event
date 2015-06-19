// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Messagebox.cs" company="">
//   
// </copyright>
// <summary>
//   The message box.
// </summary>
// --------------------------------------------------------------------------------------------------------------------



using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    using System.Web.UI;

    /// <summary>
    /// The message box.
    /// </summary>
    public static class MessageBox
    {
        /// <summary>
        /// The show.
        /// </summary>
        /// <param name="page">
        /// The page.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public static void Show(this Page page, string message)
        {
            page.ClientScript.RegisterStartupScript(
                page.GetType(), 
                "MessageBox", 
                "<script language='javascript'>alert('" + message + "');</script>");
        }
    }
}