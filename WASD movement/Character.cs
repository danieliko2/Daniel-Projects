using System;
using System.Collections.Generic;
using System.Text;

namespace GameL
{
    class Character
    {
        public string name;
        public Location loc;
        public int HP;
        public int MP;
        public int DMG;
        public int CRIT;
        public List<Item> Inventory;
        public Character(string name, Location loc, int HP, int MP, int DMG, int CRIT, List<Item> Inventory)
        {
            this.name = name;
            this.HP = HP;
            this.MP = MP;
            this.DMG = DMG;
            this.CRIT = CRIT;
            this.loc = loc;
            this.Inventory = Inventory;
        }
    }
}
