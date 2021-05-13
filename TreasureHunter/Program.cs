using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunter
{
    public class Program
    {
        static void Main()
        {
            Program menu = new Program();
            menu.Run();
        }

        public void Run()
        {
            Console.WriteLine($"Welcome to Ghost Fightin' Treasure Hunter\n" +
                $"RULESSSS**********"); //add rules
            Console.ReadLine();

            Level1 menu = new Level1();
            menu.StartLevel1();
        }
    }
}
