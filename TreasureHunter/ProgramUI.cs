using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreasureHunter
{
    public enum RoomChoice { LivingRoom = 1, Kitchen, DiningRoom, Bedroom, Bathroom, SecondBedroom }
    public class ProgramUI
    {
        private int _lives = 1;
        private int _gems = 0;
        private bool HasGem = true;
        private bool HasGhost = true;

        public void Run()
        {
            Console.WriteLine($"Welcome to Ghost Fightin' Treasure Hunter\n" +
                $"RULESSSS**********");
            Console.ReadLine();

            ProgramUI menu = new ProgramUI();
            menu.Menu();

            //run the gem/ghost initialize here
        }

        public void Menu()
        {

            while (_lives >= 1 || _gems <= 2) 
            {
                Console.WriteLine($"Lives Left: {_lives}\n" +
                    $"Gems Collected: {_gems} / 3\n" +
                    $"***********************************************");
                Console.WriteLine($"Please choose a room\n" +
                $"1. Living Room\n" +
                $"2. Kitchen\n" +
                $"3. Dining Room\n" +
                $"4. Bedroom\n" +
                $"5. Bathroom\n" +
                $"6. Second Bedroom\n" +
                $"7. Restart Game");
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "one":
                    case "living room":
                        EnterRoom();
                        break;
                    case "2":
                    case "two":
                    case "kitchen":
                        //method
                        break;
                    case "3":
                    case "three":
                    case "dining room":
                        //method
                        break;
                    case "4":
                    case "four":
                    case "bedroom":
                        //method
                        break;
                    case "5":
                    case "five":
                    case "bathroom":
                        //method
                        break;
                    case "6":
                    case "six":
                    case "second bedroom":
                        //method
                        break;
                    case "7":
                    case "seven":
                    case "restart":
                        Console.WriteLine("Are you sure you want to restart? Press enter.");
                        Console.ReadLine();
                        Console.Clear();
                        Run();
                        break;
                    default:
                        Console.WriteLine("please enter a valid number");
                        Console.ReadLine();
                        break;
                }
            }
        }

        public void GameResult()
        {
            if (_lives == 0)
            {
                Console.WriteLine("You lose! Try again?"); //reset
                Console.Clear();
                Run();
            }
            else if (_gems == 3)
            {
                Console.WriteLine("You win! Play again?"); //reset
                Console.Clear();
                Run();
            }
            else
            {
                Console.WriteLine($"Lives Left: {_lives}\n" +
                $"Gems Collected: {_gems} / 3\n" +
                $"***********************************************");
            }
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

            if (HasGem == true)
            {
                Console.WriteLine("You find a gem!");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This room is empty. Try another room.");
                Console.ReadLine();
            }

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
                        //int tryAgain = RollDice();
                        //Console.WriteLine($"You rolled a {tryAgain}");
                    }
                }
                Console.WriteLine("You defeat the ghost. Press enter to pick up gem.");
                _gems++;
                Console.ReadLine();
                Console.WriteLine($"You now have {_gems}. Press enter to select the next room");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {

            }
        }
    }
}
