using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    using System.Windows.Forms;

    public class Administration
    {
        Database DB = new Database();
        public Account currentAccount { get; set; }

        private DBLogin dblogin = new DBLogin();
        private DBPost dbpost = new DBPost();
        private DBAccount dbaccount = new DBAccount();
        private DBEvent dbevent = new DBEvent();
        private DBReserve dbreserve = new DBReserve();
        private DBAddress dbaddress = new DBAddress();
        private DBCampingspot dbCampingspot = new DBCampingspot();
        private DBItem dbItem = new DBItem();

        public Administration()
        {

        }

        public void LikePost(int postid)
        {
            dbpost.LikePost(postid);
        }
        public void Add(Post Post, string Inhoud)
        {
            dbpost.InsertMessage(Post, Inhoud);
        }

        public void Add(Map map)
        {
            dbpost.Insert(map);
        }

        public void Delete(Post Post)
        {
            dbpost.Delete(Post.Postid.ToString());
        }

        public void Find(Post Post)
        {

        }

        public bool login(string username, string password)
        {
            return dblogin.loginCheck(username, password);

        }

        /// <summary>
        /// set the current account to the given email
        /// Zet de account.email gelijk aan het gegeven email
        /// </summary>
        /// <param name="email"></param>

        public void setCurrentAccount(string email)
        {
            this.currentAccount = dblogin.returnLoggedinAccount(email);
        }

        public List<Post> returnAllPosts()
        {
            List<Post> resultaat = new List<Post>();
            resultaat = dbpost.allPosts();
            return resultaat;
        }

        public List<Post> returnAllPosts(int parentmap)
        {
            List<Post> resultaat = new List<Post>();
            resultaat = dbpost.allPosts(parentmap);
            return resultaat;
        }

        public string postTitel(int postid)
        {
            return dbpost.GetTitel(postid);
        }

        public string PostAuteur(int postid)
        {
            return dbpost.GetPostAuteur(postid);
        }

        public int NumberOfReplies(int postid)
        {
            return dbpost.numberOfReplies(postid);
        }
        public string postText(int postid)
        {
            return dbpost.GetText(postid);
        }

        public bool isMessage(int postid)
        {
            return dbpost.isBericht(postid);
        }
        public List<Post> ReturnAllReplies(int postid)
        {
            List<Post> resultaat = new List<Post>();
            resultaat = dbpost.allReplies(postid);
            return resultaat;
        }

        public void ReportPost(int postid)
        {
            dbpost.ReportPost(postid);
        }

        public bool hasParentPost(int postid)
        {
            return dbpost.hasParentPost(postid);
        }

        public int GiveParentPost(int postid)
        {
            return dbpost.returnParentPost(postid);
        }

        public void AddReply(Post Post, string Inhoud)
        {
            dbpost.InsertReply(Post, Inhoud);
        }

        public void Add(File file, Account account)
        {
            dbpost.InsertFile(file, account);
        }

        public List<Map> ReturnMaps()
        {
            return dbpost.allMaps();
        }
        public List<Map> ReturnMaps(int mapid)
        {
            return dbpost.allMaps(mapid);
        }

        public string getParentMapName(int parentmapid)
        {
            return dbpost.parentMapNaam(parentmapid);
        }
        /// <summary>
        /// Een Account wordt doorgestuurd naar dbAccount.Insert zodat het account aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="Account"></param>
        public void Add(Account Account)
        {
            dbaccount.Insert(Account);
        }

        /// <summary>
        /// Een AccountEvent wordt doorgetuurd naar dbAccount.Insert zodat het accountevent aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="accountevent"></param>
        public void Add(AccountEvent accountevent)
        {
            dbaccount.Insert(accountevent);
        }

        /// <summary>
        /// Een reservering en eventid wordt doorgestuurd naar dbReserve. zodat de reservering aan de database toegevoegd kan worden
        /// </summary>
        /// <param name="Reserve"></param>
        /// <param name="CurrentEventID"></param>
        public void Add(Reserve Reserve, int CurrentEventID)
        {
            //De if statement splitst de reservering uit tussen plek reserveringen en item reserveringen
            if (Reserve is ReserveSpot)
            {
                dbreserve.Insert(Reserve as ReserveSpot, CurrentEventID);
            }
            else if (Reserve is ReserveItem)
            {
                dbreserve.Insert(Reserve as ReserveItem, CurrentEventID);
            }
        }

        /// <summary>
        /// Een event wordt doorgestuurd naar dbEvent zodat er een event toegevoegd kan worden aan de database
        /// </summary>
        /// <param name="Event"></param>
        public void AddEvent(Event Event)
        {
            dbevent.Insert(Event);
        }

        /// <summary>
        /// Een account wordt doorgestuurd naar dbaccount.Delete zodat dit account uit de database verwijderd kan worden
        /// </summary>
        /// <param name="Account"></param>
        public void Delete(Account Account)
        {
            dbaccount.Delete(Account);
        }

        //public void Delete(Reserve Reserve)
        //{
        //    if (Reserve is ReserveSpot)
        //    {
        //        //dbreserve.Delete(Reserve as ReserveSpot);
        //    }
        //    else if (Reserve is ReserveItem)
        //    {
        //        //dbreserve.Delete(Reserve as ReserveItem);
        //    }
        //}

        public void Delete(Event Event)
        {
            //TODO
        }

        /// <summary>
        /// Een Media object wordt doorgestuurd naar dbevent.DeleteMedia zodat media verwijderd kan worden uit de database 
        /// </summary>
        /// <param name="Media"></param>
        public void Delete(Media Media)
        {
            dbevent.DeleteMedia(Media);
        }
        /// <summary>
        /// Doorzoekt alle accounts in de database naar het account met een email die gelijk is aan Code
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public Account FindAccount(string Code)
        {
            Account foundAccount = dbaccount.Select(Code);

            if (foundAccount != null)
            {
                return foundAccount;
            }
            else
            {
                MessageBox.Show("Account niet gevonden");
                return null;
            }

        }

        /// <summary>
        /// Geeft een lijst terug met alle bekende accounts uit de database
        /// </summary>
        /// <returns></returns>
        public List<Account> FindAccountAll()
        {
            List<Account> foundAccounts = dbaccount.SelectAll();

            if (foundAccounts != null)
            {
                return foundAccounts;
            }
            else
            {
                MessageBox.Show("Accounts niet gevonden");
                return null;
            }
        }

        /// <summary>
        /// Doorzoekt de database naar de hoogste reseveringscode
        /// </summary>
        /// <returns></returns>
        public int FindHighestReserveID()
        {
            int foundID = dbreserve.HighestID();
            return foundID;
        }

        /// <summary>
        /// Doorzoekt de database naar de hoogste eventid
        /// </summary>
        /// <returns></returns>
        public int FindHighestEventID()
        {
            int foundID = dbevent.HighestID();
            return foundID;
        }

        /// <summary>
        /// Doorzoekt de database naar de hoogste verhuurid
        /// </summary>
        /// <returns></returns>
        public int FindHighestItemReserveID()
        {
            return dbreserve.HighestReserveItemID();
        }

        /// <summary>
        /// Doorzoekt de database naar een item met een naam die gelijk is aan naam
        /// </summary>
        /// <param name="naam"></param>
        /// <returns></returns>
        public int FindItemID(string naam)
        {
            return dbItem.ItemID(naam);
        }

        /// <summary>
        /// Searched the database for all events for by event name
        /// </summary>
        /// <param name="EventName"></param>
        /// <returns></returns>
        public Event FindEvent(string EventName)
        {
            Event foundEvent = dbevent.Select(EventName);

            if (foundEvent != null)
            {
                return foundEvent;
            }
            else
            {
                MessageBox.Show("Event niet gevonden");
                return null;
            }

        }

        /// <summary>
        /// Doorzoekt alle events in de database naar een event met de passende eventid
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public Event FindEvent(int EventID)
        {
            Event foundEvent = dbevent.Select(EventID);

            if (foundEvent != null)
            {
                return foundEvent;
            }
            else
            {
                MessageBox.Show("Event niet gevonden");
                return null;
            }
        }

        /// <summary>
        /// Doorzoekt de database naar een adres met een passende postcode en huisnummer en retourneert vervolgens het adresid
        /// </summary>
        /// <param name="zipcode"></param>
        /// <param name="number"></param>
        /// <returns></returns>
        public int FindAddressID(string zipcode, string number)
        {
            int foundAddressID = dbaddress.FindAdressID(zipcode, number);

            if (foundAddressID != null)
            {
                return foundAddressID;
            }
            else
            {
                MessageBox.Show("AdresID niet gevonden");
                return Convert.ToInt32(null);
            }
        }

        /// <summary>
        /// Doorzoekt de database naar een account met een passend email en retouneert vervolgens het accountid
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public int FindAccountID(string email)
        {
            int foundAccountID = dbaccount.FindAccountID(email);

            if (foundAccountID != null)
            {
                return foundAccountID;
            }
            else
            {
                MessageBox.Show("Account niet gevonden");
                return Convert.ToInt32(null);
            }
        }

        /// <summary>
        /// Retouneert alle Events in de database
        /// </summary>
        /// <returns></returns>
        public List<Event> FindEventAll()
        {
            List<Event> foundEvents = dbevent.SelectAll();

            if (foundEvents != null)
            {
                return foundEvents;
            }
            else
            {
                MessageBox.Show("Geen Events gevonden");
                return null;
            }
        }

        //Retouneert alle AccountEvents bekend in de database per account
        public List<Event> FindEventAllPerAccount(Account account)
        {
            List<Event> foundEvents = dbevent.SelectAll();

            if (foundEvents != null)
            {
                return foundEvents;
            }
            else
            {
                MessageBox.Show("Geen Events gevonden");
                return null;
            }
        }

        /// <summary>
        /// Doorzoekt de database naar een AccountEvent met een passend accountid en eventid en retourneert vervolgens dit accountevent
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public AccountEvent FindAccountEvent(int AccountID, int EventID)
        {
            AccountEvent founAccountEvent = dbaccount.FindAccountEvent(AccountID, EventID);
            return founAccountEvent;
        }

        /// <summary>
        /// Doorzoekt de database naar alle AccountEvent met een passen eventId en retourneert vervolgens deze lijst
        /// </summary>
        /// <param name="EventID"></param>
        /// <returns></returns>
        public List<AccountEvent> FindAllAccountEvent(int EventID)
        {
            List<AccountEvent> foundAccountEvents = dbevent.SelectAllPresent(EventID);

            if (foundAccountEvents != null)
            {
                return foundAccountEvents;
            }
            else
            {
                MessageBox.Show("Geen Events accounts gevonden");
                return null;
            }
        }

        ///// <summary>
        ///// Veranderd een accountEvent in de database
        ///// </summary>
        ///// <param name="present"></param>
        //public void ChangeAccountEvent(bool present)
        //{
        //    int result = 0;
        //    if (present)
        //    {
        //        result = 1;
        //    }
        //    dbaccount.UpdateAccountEvent(result);
        //}

        /// <summary>
        /// Doorzoekt de database naar een passen accountEvent en zet deze op aanwezig
        /// </summary>
        /// <param name="accountEvent"></param>
        public void ChangeAccountEvent(AccountEvent accountEvent)
        {
            dbaccount.UpdateAccountEvent(accountEvent);
        }

        /// <summary>
        /// Doorzoekt de database voor een reservering met de juiste reserveringcode
        /// en een account is nodig voor de reservering
        /// </summary>
        /// <param name="Code"></param>
        /// <param name="account"></param>
        /// <returns></returns>
        public Reserve FindReserve(int Code, Account account)
        {
            Reserve foundReserve = dbreserve.Select(Code, account);
            if (foundReserve != null)
            {
                return foundReserve;
            }
            else
            {
                MessageBox.Show("Reservering niet gevonden");
                return null;
            }

        }

        /// <summary>
        /// Doorzoekt de database naar alle kampeerplekreserveringen en retouneert vervolgens deze lijst
        /// </summary>
        /// <returns></returns>
        public List<ReserveSpot> FindReserveSpotsAll()
        {
            List<ReserveSpot> foundReserves = dbreserve.SelectAllSpots();
            if (foundReserves != null)
            {
                return foundReserves;
            }
            else
            {
                MessageBox.Show("Reservering niet gevonden");
                return null;
            }
        }

        /// <summary>
        /// Doorzoekt de database naar alle bekende items en retouneert deze lijst
        /// </summary>
        /// <returns></returns>
        public List<Item> FindItems()
        {
            List<Item> foundItems = dbItem.SelectAllItems();
            if (foundItems != null)
            {
                return foundItems;
            }
            else
            {
                {
                    MessageBox.Show("Geen items gevonden");
                    return null;
                }
            }
        }

        /// <summary>
        /// retourneert alle informatie die nodig is voor het incheck systeem
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public List<string> CheckReserve(int Code)
        {
            List<string> checkedReserve = dbreserve.Check(Code);
            if (checkedReserve != null)
            {
                return checkedReserve;
            }
            else
            {
                MessageBox.Show("Reservering niet gevonden");
                return null;
            }

        }

        /// <summary>
        /// retouneert een lijst van itemreserveringen
        /// </summary>
        /// <returns></returns>
        public List<ReserveItem> FindReserveItemAll()
        {
            List<ReserveItem> foundReserves = dbreserve.SelectAllItems();
            if (foundReserves != null)
            {
                return foundReserves;
            }
            else
            {
                MessageBox.Show("Reservering niet gevonden");
                return null;
            }
        }

        public List<Media> FindMediaItemAll()
        {
            List<Media> foundMedia = dbevent.SelectAllMedia();
            if (foundMedia != null)
            {
                return foundMedia;
            }
            else
            {
                MessageBox.Show("Media Items zijn niet gevonden");
                return null;
            }
        }

        //public CampingSpot FindCampingSpot(int id)
        //{
        //    //CampingSpot foundCampingSpot = dbreserve.Select(/*id*/);
        //    //if (foundCampingSpot != null)
        //    //{
        //    //    return foundCampingSpot;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Kampeerplek niet gevonden");
        //    //    return null;
        //    //}
        //    return null;
        //}

        /// <summary>
        /// retouneert een lijst van alle kampeerplekken
        /// </summary>
        /// <returns></returns>
        public List<CampingSpot> FindCampingSpotsAll()
        {
            List<CampingSpot> foundSpots = dbCampingspot.SelectAllSpots();
            if (foundSpots != null)
            {
                return foundSpots;
            }
            else
            {
                MessageBox.Show("Kampeerplekken niet gevonden");
                return null;
            }
            return null;
        }

        //public Item FindItem(int id)
        //{
        //    //Item founditem = dbreserve.Select(/*id*/);
        //    //if (founditem != null)
        //    //{
        //    //    return founditem;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Item niet gevonden");
        //    //    return null;
        //    //}
        //    return null;
        //}

        //public List<Item> FindItemsAll()
        //{
        //    //List<Item> foundItems = dbreserve.Select( /*id*/);
        //    //if (foundItems != null)
        //    //{
        //    //    return foundItems;
        //    //}
        //    //else
        //    //{
        //    //    MessageBox.Show("Items niet gevonden");
        //    //}
        //    return null;
        //}

        /// <summary>
        /// Update het email van het account
        /// </summary>
        /// <param name="Account"></param>
        /// <param name="oldemail"></param>
        public void Update(Account Account, string oldemail)
        {
            dbaccount.Update(Account, oldemail);
        }

        /// <summary>
        /// Koppelt bij het inchecken een RFID aan een account
        /// </summary>
        /// <param name="email"></param>
        /// <param name="rfid"></param>
        public void ChainRFID(string email, string rfid)
        {
            bool SuccesChain = dbaccount.ChainRFID(email, rfid);
            if (SuccesChain)
            {
                MessageBox.Show("Koppeling Gelukt");
            }
            else
            {
                MessageBox.Show("Koppeling Mislukt");
            }
        }

        /// <summary>
        /// Veranderd de betalingstatus van de reservering naar waar
        /// </summary>
        /// <param name="reserveringsID"></param>
        /// <returns></returns>
        public bool ChangePaymentStat(int reserveringsID)
        {
            bool SuccesChangeStat = dbreserve.UpdatePayment(reserveringsID);
            if (SuccesChangeStat)
            {
                MessageBox.Show("Betaling voltooid");
                return true;
            }
            else
            {
                MessageBox.Show("Betaling Mislukt");
                return false;
            }
        }

        /// <summary>
        /// De gebruiker wordt aangemeld
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool Login(string email, string password)
        {
            return dblogin.loginCheck(email, password);
        }

        /// <summary>
        /// Doorzoekt de database naar het juiste media bestand en retouneert deze
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Media FindMedia(string value)
        {
            return dbevent.SelectMedia(value);
        }

        /// <summary>
        /// update de gegevens van het event
        /// </summary>
        /// <param name="tempEvent"></param>
        /// <param name="Oldzip"></param>
        /// <param name="huisnummer"></param>
        public void UpdateEvent(Event tempEvent, string Oldzip, int huisnummer)
        {
            dbevent.UpdateEvent(tempEvent, Oldzip, huisnummer);
        }

        /// <summary>
        /// Verwijderd de itemreserving uit de database
        /// </summary>
        /// <param name="value"></param>
        public void DeleteItemRes(int value)
        {
            dbreserve.DeleteItem(value);
        }

        /// <summary>
        /// Verwijderd de kampeerplekreservering uit de database
        /// </summary>
        /// <param name="value"></param>
        public void DeleteSpotRes(int value)
        {
            dbreserve.DeleteSpot(value);
        }

    }
}