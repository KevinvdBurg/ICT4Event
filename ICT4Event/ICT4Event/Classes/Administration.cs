
// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Administration.cs" company="ICT4EVENTS.">
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
    using System.Linq;
    using System.Web;
    using System.Web.UI;

    /// <summary>
    /// The administration.
    /// </summary>
    public class Administration : Page
    {
        /// <summary>
        /// Een instatntie van de DBAddress
        /// </summary>
        private readonly DBAddress dbaddress = new DBAddress();

        /// <summary>
        /// Een instatntie van de DBEvent
        /// </summary>
        private readonly DBEvent dbevent = new DBEvent();

        /// <summary>
        /// Een instatntie van de DBAccount
        /// </summary>
        private readonly DbAccount dbaccount = new DbAccount();

        /// <summary>
        /// Een instatntie van de DBLogin
        /// </summary>
        private readonly DbLogin dblogin = new DbLogin();

        /// <summary>
        /// Een instatntie van de DBPost
        /// </summary>
        private readonly DBPost dbpost = new DBPost();

        /// <summary>
        /// The dbreserve.
        /// </summary>
        private DBReserve dbreserve = new DBReserve();

        /// <summary>
        /// The db campingspot.
        /// </summary>
        private DBCampingspot dbCampingspot = new DBCampingspot();

        /// <summary>
        /// The db item.
        /// </summary>
        private DBItem dbItem = new DBItem();

        /// <summary>
        /// Een instatntie van de AdRegistreerLogin
        /// </summary>
        private readonly AdRegistreerLogin adRegistreerLogin = new AdRegistreerLogin();

        /// <summary>
        /// Een instatntie van de DBAddress
        /// </summary>
        private readonly DBAddress dbAddress = new DBAddress();

        /// <summary>
        /// The domain con.
        /// </summary>
        private const string DomainCon = "CN=Users,DC=pts45,DC=local";

        /// <summary>
        /// Een event wordt doorgestuurd naar dbEvent zodat er een event toegevoegd kan worden aan de database
        /// </summary>
        /// <param name="Event">
        /// Een Event
        /// </param>
        public void AddEvent(Event Event)
        {
            this.dbevent.Insert(Event);
        }

        /// <summary>
        /// The find event.
        /// </summary>
        /// <param name="EventName">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public Event FindEvent(string EventName)
        {
            var foundEvent = this.dbevent.Select(EventName);

            if (foundEvent != null)
            {
                return foundEvent;
            }

            this.Page.Show("Event niet gevonden");
            return null;
        }

        /// <summary>
        /// The find event.
        /// </summary>
        /// <param name="EventID">
        /// Event.
        /// </param>
        /// <returns>
        /// The <see cref="Event"/>.
        /// </returns>
        public Event FindEvent(int EventID)
        {
            var foundEvent = this.dbevent.Select(EventID);

            if (foundEvent != null)
            {
                return foundEvent;
            }

            this.Page.Show("Event niet gevonden");
            return null;
        }

        /// <summary>
        /// The find address id.
        /// </summary>
        /// <param name="zipcode">
        /// Zipcode.
        /// </param>
        /// <param name="number">
        /// Number.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int FindAddressID(string zipcode, string number)
        {
            var foundAddressID = this.dbaddress.FindAdressID(zipcode, number);

            if (foundAddressID != null)
            {
                return foundAddressID;
            }

            this.Page.Show("AdresID niet gevonden");
            return Convert.ToInt32(null);
        }

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
        /// VInd het gebruikersnaam en kijk of deze bestaat
        /// </summary>
        /// <param name="gebruikersnaam">
        /// Gebruikersnaam.
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
        /// Vind een email en kijkt of hij bestaat
        /// </summary>
        /// <param name="email">
        /// Een email
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
        /// Controleerd of de gebruiker mag inloggen. Hier wordt gekeken of de activatie correct is.
        /// </summary>
        /// <param name="username">
        /// De gebruikersnaam
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public bool LoginCheck(string username)
        {
            return this.dblogin.LoginActivatieCheck(username.ToLower());
        }

        /// <summary>
        /// Krijgt alle details van de Gebruiker uit de database
        /// </summary>
        /// <param name="username">
        /// De gebruikers naam
        /// </param>
        /// <returns>
        /// The <see cref="Account"/>.
        /// </returns>
        public Account GetDetails(string username)
        {
            return this.dbaccount.Select(username.ToLower());
        }

        /// <summary>
        /// Stuurt een Email naar de gebruiker
        /// </summary>
        /// <param name="account">
        /// Een Account Object
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
        /// Activeerd een account als de Hash correct is
        /// </summary>
        /// <param name="hash">
        /// Activatie Hash
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool ActivateAccount(string hash)
        {
            return this.dbaccount.ActivateAccount(hash);
        }

        /// <summary>
        /// Koppeld een gebruiker aan een groep
        /// </summary>
        /// <param name="username">
        /// Gebruikers naam
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// Een lijst met alle groepen waar de gebruiker inzit
        /// </returns>
        public List<string> GetAccountGroups(string username)
        {
            return this.adRegistreerLogin.FindUserGroup(username);
        }

        /// <summary>
        /// Kijkt of het email valide is
        /// </summary>
        /// <param name="email">
        /// The email.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsValid(string email)
        {
            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            return Regex.IsMatch(email, pattern);
        }

        /// <summary>
        /// Updated een Account in de AD
        /// </summary>
        /// <param name="username">
        /// Een Gebruikersnaam
        /// </param>
        /// <param name="email">
        /// Een Email
        /// </param>
        /// <param name="wachtwoord">
        /// Een Wachtwoord
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool UpdateAccountAD(string username, string email, string wachtwoord)
        {
            return this.adRegistreerLogin.UpdateUserAccount(username, email, wachtwoord);
        }

        /// <summary>
        /// Update een gebruiker in de DB
        /// Je kan geen Gebruikersnaam wijzigen
        /// </summary>
        /// <param name="id">
        /// Een Account ID
        /// </param>
        /// <param name="email">
        /// Een Email
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool UpdateAccountDB(int id, string email)
        {
            return this.dbaccount.UpdateUserAccount(id, email);
        }

        /// <summary>
        /// Vind alle events
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Event> FindEventAll()
        {
            var foundEvents = this.dbevent.SelectAll();

            if (foundEvents != null)
            {
                return foundEvents;
            }

            this.Page.Show("Geen Events gevonden");
            return null;
        }

        /// <summary>
        /// Update een event
        /// </summary>
        /// <param name="tempEvent">
        /// Tijdelijk Event.
        /// </param>
        public void UpdateEvent(Event tempEvent)
        {
            this.dbevent.UpdateEvent(tempEvent);
        }

        /// <summary>
        /// The main categories.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> MainCategories()
        {
            return this.dbpost.GetMainCategories();
        }

        /// <summary>
        /// The sub categories.
        /// </summary>
        /// <param name="catnaam">
        /// The catnaam.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> SubCategories(string catnaam)
        {
            return this.dbpost.GetSubCategories(this.dbpost.GetCategorieID(catnaam));
        }

        /// <summary>
        /// The category files list.
        /// </summary>
        /// <param name="catnaam">
        /// The catnaam.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> CategoryFilesList(string catnaam)
        {
            return this.dbpost.CategoryFiles(this.dbpost.GetCategorieID(catnaam));
        }

        /// <summary>
        /// The posts.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> Posts()
        {
            return this.dbpost.MainMessages();
        }

        /// <summary>
        /// The post tekst.
        /// </summary>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string postTekst(string titel)
        {
            return this.dbpost.GetMessage(this.dbpost.GetMessageID(titel));
        }

        /// <summary>
        /// The get comments.
        /// </summary>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetComments(string titel)
        {
            return this.dbpost.GetComments(this.dbpost.GetMessageID(titel));
        }

        /// <summary>
        /// The test contains.
        /// </summary>
        /// <param name="str">
        /// The str.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string testContains(string str)
        {
            while (str.IndexOf("/") != -1)
            {
                str = str.Substring(str.IndexOf("/") + 1);
            }

            return str;
        }

        /// <summary>
        /// The category messages.
        /// </summary>
        /// <param name="catnaam">
        /// The catnaam.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> CategoryMessages(string catnaam)
        {
            return this.dbpost.CatMessages(this.dbpost.GetCategorieID(catnaam));
        }

        /// <summary>
        /// The insert main message.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        public void InsertMainMessage(int accountid, string titel, string inhoud)
        {
            this.dbpost.InsetMainMessage(accountid, titel, inhoud);
        }

        /// <summary>
        /// The insert cat message.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="titel">
        /// The titel.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        /// <param name="catnaam">
        /// The catnaam.
        /// </param>
        public void InsertCatMessage(int accountid, string titel, string inhoud, string catnaam)
        {
            this.dbpost.InsertCatMessage(accountid, titel, inhoud, this.dbpost.GetCatId(catnaam));
        }

        /// <summary>
        /// The insert reply.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="inhoud">
        /// The inhoud.
        /// </param>
        /// <param name="postTitel">
        /// The post titel.
        /// </param>
        public void InsertReply(int accountid, string inhoud, string postTitel)
        {
            this.dbpost.InsertReply(accountid, inhoud, this.dbpost.GetMessageID(postTitel));
        }

        /// <summary>
        /// The insert file.
        /// </summary>
        /// <param name="accountid">
        /// The accountid.
        /// </param>
        /// <param name="bestand">
        /// The bestand.
        /// </param>
        /// <param name="cat">
        /// The cat.
        /// </param>
        public void InsertFile(int accountid, string bestand, string cat)
        {
            this.dbpost.InsertBestand(accountid, bestand, this.dbpost.GetCatId(cat));
        }

        /// <summary>
        /// The GetHoogsteEventID.
        /// </summary>
        public int GetHoogsteEventID()
        {
            return this.dbevent.HoogsteEventID();
        }


        /// <summary>
        /// The find all free camping spots.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<CampingSpot> FindAllFreeCampingSpots()
        {
            List<CampingSpot> foundSpots = this.dbCampingspot.FindCampingSpots();
            List<CampingSpot> freeSpots = new List<CampingSpot>();
            foreach (var campingSpot in foundSpots)
            {
                if (!this.dbCampingspot.FindFreeSpots(campingSpot.ID))
                {
                    freeSpots.Add(campingSpot);
                }
            }

            return freeSpots;
        }

        /// <summary>
        /// The new person.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int NewPerson(Person person)
        {
            return this.dbreserve.NewPerson(person);
        }

        /// <summary>
        /// The new reservation.
        /// </summary>
        /// <param name="person">
        /// The person.
        /// </param>
        /// <param name="plekid">
        /// The plekid.
        /// </param>
        public void NewReservation(Person person, string plekid)
        {
            this.dbreserve.NewReservation(person, plekid);
        }

        /// <summary>
        /// The get specifications list.
        /// </summary>
        /// <param name="plekid">
        /// The plekid.
        /// </param>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<string> GetSpecificationsList(int plekid)
        {
            return this.dbCampingspot.FindInfo(plekid);
        }

        /// <summary>
        /// The get free items list.
        /// </summary>
        /// <returns>
        /// The <see cref="List"/>.
        /// </returns>
        public List<Item> GetFreeItemsList()
        {
            return this.dbItem.FindFreeItemsList();
        }

        /// <summary>
        /// The new item reservation.
        /// </summary>
        /// <param name="item">
        /// The item.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool NewItemReservation(Item item)
        {
            return this.dbItem.NewItemReservation(item);
        }

        /// <summary>
        /// The update location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        public void UpdateLocation(Location location)
        {
            this.dbAddress.Update(location);
        }

        /// <summary>
        /// The add location.
        /// </summary>
        /// <param name="location">
        /// The location.
        /// </param>
        public void AddLocation(Location location)
        {
            this.dbAddress.Insert(location);
        }
    }
}