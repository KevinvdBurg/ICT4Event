// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ADRegistreerLogin.cs" company="ICT4EVENTS.">
//   ICT4EVENTS.
// </copyright>
// <summary>
//   The ad registreer login.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace ICT4Event.Classes
{
    using System;
    using System.Collections.Generic;
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;
    using System.Text;
    using System.Web.UI;

    /// <summary>
    /// The ad registreer login.
    /// </summary>
    public class AdRegistreerLogin
    {
        /// <summary>
        /// The ctx.
        /// </summary>
        private PrincipalContext ctx = new PrincipalContext(
            ContextType.Domain, 
            "pts45.local", 
            "Administrator", 
            "Admin123");

        /// <summary>
        /// The create user account.
        /// </summary>
        /// <param name="ldapPath">
        /// The ldap path.
        /// </param>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="userPassword">
        /// The user password.
        /// </param>
        /// <param name="userEmail">
        /// The user email.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string CreateUserAccount(string ldapPath, string userName, string userPassword, string userEmail)
        {
            Console.WriteLine(ldapPath);
            try
            {
                var ctx = new PrincipalContext(ContextType.Domain, "pts45.local", ldapPath, "Administrator", "Admin123");

                // UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, "Guest");
                var usr = new UserPrincipal(ctx);
                usr.SamAccountName = userName;
                usr.UserPrincipalName = userName;
                usr.EmailAddress = userEmail;
                usr.SetPassword(userPassword);
                usr.Enabled = true;
                usr.UnlockAccount();

                usr.Save();

                this.AddUserToGroup(userName, "Web-Gebruiker", ctx);
                usr.Dispose();
                ctx.Dispose();
                return userName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The edit user account.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="userPassword">
        /// The user password.
        /// </param>
        /// <param name="userEmail">
        /// The user email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool EditUserAccount(string userName, string userPassword, string userEmail)
        {
            try
            {
            }
            catch (Exception)
            {
                throw;
            }

            return true;
        }

        /// <summary>
        /// The add user to group.
        /// </summary>
        /// <param name="userId">
        /// The user id.
        /// </param>
        /// <param name="groupName">
        /// The group name.
        /// </param>
        /// <param name="ctx">
        /// The ctx.
        /// </param>
        public void AddUserToGroup(string userId, string groupName, PrincipalContext ctx)
        {
            try
            {
                using (ctx)
                {
                    var group = GroupPrincipal.FindByIdentity(ctx, groupName);
                    group.Members.Add(ctx, IdentityType.UserPrincipalName, userId);
                    group.Save();
                }
            }
            catch (DirectoryServicesCOMException e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The find by identity.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="UserPrincipal"/>.
        /// </returns>
        public UserPrincipal FindByIdentity(string username)
        {
            try
            {
                var usr = UserPrincipal.FindByIdentity(this.ctx, IdentityType.SamAccountName, username);
                return usr;
            }
            catch (DirectoryServicesCOMException e)
            {
                // doSomething with E.Message.ToString(); 
            }

            return null;
        }

        /// <summary>
        /// The find user group.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> FindUserGroup(string username)
        {
            List<string> groupList = new List<string>();
            try
            {
                UserPrincipal user = UserPrincipal.FindByIdentity(this.ctx, IdentityType.SamAccountName, username);
                if (user != null)
                {
                    foreach (var group in user.GetGroups())
                    {
                        groupList.Add(@group.Name);
                        Console.WriteLine(@group.Name);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return groupList;
        }

        /// <summary>
        /// The authenticate ad.
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="password">
        /// The password.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AuthenticateAd(string userName, string password)
        {
            try
            {
                using (this.ctx)
                {
                    var validatedOnDomain = this.ctx.ValidateCredentials(userName, password);
                    return validatedOnDomain;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        /// <summary>
        /// The update user account.
        /// </summary>
        /// <param name="username">
        /// The username.
        /// </param>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <param name="wachtwoord">
        /// The wachtwoord.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool UpdateUserAccount(string username, string email, string wachtwoord)
        {
            bool resultaat = false;
            try
            {
                UserPrincipal user = this.FindByIdentity(username);
                user.SetPassword(wachtwoord);
                user.EmailAddress = email;

                user.Save();

                user.Dispose();
                resultaat = true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            return resultaat;
        }
    }
}