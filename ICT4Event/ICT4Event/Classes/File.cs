using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class File : Post
    {
        public int TypeBestand
        {
            get;
            set;
        }

        public Category Category
        {
            get;
            set;
        }

        public string FileLocation
        {
            get;
            set;
        }

        public long Size
        {
            get;
            set;
        }

        public File(DateTime Date, int Likes, int Map, int Post, int Reports, string Title, string Type, string FileLocation, long Size, int typeBestand)
            : base(Date, Likes, Map, Post, Reports, Title, Type)
        {
            this.Category = Category;
            this.FileLocation = FileLocation;
            this.Size = Size;
            this.TypeBestand = typeBestand;
        }

    }
}