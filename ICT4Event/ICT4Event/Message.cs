using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Message : Post
    {
        public string Content
        {
            get;
            set;
        }

        //alles
        public Message(DateTime Date, int Likes, int Map, int Post, int Reports, string Title, string Type, string Content)
            : base(Date, Likes, Map, Post, Reports, Title, Type)
        {
            this.Content = Content;
        }

        public Message(DateTime Date, int Likes, int Map, int Reports, string Title, string Type, string Content)
            : base(Date, Likes, Map, Reports, Title, Type)
        {
            this.Content = Content;
        }

        public Message(string Title, string Content)
            : base(Title)
        {
            this.Content = Content;
        }
    }
}