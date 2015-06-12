using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    using System.DirectoryServices;
    using System.Security.Principal;
    using System.DirectoryServices.AccountManagement;
    using System.Drawing.Printing;
    using System.Web.DynamicData.ModelProviders;

    public class ADRegistreerLogin
    {


        public string CreateUserAccount(string ldapPath, string userName, string userPassword, string userEmail)
        {
            Console.WriteLine(ldapPath);
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "pts45.local", ldapPath, "Administrator", "Admin123");
                //UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, "Guest");
                UserPrincipal usr = new UserPrincipal(ctx);
                usr.SamAccountName = userName;
                usr.UserPrincipalName = userName;
                usr.EmailAddress = userEmail;

                usr.SetPassword(userPassword);
                usr.Save();

                AddUserToGroup(userName, "Web-Gebruiker", ctx);
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

        public void AddUserToGroup(string userId, string groupName, PrincipalContext ctx)
        {
            try
            {
                using (ctx)
                {
                    GroupPrincipal group = GroupPrincipal.FindByIdentity(ctx, groupName);
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
        public UserPrincipal FindByIdentity(string username)
        {
            try
            {
                PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "pts45.local", "Administrator", "Admin123");

                UserPrincipal usr = UserPrincipal.FindByIdentity(ctx, IdentityType.SamAccountName, username);
                return usr;
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //doSomething with E.Message.ToString(); 

            }
            return null;
        } 

        public bool AuthenticateAD(string userName, string password, string domain)
        {
            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain);
            // validate the credentials 
            bool validatedOnDomain = pc.ValidateCredentials(userName, password);

            return validatedOnDomain;
        }

        public Account GetAccount()
        {
            return new Account();
        }
    }
}