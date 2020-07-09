using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program
{
    class ProgramUI //start location for the game
    {
        static void Main(string[] args)
        {
            //Create game
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(String.Format("{0," + Console.WindowWidth / 2 + "}", "---WELCOME TO WAR!---"));
            Console.ResetColor();
            

            
            Console.WriteLine("\n" +
                "Who is player 1?") ;
            string Player1 = Console.ReadLine();
            

            Console.WriteLine("Enter Player 2: ");
            string Player2 = Console.ReadLine();

            Console.Clear();
             
            //Start game
            Game game = new Game(Player1, Player2);
            while (!game.IsEndOfGame())
            {
                game.PlayTurn();
                Console.ReadLine();
                Console.Clear();
            }
            Console.Read();
        }
    }
}
