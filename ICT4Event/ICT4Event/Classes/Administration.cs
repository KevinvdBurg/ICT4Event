using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Net.Mail;
    using System.Web.UI;
    //using System.Windows.Forms;

    using ICT4Event.Classes;

    public class Administration
    {
        private Database DB = new Database();
        private DBLogin dblogin = new DBLogin();
        private DBAccount dbaccount = new DBAccount();
        private  ADRegistreerLogin adRegistreerLogin = new ADRegistreerLogin();

        private const string domain = "PTS45.local";
        //private const string domainCon = "CN=Users,DC=pts45,DC=local";
        private const string domainCon = "CN=Users,DC=pts45,DC=local";
        public Administration()
        {

        }

        /// <summary>
        /// Een Account wordt doorgestuurd naar dbAccount.Insert zodat het account aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="Account"></param>
        public void Add(Account Account)
        {
            dbaccount.Insert(Account);
            adRegistreerLogin.CreateUserAccount(domainCon, Account.Gebruiksersnaam, Account.Wachtwoord, Account.Email);
        }

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
        public bool FindEmail(string email)
        {
            bool gevonden = dbaccount.SelectEmail(email.ToLower());

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
        /// De gebruiker wordt aangemeld
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string userName, string password)
        {
            return adRegistreerLogin.AuthenticateAD(userName, password, domain);
        }
        public string LoginCheck(string username, string password)
        {
            return this.dblogin.loginCheck(username, password);
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public Account GetDetails(string username)
        {
            return dbaccount.Select(username);
        }

        public void SendEmail(Account account)
        {
            string to = account.Email;
            string from = "noreply@ict4events.bb";
            MailMessage message = new MailMessage(from, to);
            message.Subject = "You Activation Key";
            message.Body = @"Dear " + account.Gebruiksersnaam + Environment.NewLine + "Your activation key is: "
                           + Environment.NewLine + account.Hash;
            SmtpClient client = new SmtpClient("smtp.ict4events.bb");
            client.UseDefaultCredentials = true;

            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex.ToString());
            }
        }

        public bool ActivateAccount(string hash)
        {
            return this.dbaccount.ActivateAccount(hash);
        }
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