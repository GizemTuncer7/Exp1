using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Casino
{
    public class Dice
    {
        private int minBet = 40;
        Random randomDice=new Random();
        public int playerDice1, houseDice1, playerDice2, houseDice2, playerTotal, houseTotal;
        
        public void introDice()
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Dice Game...");
            Console.WriteLine("Min bet is set to " + minBet+" for this gamemode");
            Console.WriteLine("You roll the dice");
            Console.WriteLine("House rolls the dice");
            Console.WriteLine("If house rolls the dice higher, you lose your bet");
            Console.WriteLine("If you roll the dice higher, you win the amount you bet");
            Console.WriteLine("Press any key to start       Exit:E");
            Lobby.status = Console.ReadKey();
            if(Lobby.status.Key == ConsoleKey.E)
            {
                
                Lobby.enter();
                Lobby.chooseGame();
            }
            
        }
        public void infoDice()
        {
            Console.Clear();
            Console.WriteLine("You have " +Player.credits+" credits.");
            Console.WriteLine("Choose a bet amount:");
            Player.betAmount=Convert.ToInt32(Console.ReadLine());
            if (Player.betAmount < minBet)
            {
                Console.WriteLine("Bet can not be smaller than the minimum bet amount...");
                Thread.Sleep(3000);
                infoDice();
            }
            if (Player.credits < Player.betAmount)
            {
                Console.WriteLine("Insufficient credits...");
                infoDice();
            }
        }
        public void startDiceGame()
        {
            Console.Clear();
            Console.WriteLine("Bet amount: {0} Credits left: {1} Minimum Bet: {2}",Player.betAmount,Player.credits-Player.betAmount,minBet);
            Console.WriteLine("Please do not press any keys, just wait...");
            Thread.Sleep(3000);
            playerDice1 = randomDice.Next(1, 7);
            playerDice2 = randomDice.Next(1, 7);
            playerTotal = playerDice1 + playerDice2;
            Console.WriteLine("Player rolled {0},{1}.", playerDice1, playerDice2);
            Thread.Sleep(1000);
            houseDice1 = randomDice.Next(1, 7);
            houseDice2 = randomDice.Next(1, 7);
            houseTotal=houseDice1 + houseDice2;
            Console.WriteLine("House rolled {0},{1}.", houseDice1, houseDice2);

            Thread.Sleep(1000);
            if (playerTotal < houseTotal)
            {
                Player.credits -= Player.betAmount;
                Console.WriteLine("You lost, credits left: {0}", Player.credits);
                

            }
            else if(playerTotal > houseTotal)
            {
                Player.credits += Player.betAmount;
                Console.WriteLine("You win, credits: {0}", Player.credits);
            }
            else if(houseTotal == playerTotal)
            {
                Console.WriteLine("Equal rolls, you do not lose or win...");
                
                
            }
            Thread.Sleep(3000);
            Console.Clear();
            Console.WriteLine("Roll one more? Y/N");
            Lobby.status = Console.ReadKey();
            if (Lobby.status.Key == ConsoleKey.Y)
            {
                Console.Clear();
                infoDice();
                startDiceGame();

            }
            else if(Lobby.status.Key == ConsoleKey.N)
            {
                Console.Clear();
                Lobby.enter();
                Lobby.chooseGame();
            }
            

        }

    }
}
