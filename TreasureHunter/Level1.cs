using System;
using TreasureHunter;
using System.Collections.Generic;
using System.Linq;

namespace TreasureHunter
{
    public class Level1
    {
        private int _lives = 4;
        public int _gems = 0;
        public List<string> RoomCollection = new List<string> { "living room", "kitchen", "dining room", "bathroom", "bedroom", "bedroom two" };

        public void Menu()
        {
            Console.WriteLine($"Lives Left: {_lives}\n" +
                    $"Gems Collected: {_gems} \n\n" +
                    $"Type RESTART to start over.\n" +
                    $"***********************************************");
            Console.WriteLine($"Please Choose a Room:");

            foreach (string room in RoomCollection)
            {
                Console.WriteLine($"  {room.ToUpper()}");
            }
            Console.WriteLine();

            int roomCount = RoomCollection.Count();
            if (roomCount == 0)
            {
                GameResult();
            }
        }

        public void StartLevel1()
        {
            
            while (_lives >= 1)
            {

                Menu();
                string input = Console.ReadLine();

                RoomCollection.Remove(input.ToLower());

                switch (input.ToLower())
                {
                    case "living room":
                        EnterRoom();
                        break;
                    case "kitchen":
                        EnterRoom();
                        break;
                    case "dining room":
                        EnterRoom();
                        break;
                    case "bedroom":
                        EnterRoom();
                        break;
                    case "bathroom":
                        EnterRoom();
                        break;
                    case "bedroom two":
                        EnterRoom();
                        break;
                    case "restart":
                        GameResult();
                        Console.ReadLine();
                        Console.Clear();
                        Program startOver = new Program();
                        startOver.Run();
                        break;
                    default:
                        Console.WriteLine("Sorry, invalid selection. Press ENTER to select a room.");
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
        }

        public void GameResult()
        {
            Console.Clear();
            Console.WriteLine($"You made it out of the house with {_gems} gems and {_lives} lives! Play again?");
            Console.ReadLine();
            Console.Clear();
            Program menu = new Program();
            menu.Run();

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

            Random ghost = new Random();
            int HasGhost = ghost.Next(1, 7);

            if (HasGhost >= 3)
            {
                Console.WriteLine("You encounter a ghost!\n" +
                    "Press ENTER to roll the dice and attack the ghost");
                Console.ReadLine();
                int ghostAttack = RollDice();
                Console.WriteLine($"You rolled a {ghostAttack}");

                while (ghostAttack <= 3)
                {
                    _lives--;
                    Console.WriteLine($"Sorry. You now have {_lives} lives.");
                    if (_lives == 0)
                    {
                        Console.WriteLine("\nYOU DIED, TRY AGAIN?");
                        Console.ReadLine();
                        Console.Clear();
                        Program startOver = new Program();
                        startOver.Run();
                    }
                    else
                    {
                        Console.WriteLine("Try again! Press ENTER to attack again.");
                        Console.ReadLine();
                        ghostAttack = RollDice();
                        Console.WriteLine($"You rolled a {ghostAttack}");
                    }
                }
                Console.WriteLine("You defeat the ghost! Look for a gem in the room.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("There is no ghost in the room! Look for a gem in the room.");
                Console.ReadLine();
            }

            Random gem = new Random();
            int HasGem = gem.Next(1, 7);

            if (HasGem >= 4)
            {
                Console.WriteLine("You find a gem! Press ENTER to pick it up.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("This room is empty. Try another room.");
                Console.ReadLine();
                Console.Clear();
                StartLevel1();
            }

            _gems++;
            Console.WriteLine($"You now have {_gems} gems. Press ENTER to select the next room");
            Console.ReadLine();
            Console.Clear();
        }
    }
}
