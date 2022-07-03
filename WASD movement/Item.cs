using System;
using System.Collections.Generic;
using System.Text;

namespace GameL
{
    class Item
    {
        public string name;
        public int hpup;
        public int mpup;
        public int dmgup;
        public int critup;
        public ConsoleColor clr;
        public Item(string name, int hpup, int mpup, int dmgup, int critup, ConsoleColor clr)
        {
            this.name = name;
            this.hpup = hpup;
            this.mpup= mpup;
            this.dmgup = dmgup;
            this.critup = critup;
            this.clr = clr;
        }
    }
}
