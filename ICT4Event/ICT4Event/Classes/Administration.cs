// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The administration.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace ICT4Event
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Net.Mail;
    using System.Text.RegularExpressions;
    using System.Web.UI;

    using ICT4Event.Classes;

    // using System.Windows.Forms;

    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration
    {
        // private const string domainCon = "CN=Users,DC=pts45,DC=local";
        /// <summary>
        /// The domain con.
        /// </summary>
        private const string DomainCon = "CN=Users,DC=pts45,DC=local";

        /// <summary>
        /// The ad registreer login.
        /// </summary>
        private readonly AdRegistreerLogin adRegistreerLogin = new AdRegistreerLogin();

        /// <summary>
        /// The dbaccount.
        /// </summary>
        private readonly DbAccount dbaccount = new DbAccount();

        /// <summary>
        /// The dblogin.
        /// </summary>
        private readonly DbLogin dblogin = new DbLogin();

        /// <summary>
        /// The db.
        /// </summary>
        private Database db = new Database();

        /// <summary>
        /// Een Account wordt doorgestuurd naar dbAccount.Insert zodat het account aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="account">
        /// Account.
        /// </param>
        public void Add(Account account)
        {
            this.dbaccount.Insert(account);
            this.adRegistreerLogin.CreateUserAccount(
                DomainCon, 
                account.Gebruiksersnaam, 
                account.Wachtwoord, 
                account.Email);
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
            var gevonden = this.dbaccount.SelectGebruikersnaam(gebruikersnaam.ToLower());

            if (gevonden == false)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The find email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool FindEmail(string email)
        {
            var gevonden = this.dbaccount.SelectEmail(email.ToLower());

            if (gevonden == false)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// De gebruiker wordt aangemeld
        /// </summary>
        /// <param name="userName">
        /// The user Name.
        /// </param>
        /// <param name="password">
        /// The user Password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Login(string userName, string password)
        {
            return this.adRegistreerLogin.AuthenticateAd(userName.ToLower(), password);
        }

        /// <summary>
        /// The login check.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public bool LoginCheck(string username)
        {
            return this.dblogin.LoginActivatieCheck(username.ToLower());
        }

        /// <summary>
        /// The is valid email.
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The get details.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>.
        /// </returns>
        public Account GetDetails(string username)
        {
            return this.dbaccount.Select(username.ToLower());
        }

        /// <summary>
        /// The send email.
        /// </summary>
        /// <param name="account">
        /// The account.
        /// </param>
        public void SendEmail(Account account)
        {
            var to = account.Email;
            var from = "noreply@ict4events.bb";
            var message = new MailMessage(from, to);
            message.Subject = "You Activation Key";
            message.Body = @"Dear " + account.Gebruiksersnaam + Environment.NewLine + "Your activation key is: "
                           + Environment.NewLine + account.Hash;
            var client = new SmtpClient("smtp.ict4events.bb");
            client.UseDefaultCredentials = true;
            try
            {
                client.Send(message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception caught in CreateTestMessage2(): {0}", ex);
            }
        }

        /// <summary>
        /// The activate account.
        /// </summary>
        /// <param name="hash">
        /// The hash.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ActivateAccount(string hash)
        {
            return this.dbaccount.ActivateAccount(hash);
        }

        public List<string> GetAccountGroups(string username)
        {
            return this.adRegistreerLogin.FindUserGroup(username);
        }

        public bool IsValid(string email)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            return Regex.IsMatch(email, pattern);
        }


        public bool UpdateAccountAD(string username, string email, string wachtwoord)
        {
            return this.adRegistreerLogin.UpdateUserAccount(username, email, wachtwoord);
            
        }

        public bool UpdateAccountDB(int id, string email)
        {
            return this.dbaccount.UpdateUserAccount(id, email);
        }
    }
}