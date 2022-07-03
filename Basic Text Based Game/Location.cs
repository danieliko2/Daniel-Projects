using System;
using System.Collections.Generic;
using System.Text;

namespace GameL
{
    class Location
    {

        public  List<string> locations = new List<string>();
        public string locname;
        public string enemies;
        public int pathwaysnum;
        public Location(string locname, List<string> locations, string enemies)
        {
            this.locations = locations;
            this.locname = locname;
            pathwaysnum = locations.Count;
            this.enemies = enemies;
        }
        public List<string> GetPathways()
        {
            return locations;
        }
        public int GetPathwaysNum()
        {
            return pathwaysnum;
        }
        
    }
}
