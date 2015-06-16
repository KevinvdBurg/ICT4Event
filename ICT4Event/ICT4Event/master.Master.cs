using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event
{
    public partial class master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void Uitloggen()
        {
            this.Session.Clear();
            this.Session.Abandon();
            this.Session.RemoveAll();
        }
    }
}