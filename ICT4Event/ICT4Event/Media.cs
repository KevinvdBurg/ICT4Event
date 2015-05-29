using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Media
    {
        public int PostID { get; set; }
        public int AANTALREPORTS { get; set; }
        public string Inhoud { get; set; }
        public string Bestandlocatie { get; set; }
        public string AccountName { get; set; }

        public Media(int postId, int aantalreports, string inhoud, string bestandlocatie)
        {
            PostID = postId;
            AANTALREPORTS = aantalreports;
            Inhoud = inhoud;
            Bestandlocatie = bestandlocatie;
        }

        public Media(int postId, int aantalreports, string inhoud, string bestandlocatie, string accountName)
        {
            PostID = postId;
            AANTALREPORTS = aantalreports;
            Inhoud = inhoud;
            Bestandlocatie = bestandlocatie;
            AccountName = accountName;
        }
    }
}