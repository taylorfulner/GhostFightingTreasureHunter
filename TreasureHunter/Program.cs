using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunter
{
    public class Program
    {
        public static void Main()
        {
            Program menu = new Program();
            menu.Run();
        }

        public void Run()
        {
            Console.WriteLine($"Welcome to Ghost Fightin' Treasure Hunter\n" +
                $"RULES: You are on a mission to collect the gems!  They are hidden in a house that is reported to be haunted - but you don't beieve in ghosts.  Go through each room and search for treasure!"); //add rules
            Console.ReadLine();

            Level1 menu = new Level1();
            menu.StartLevel1();

        }
    }
}
