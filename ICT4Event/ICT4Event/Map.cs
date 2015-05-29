using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ICT4Event
{
    public class Map
    {
        public String Name
        {
            get;
            set;
        }

        public int ParentMap
        {
            get;
            set;
        }

        public int Mapid
        {
            get;
            set;
        }


        public Map(int mapid, string Name, int ParentMap)
        {
            this.Mapid = mapid;
            this.Name = Name;
            this.ParentMap = ParentMap;
        }

        public Map(int mapid, string name)
        {
            this.Mapid = mapid;
            this.Name = name;
        }
    }
}