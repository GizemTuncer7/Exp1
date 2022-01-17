using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Casino
{
    public class Guess
    {
        private int minBet = 10;
        public int randomNumber;
        public int guessNumber;
        public void introGuess()
        {
            Console.WriteLine("Welcome to the Guess Game");
            Console.WriteLine("Place a bet and guess a number between 1 and 10");
            Console.WriteLine("If you guess correctly you win the amount you bet");
            Console.WriteLine("If you fail to guess your bet will be lost");
            Console.WriteLine("In case you lose, the game will tell you whether your guess was too high or too low");
            Console.WriteLine("You can keep betting according to high/low");
            Console.WriteLine("Press any key to start           Exit:E");
            if (Lobby.status.Key == ConsoleKey.E)
            {
                Lobby.enter();
                Lobby.chooseGame();
            }
            randomNumber = new Random().Next(1, 11);
    }
        public void infoGuess()
        {
            Console.Clear();
            Console.WriteLine("You have " + Player.credits + " credits.");
            Console.WriteLine("Choose a bet amount:");
            Player.betAmount = Convert.ToInt32(Console.ReadLine());
            if (Player.betAmount < minBet)
            {
                Console.WriteLine("Bet can not be smaller than the minimum bet amount...");
                Thread.Sleep(3000);
                infoGuess();
            }
            if (Player.credits < Player.betAmount)
            {
                Console.WriteLine("Insufficient credits...");
                infoGuess();
            }
        }
        public void startGuessGame()
        {
            Console.Clear();
            Console.WriteLine("Bet amount: {0} Credits left: {1} Minimum Bet: {2}", Player.betAmount, Player.credits - Player.betAmount, minBet);
            Thread.Sleep(1000);
            Console.WriteLine("Take a guess between 1-10");
            guessNumber = GetGuess();
            if (guessNumber == randomNumber)
            {
                Console.WriteLine("Your guess is correct");
                Player.credits += Player.betAmount;
                Console.WriteLine("You won and your credit is: {0}", Player.credits);
                Thread.Sleep(1000);
                Console.Clear();
                Console.WriteLine("Guess once more? Y/N");
                Lobby.status = Console.ReadKey();
                if (Lobby.status.Key == ConsoleKey.Y)
                {
                    introGuess();
                    infoGuess();
                    startGuessGame();
                }
                else if (Lobby.status.Key == ConsoleKey.N)
                {
                    Console.Clear();
                    Lobby.enter();
                    Lobby.chooseGame();

                }
            }
            else if (guessNumber < randomNumber)
            {
                Console.WriteLine("Your guess was too low");
                Player.credits -= Player.betAmount;
                Console.WriteLine("You lost and your credit is: {0}", Player.credits);



            }
            else if (guessNumber > randomNumber)
            {
                Console.WriteLine("Your guess was too high");
                Player.credits -= Player.betAmount;
                Console.WriteLine("You lost and your credit is: {0}", Player.credits);
            }
            Thread.Sleep(1000);
            Console.Clear();
            Console.WriteLine("Guess once more? Y/N");
            Lobby.status = Console.ReadKey();
            if (Lobby.status.Key == ConsoleKey.Y)
            {
                infoGuess();
                startGuessGame();
            }
            else if (Lobby.status.Key == ConsoleKey.N)
            {
                Console.Clear();
                Lobby.enter();
                Lobby.chooseGame();

            }
        }
        private static int GetGuess()
        {
            int guessNumber;
            try
            {
                guessNumber = Convert.ToInt32(Console.ReadLine());
            }

            catch (Exception)
            {
                Console.WriteLine("You did not enter a valid guess.");
                guessNumber = GetGuess();
            }

            return guessNumber;

        }


    }
}
