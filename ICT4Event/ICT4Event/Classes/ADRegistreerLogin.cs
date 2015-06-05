using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    using System.DirectoryServices;
    using System.Security.Principal;
    using System.DirectoryServices.AccountManagement;

    public class ADRegistreerLogin
    {

        public string CreateUserAccount(string ldapPath, string userName, string userPassword)
        {
            PrincipalContext ctx = new PrincipalContext(ContextType.Domain, "pts45.local", ldapPath);
            // create a user principal object
            
            UserPrincipal user = new UserPrincipal(ctx, userName, userPassword, true);

            // force the user to change password at next logon
            user.ExpirePasswordNow();

            // save the user to the directory
            user.Save();

            return user.SamAccountName;
            
            string oGUID = string.Empty;
            try
            {
                oGUID = string.Empty;
                string connectionPrefix = "LDAP://" + "CN=Users," + ldapPath;
                DirectoryEntry dirEntry = new DirectoryEntry(connectionPrefix, "Administrator", "Admin123");
                DirectoryEntry newUser = dirEntry.Children.Add
                    ("CN=" + userName, "User");
                newUser.Properties["samAccountName"].Value = userName;
                newUser.CommitChanges();
                oGUID = newUser.Guid.ToString();

                newUser.Invoke("SetPassword", new object[] { userPassword });
                newUser.CommitChanges();


                newUser.Properties["userAccountControl"].Value = 0x200;
                newUser.CommitChanges();

                dirEntry.Close();
                newUser.Close();

                //MessageBox.Show(" gelukt!");
            }
            catch (System.DirectoryServices.DirectoryServicesCOMException E)
            {
                //MessageBox.Show(E.Message);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            return oGUID;
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