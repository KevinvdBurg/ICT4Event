using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Web.UI;
    using System.Windows.Forms;

    public class Administration
    {
        private Database DB = new Database();
        private DBLogin dblogin = new DBLogin();
        private DBAccount dbaccount = new DBAccount();
       

        public Administration()
        {

        }

        /// <summary>
        /// set the current account to the given email
        /// Zet de account.email gelijk aan het gegeven email
        /// </summary>
        /// <param name="email"></param>

        //public void setCurrentAccount(string email)
        //{
        //    this.currentAccount = dblogin.returnLoggedinAccount(email);
        //}

        /// <summary>
        /// Een Account wordt doorgestuurd naar dbAccount.Insert zodat het account aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="Account"></param>
        public void Add(Account Account)
        {
            dbaccount.Insert(Account);
        }
        /// <summary>
        /// Een account wordt doorgestuurd naar dbaccount.Delete zodat dit account uit de database verwijderd kan worden
        /// </summary>
        /// <param name="Account"></param>
        //public void Delete(Account Account)
        //{
        //    dbaccount.Delete(Account);
        //}

        /// <summary>
        /// The find gebruikersnaam.
        /// </summary>
        /// <param name="gebruikersnaam">
        /// The gebruikersnaam.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool FindGebruikersnaam(string gebruikersnaam)
        {
            bool gevonden = dbaccount.SelectGebruikersnaam(gebruikersnaam.ToLower());

            if (gevonden == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Doorzoekt de database naar een account met een passend email en retouneert vervolgens het accountid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        //public int FindAccountID(string email)
        //{
        //    int foundAccountID = dbaccount.FindAccountID(email);

        //    if (foundAccountID != null)
        //    {
        //        return foundAccountID;
        //    }
        //    else
        //    {
        //        MessageBox.Show(this,"Account niet gevonden");
        //        return Convert.ToInt32(null);
        //    }
        //}

        /// <summary>
        /// Update het email van het account
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="oldemail"></param>
        //public void Update(Account Account, string oldemail)
        //{
        //    dbaccount.Update(Account, oldemail);
        //}

        /// <summary>
        /// Koppelt bij het inchecken een RFID aan een account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="rfid"></param>
        //public void ChainRFID(string email, string rfid)
        //{
        //    bool SuccesChain = dbaccount.ChainRFID(email, rfid);
        //    if (SuccesChain)
        //    {
        //        MessageBox.Show(this,"Koppeling Gelukt");
        //    }
        //    else
        //    {
        //        MessageBox.Show(this,"Koppeling Mislukt");
        //    }
        //}

        /// <summary>
        /// De gebruiker wordt aangemeld
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public bool Login(string email, string password)
        //{
        //    return dblogin.loginCheck(email, password);
        //}


    }

    public static class MessageBox
    {
        public static void Show(this Page Page, String Message)
        {
            Page.ClientScript.RegisterStartupScript(
               Page.GetType(),
               "MessageBox",
               "<script language='javascript'>alert('" + Message + "');</script>"
            );
        }
    }
}