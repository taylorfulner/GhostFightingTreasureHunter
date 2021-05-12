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
        public List<string> RoomCollection = new List<string> { "living room", "kitchen", "dining room", "bathroom", "bedroom", "bedroom two"};


        public void Run()
        {
            Console.WriteLine($"Welcome to Ghost Fightin' Treasure Hunter\n" +
                $"RULESSSS**********"); //add rules
            Console.ReadLine();

            Level1 menu = new Level1();
            menu.StartMenu();
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
                Console.WriteLine(room);
            }
            Console.WriteLine();
        }

        public void StartMenu()
        {
            
            while (_lives >= 1)
            {

                Menu();
                string input = Console.ReadLine();

                RoomCollection.Remove(input);

                switch (input.ToLower()) //menu doesn't keep going if you put the invalid number
                {
                    case "1":
                    case "one":
                    case "living room":
                        EnterRoom();
                        break;
                    case "2":
                    case "two":
                    case "kitchen":
                        EnterRoom();
                        break;
                    case "3":
                    case "three":
                    case "dining room":
                        EnterRoom();
                        break;
                    case "4":
                    case "four":
                    case "bedroom":
                        EnterRoom();
                        break;
                    case "5":
                    case "five":
                    case "bathroom":
                        EnterRoom();
                        break;
                    case "6":
                    case "six":
                    case "bedroom two":
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
            Console.WriteLine($"You win with {_gems} gems! Play again?");
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
                StartMenu();
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
