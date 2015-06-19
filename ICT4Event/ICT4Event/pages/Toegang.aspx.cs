using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ICT4Event.pages
{
    public partial class Toegang : System.Web.UI.Page
    {
        private Administration ad = new Administration();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnApply_Click(object sender, EventArgs e)
        {
            ad.InsertResPolsband(Convert.ToInt32(tbResId.Text), tbUsername.Text, tbPolsbandje.Text);
            ad.SetPolsbandActive(tbPolsbandje.Text);
        }

        protected void btnPaid_Click(object sender, EventArgs e)
        {
            if (ad.ResPaymentStatus(Convert.ToInt32(tbResId.Text)) == 1)
            {
                lblBetaald.Text = "Betaald";
                lblBetaald.ForeColor = System.Drawing.Color.GreenYellow;
            }
            else
            {
                lblBetaald.Text = "Niet betaald";
                lblBetaald.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void btnPay_Click(object sender, EventArgs e)
        {
            ad.SetResBetaald(Convert.ToInt32(tbResId.Text));
            lblBetaald.Text = "Betaald";
            lblBetaald.ForeColor = System.Drawing.Color.GreenYellow;
        }

        protected void btnCheckOut_Click(object sender, EventArgs e)
        {
            ad.ResCheckOut(tbBarcode.Text);
        }
    }
}