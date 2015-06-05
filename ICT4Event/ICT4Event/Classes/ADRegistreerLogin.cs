using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event.Classes
{
    using System.DirectoryServices;

    public class ADRegistreerLogin
    {

        public string CreateUserAccount(string ldapPath, string userName, string userPassword)
        {
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
            //string message = "";
            DirectoryEntry entry = new
                DirectoryEntry("LDAP://" + domain, userName, password);
            try
            {
                object obj = entry.NativeObject;
                DirectorySearcher search = new DirectorySearcher(entry);
                search.Filter = "(SAMAccountName=" + userName + ")";
                search.PropertiesToLoad.Add("cn");
                SearchResult result = search.FindOne();

                if (null == result)
                {

                    return false;
                }
                //MessageBox.Show(" Gelukt!");


            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                return false;
                //throw new Exception("Error authenticating user. " + ex.Message);
            }
            return true;
        }
    }
}