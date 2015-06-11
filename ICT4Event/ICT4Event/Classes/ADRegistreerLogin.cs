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

                usr.EmailAddress = userEmail;

                usr.SetPassword(userPassword);
                usr.Save();

                usr.Dispose();
                ctx.Dispose();
                return usr.SamAccountName;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public bool AuthenticateAD(string userName, string password, string domain)
        {

            PrincipalContext pc = new PrincipalContext(ContextType.Domain, domain);
            // validate the credentials 
            bool validatedOnDomain = pc.ValidateCredentials(userName, password);

            return validatedOnDomain;

        }
    }
}