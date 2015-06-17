﻿// --------------------------------------------------------------------------------------------------------------------
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
    using System.DirectoryServices;
    using System.DirectoryServices.AccountManagement;

    /// <summary>
    /// The ad registreer login.
    /// </summary>
    public class AdRegistreerLogin
    {
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
                var ctx = new PrincipalContext(ContextType.Domain, "pts45.local", "Administrator", "Admin123");

                var usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username);
                return usr;
            }
            catch (DirectoryServicesCOMException e)
            {
                // doSomething with E.Message.ToString(); 
            }

            return null;
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
        /// <param name="domain">
        /// The domain.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool AuthenticateAd(string userName, string password, string domain)
        {
            var pc = new PrincipalContext(ContextType.Domain, domain);

            // validate the credentials 
            var validatedOnDomain = pc.ValidateCredentials(userName, password);

            return validatedOnDomain;
        }
    }
}