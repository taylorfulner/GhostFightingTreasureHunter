using System;
using TreasureHunter;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunter
{
    public class Level1
    {
        private int _lives = 6;
        private int _gems = 0;
        public List<string> RoomCollection = new List<string> { "LIVING ROOM", "KITCHEN", "DINING ROOM", "BATHROOM", "BEDROOM", "BEDROOM TWO" };


        public void Run()
        {
            Console.WriteLine($"Welcome to Ghost Fightin' Treasure Hunter\n" +
                $"RULES: You are on a mission to collect the gems!  They are hidden in a house that is reported to be haunted - but you don't beieve in ghosts.  Go through each room and collect your treasure!"); 
            Console.ReadLine();

            Level1 menu = new Level1();
            menu.StartLevel1();
        }

        public void Menu()
        {
            Console.WriteLine($"Lives Left: {_lives}\n" +
                    $"Gems Collected: {_gems} \n\n" +
                    $"Type RESTART to start over.\n" +
                    $"***********************************************");
            Console.WriteLine($"Please choose a room:");

            foreach (string room in RoomCollection)
            {
                Console.WriteLine($"  {room}");
            }
            Console.WriteLine();
        }

        public void StartLevel1()
        {
            
            while (_lives >= 1)
            {

                Menu();
                string input = Console.ReadLine();

                RoomCollection.Remove(input.ToUpper());

                switch (input.ToUpper()) //menu doesn't keep going if you put the invalid number
                {
                    case "LIVING ROOM":
                        EnterRoom();
                        break;
                    case "KITCHEN":
                        EnterRoom();
                        break;
                    case "DINING ROOM":
                        EnterRoom();
                        break;
                    case "BEDROOM":
                        EnterRoom();
                        break;
                    case "BATHROOM":
                        EnterRoom();
                        break;
                    case "BEDROOM TWO":
                        EnterRoom();
                        break;
                    case "restart":
                        GameResult();
                        Console.ReadLine();
                        Console.Clear();
                        Run();
                        break;
                    default:
                        Console.WriteLine("please enter a valid number");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void GameResult()
        {
            Console.WriteLine($"You have {_gems} gems! You thought you won - however - the ghosts locked you in! You must fight the ghosts and find the key to keep your treasure.  Drink this to restore your health!  Press enter to continue your journey.");
            Console.ReadLine();
            Console.Clear();
            Run();
        }
        public int RollDice()
        {
            Random diceRoll = new Random();
            int ghostAttack = diceRoll.Next(1, 7);
            return ghostAttack;
        }

        public void EnterRoom()
        {

            Console.Clear();

            Random gem = new Random();
            bool HasGem = gem.Next(0, 2) > 0;

            if (HasGem == true)
            {
                Console.WriteLine("You find a gem!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This room is empty. Try another room.");
                Console.ReadLine();
                Console.Clear();
                StartLevel1();
            }

            Random ghost = new Random();
            bool HasGhost = ghost.Next(0, 2) > 0;

            if (HasGhost == true)
            {
                Console.WriteLine("You encounter a ghost!\n" +
                    "Press enter to roll the dice and attack the ghost");
                Console.ReadLine();
                int ghostAttack = RollDice();
                Console.WriteLine($"You rolled a {ghostAttack}");

                while (ghostAttack <= 3)
                {
                    _lives--;
                    Console.WriteLine($"sorry. You now have {_lives} lives.");
                    if (_lives == 0)
                    {
                        Console.WriteLine("you died. Try again?");
                        Console.ReadLine();
                        Console.Clear();
                        Run();
                    }
                    else
                    {
                        Console.WriteLine("try again! Press enter to attack again.");
                        Console.ReadLine();
                        ghostAttack = RollDice();
                        Console.WriteLine($"You rolled a {ghostAttack}");
                    }
                }
                Console.WriteLine("You defeat the ghost! Press enter to pick up the gem.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Press enter to pick up the gem and run away before a ghost gets here!");
                Console.ReadLine();
            }
            _gems++;
            Console.WriteLine($"You now have {_gems} gems. Press enter to select the next room");
            Console.ReadLine();
            Console.Clear();

            int roomCount = RoomCollection.Count();
            if (roomCount == 0)
            {
                GameResult();

            }
        }
    }
}
