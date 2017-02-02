using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            int input;
            do
            {
                Console.Clear();
                Console.WriteLine("1) Start game");
                Console.WriteLine("2) End game");
                input = int.Parse(Console.ReadLine());
                if (input == 1)
                {
                    List<Player> players = definePlayers();
                    defineHand(players);
                    compareHands(players);
                }
            } while (input != 2);
        }

        public static List<Player> definePlayers()
        {
            List<Player> players = new List<Player>();
            for (int i = 0; i < 2; i++)
            {
                Console.Clear();
                string name;
                Console.WriteLine($"Player {i}, enter your name");
                name = Console.ReadLine();
                players.Add(new Player { Name = name });
            }
            return players;
        }

        public static List<Player> defineHand(List<Player> players)
        {

            foreach (Player p in players) //0 --> 1
            {
                Console.Clear();
                Console.WriteLine($"{p.Name} select your hand");
                Console.WriteLine("1) Rock\n2) Paper\n3) Scissor");
                // 1 = Rock, 2 = Paper and 3 = Scissors
                p.Hand = int.Parse(Console.ReadLine());
            }
            return players;
        }

        public static string CompareHandsHelper(List<Player> players)
        {           
            // 1 = Rock, 2 = Paper and 3 = Scissors
            if (players[0].Hand == players[1].Hand)
            {
                return "Draw";
            }


            if (players[0].Hand == 1 && players[1].Hand == 3) // Rock vs Scissors = Rock wins	
            {
                return players[0].Name;
            }


            if (players[0].Hand == 1 && players[1].Hand == 2) // Rock vs Paper = Paper wins
            {
                return players[1].Name;
            }


            if (players[0].Hand == 3 && players[1].Hand == 1) // Scissors vs Rock = Rock wins	
            {
                return players[1].Name;
            }


            if (players[0].Hand == 3 && players[1].Hand == 2) //Scissors vs Paper = Scissors wins	
            {
                return players[0].Name;
            }


            if (players[0].Hand == 2 && players[1].Hand == 3) //Paper vs Scissors = Scissors wins	
            {
                return players[1].Name;
            }

            else // Paper vs Rock = Paper wins
            {
                return players[0].Name;
            }
        }

        public static void compareHands(List<Player> players)
        {
            string winner = CompareHandsHelper(players);
            Console.Clear();
            if (winner == players[0].Name)
            {
                Console.WriteLine($"{players[0].Name} won!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if (winner == players[1].Name)
            {
                Console.WriteLine($"{players[1].Name} won!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
            if(winner != players[0].Name && winner != players[1].Name)
            {
                Console.WriteLine("Draw!");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
            }
        }
    }
}
