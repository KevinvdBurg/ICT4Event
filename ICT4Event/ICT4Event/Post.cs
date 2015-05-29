using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Post
    {
        public Account Account
        {
            get;
            set;
        }

        public int Postid
        {
            get;
            set;
        }


        public int Map
        {
            get;
            set;
        }

        public int ParentPost
        {
            get;
            set;
        }

        public DateTime Date
        {
            get;
            set;
        }

        public string Type
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public int Reports
        {
            get;
            set;
        }

        public int Likes
        {
            get;
            set;
        }

        //wel parent post
        public Post(DateTime Date, int Likes, int Map, int Post, int Reports, string Title, string Type)
        {
            //this.Account = Account;
            this.Date = Date;
            this.Likes = Likes;
            this.Map = Map;
            this.ParentPost = Post;
            this.Reports = Reports;
            this.Title = Title;
            this.Type = Type;
        }

        //geen een parent post
        public Post(DateTime Date, int Likes, int Map, int Reports, string Title, string Type)
        {
            //this.Account = Account;
            this.Date = Date;
            this.Likes = Likes;
            //this.Map = Map;
            this.Map = Map;
            this.Reports = Reports;
            this.Title = Title;
            this.Type = Type;
        }

        public Post(DateTime Date, string Title, string Type)
        {
            this.Date = Date;
            this.Title = Title;
            this.Type = Type;
        }

        public Post(int postid, int Likes, int Reports, string Title)
        {
            this.Likes = Likes;
            this.Postid = postid;
            this.Reports = Reports;
            this.Title = Title;
        }

        public Post(string Title)
        {
            this.Title = Title;
        }
    }
}