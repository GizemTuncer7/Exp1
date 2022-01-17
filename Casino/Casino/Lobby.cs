using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Casino
{
    public class Lobby
    {
        static public ConsoleKeyInfo status;
        static public void enter()
        {
            Console.Clear();
            Console.WriteLine("Welcome                                                                                          You have {0} credits",Player.credits);


            Console.WriteLine("D for Dice Game");
            Console.WriteLine("G for Guess Game");
            Console.WriteLine("E for Exit");
            status = Console.ReadKey();
        }
            
           
        static public void chooseGame()
        {
            
            if (status.Key == ConsoleKey.D)
            {
                Console.Clear();
                Dice game = new Dice();
                game.introDice();
                status = Console.ReadKey();
                game.infoDice();
                game.startDiceGame();
            }

            else if (status.Key == ConsoleKey.G)
            {
                Console.Clear();
                Guess game = new Guess();
                game.introGuess();
                status = Console.ReadKey();
                game.infoGuess();
                game.startGuessGame();
            }
            
            else if (status.Key == ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("BYE BYE <3 <3");
                Thread.Sleep(3000);
                System.Environment.Exit(0);
            }
        }

           
        
    }
}
