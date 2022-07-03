using System;
using System.Collections.Generic;
using System.Runtime;

namespace GameL
{
    class Program
    {
        
        static int choice;
        static int pathways;
        static int rnd;
        static Random rand = new Random();
        static string lastloc;
        static List<string> gpathways = null;

        static Item greydaggar = new Item("greydaggar", 0, 0, 2, 0, ConsoleColor.DarkGray);
        static Item Potion = new Item("Potion", 50, 0, 0, 0, ConsoleColor.Red);

        static List<Item> invntry = new List<Item>();
        static List<Item> goofinvntry = new List<Item>() { greydaggar };
        static List<Item> zombinvntry = new List<Item>() { Potion };

        static List<string> startpointpaths = new List<string>() { "path1", "path2" };
        static List<string> path1paths = new List<string>() { "valleyofchos", "valleyofGooZ", "startpoint" };
        static List<string> path2paths = new List<string>() { "startpoint", "Marketplace", "startpoint" };
        static List<string> valleyofGooZpaths = new List<string>() {"path1"};
        static List<string> MarketplacePaths = new List<string>() { "path2" };

        static Location startpoint = new Location("startpoing", startpointpaths, null);
        static Location valleyofGooZ = new Location("valleyofGooZ", valleyofGooZpaths, "GOOF");
        static Location path1 = new Location("path1", path1paths, null);
        static Location path2 = new Location("path2", path2paths, null);
        static Location Marketplace = new Location("Marketplace", MarketplacePaths, "ZOMB");

        static Character MainCharacter = new Character("MainCharacter", startpoint, 100, 100, 10, 5, invntry);
        static Character GOOF = new Character("GOOF", valleyofGooZ, 50, 100, 5, 5, goofinvntry);
        static Character ZOMB = new Character("ZOMB", Marketplace, 50, 100, 12, 5, zombinvntry);

        static Location returnLocation(string str)
        {
            if (str == "path1") { return path1; };
            if (str == "path2") { return path2; };
            if (str == "startpoint") { return startpoint; };
            if (str == "valleyofGooZ") { return valleyofGooZ; };
            if (str == "Marketplace") { return Marketplace; };
            return null;
        }
        static Character returnEnemy(string str)
        {
            if (str == "GOOF") { return GOOF; }
            if (str == "ZOMB") { return ZOMB; }
            return null;
        }
        static void action(char c)
        {
            if (c =='i')
            {
                Console.WriteLine("Your Inventory");
                Console.WriteLine();
                for(int i=0; i<=MainCharacter.Inventory.Count-1; i++)
                {
                    Console.WriteLine(MainCharacter.Inventory[i].name);
                }
            }
            if (c=='s')
            {
                Console.WriteLine("Your stats: ");
                Console.WriteLine();
                //TODO: color stuff
                Console.WriteLine("HP: " + MainCharacter.HP.ToString() + " MP:" + MainCharacter.MP.ToString()+" Current DMG: "+MainCharacter.DMG.ToString());
            }
            if(c=='m')
            {
                Console.WriteLine("          startpoint");
                Console.WriteLine("path1                     path2 ");
            }    
        }
        static void Main(string[] args)
        {
            int pathchoice;
            while(1==1)
            {
                Console.Write("Now entering ");
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine(MainCharacter.loc.locname);
                Console.ForegroundColor = ConsoleColor.Gray;
                if (MainCharacter.loc.enemies!=null)
                {
                    Fight(MainCharacter, returnEnemy(MainCharacter.loc.enemies));
                }
                pathways = MainCharacter.loc.GetPathwaysNum();
                gpathways = MainCharacter.loc.GetPathways();
                Console.WriteLine("Choose Path");
                for(int i=0; i<pathways; i++)
                {
                    Console.Write((i+1).ToString() + ": " + gpathways[i].ToString()+"    ");
                }
                Console.WriteLine();
                lastloc = MainCharacter.loc.locname;
                var e = Console.ReadLine();
                try
                {
                    pathchoice = int.Parse(e);
                    MainCharacter.loc = returnLocation(gpathways[pathchoice - 1]);
                }
                catch(FormatException)
                {
                    e=e.ToString();
                    action(e.ToCharArray()[0]);
                }
                //MainCharacter.loc = (Location)Enum.Parse(typeof(Location), gpathways[int.Parse(Console.ReadLine()) - 1], true); --- Try new way to get loc name
                Console.WriteLine();             
            }
        }
        public static void Fight(Character main, Character Mob)
        {
            if(Mob.HP>0)
            {
                Console.Write("FIGHT VS ");
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine(Mob.name);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("YOUR HP: " + main.HP.ToString() + " HIS HP: " + Mob.HP.ToString());
            }
            bool run = false;
            while (main.HP > 0 && Mob.HP > 0 && run == false)
            {
                Console.WriteLine("1: Hit    2: Run");
                var e = Console.ReadLine();
                try
                {
                    choice = int.Parse(e);
                    if (choice == 1)
                    {
                        rnd = rand.Next(99);
                        if (rnd<=main.CRIT)
                        {
                            Console.WriteLine("CRITICALL!!@$$");
                            Mob.HP = Mob.HP - (main.DMG * 2);
                            Console.Write("You  ");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("CRIT ");
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(" for ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(main.DMG*2);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        else
                        {
                            Mob.HP = Mob.HP - main.DMG;
                            Console.Write("You deal ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write(main.DMG);
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                        Console.Write(" DMG to ");
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine(Mob.name);
                        Console.Write(Mob.name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" hp is " + Mob.HP.ToString());
                        main.HP = main.HP - Mob.DMG;
                        Console.WriteLine();
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.Write(Mob.name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" deals ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(Mob.DMG);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine(" DMG to you");
                        Console.WriteLine("Your HP is " + main.HP);
                    }
                    if (choice == 2)
                    {
                        run = true;
                        main.loc = returnLocation(lastloc);
                    }
                }
                catch (FormatException)
                {
                    e = e.ToString();
                    action(e.ToCharArray()[0]);
                }
                if (Mob.HP<=0)
                {
                    int pickchoice = 0;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Mob.name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine(" is dead");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(Mob.name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //TODO: multiple drops and collect
                    Console.Write(" dropped ");
                    //set console color to item rarity
                    Console.ForegroundColor = Mob.Inventory[0].clr;
                    //Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Mob.Inventory[0].rarecolor, true);
                    Console.WriteLine(Mob.Inventory[0].name);
                    Console.ForegroundColor = ConsoleColor.Gray;
                    //end
                    Console.WriteLine("Pick items?");
                    Console.WriteLine("1: YES    2: NO");
                    pickchoice = int.Parse(Console.ReadLine());
                    if (pickchoice==1)
                    {
                        MainCharacter.Inventory.Add(Mob.Inventory[0]);
                        Console.Write("you now have in your inventory ");
                        //set console color to item rarity
                        Console.ForegroundColor = Mob.Inventory[0].clr;
                        //Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), Mob.Inventory[0].rarecolor, true);
                        Console.WriteLine(Mob.Inventory[0].name);
                        Console.ForegroundColor = ConsoleColor.Gray;
                        //end
                    }
                    if (pickchoice==2)
                    {

                    }
                }
            }
        }
    }
}
