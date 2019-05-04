using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Roulette2
{
    class Roulette
    {
        public void roulette()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Random random = new Random();
            var r = new Roulette();
            var ran = new Random();
            string[] color = { "Red", "Black" };
            int[] number = { 0, 00, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,
            16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 39, 31, 32, 33, 34, 35, 36 };
            string choice;
            int attempts = 0;
            int bet;
            int money = 500;

            while (money != 0)
            {
                Console.WriteLine("Welcome to the game of blackjack! Wish to try your luck? Read the options below.\n");
                Console.WriteLine($"Money: ${money}                          Attempts:{ attempts }" + "\n");
                Console.WriteLine("Options                                                                                   Odds\n");
                Console.WriteLine(
                "a. Evens                                                                                  1:1\n" +
                "b. Odds                                                                                   1:1\n" +
                "c. Reds                                                                                   1:1\n" +
                "d. Blacks                                                                                 1:1\n" +
                "e. Lows(1-18)                                                                             1:1\n" +
                "f. Highs(19-36)                                                                           1:1\n" +
                "g. Dozens: 1-12                                                                           2:1\n" +
                "h. Dozens: 13-24,                                                                         2:1\n" +
                "i. Dozens: 25-36                                                                          2:1\n" +
                "e. Columns: First, Second, or Third Columns                                               2:1\n" +
                "f  6 Numbers: Double Rows, e.g. 1/2/3/4/5/6 or 22/23/24/25/26                             5:1\n" +
                "g  Corner: At the intersection of any four contiguous numbers e.g. 1/2/4/5 or 23/24/26/27 8:1\n" +
                "h. Street: Rows, e.g. 1/2/3 or 22,23,24                                                   11:1\n" +
                "i. Split: At the edge of any two contiguous numbers, e.g. 1/2, 11/14, and 35/36           17:1\n" +
                "j. Individual Number: 0, 00, 1-36                                                         35:1\n");
                Console.WriteLine("Where would you like to place your money? Please select an appropriate letter.");
                choice = (Console.ReadLine());
                choice.ToLower();
                bool check =
                    choice == "a" ||
                    choice == "b" ||
                    choice == "c" ||
                    choice == "d" ||
                    choice == "e" ||
                    choice == "f" ||
                    choice == "g" ||
                    choice == "h" ||
                    choice == "i" ||
                    choice == "j";
                if (check == false)
                {
                    Console.WriteLine("Please select a valid input.");
                    Console.WriteLine("Please press 'Enter'.");
                    Console.ReadKey();
                    Console.Clear();
                    continue;
                }
                else
                {
                bet:
                    Console.WriteLine("How much money would you like to bet?");
                    bet = Convert.ToInt32(Console.ReadLine());
                    if (bet > money)
                    {
                        Console.WriteLine("You do not have enough money to make this bet!");
                        Console.WriteLine("Press 'Enter' to try again.");
                        Console.ReadKey();
                        goto bet;
                    }
                    else
                    {
                        money -= bet;
                        string ranColor = color[ran.Next(color.Length)];
                        int ranNumber = number[ran.Next(number.Length)];
                        bool even = ranNumber % 2 == 0;
                        int x;
                        if ((choice == "a" && even == true) || (choice == "b") && (even == false))
                        {
                            Console.WriteLine("The rouletter rolled: " + ranColor + " " + ranNumber);
                            Console.WriteLine("You won! +$" + bet + "!");
                            Console.WriteLine("Press 'Enter' to continue!");
                            money += (bet * 2);
                            attempts += 1;
                            Console.ReadKey();
                        }

                       // else if (choice == "c" && color == true) || (choice == "d") && (color == false))
                         //   {

                        //}
                        else
                        {
                            Console.WriteLine("The roulette rolled: " + ranColor + " " + ranNumber);
                            Console.WriteLine("You lost! -$" + bet + "!");
                            Console.WriteLine("<Press enter to continue>");
                            attempts += 1;
                            Console.ReadKey();
                            if (money == 0)
                            {
                                Console.WriteLine("You are out of money.");
                                Console.WriteLine("<Press enter to continue>");
                                Console.ReadKey();
                            }
                        }
                    }
                }
                Console.Clear();
            }
        }

        private static void Lose(ref int attempts, int bet, ref int money, string ranColor, int ranNumber)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine($"The roulette rolled: {ranColor + " " + ranNumber}");
            Console.WriteLine($"HA! loser, you lost... {bet}");
            Console.WriteLine("<Press Enter to continue>");
            Console.ResetColor();
            money -= bet;
            attempts += 1;
            Console.ReadKey();
            if (money <= 0)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("You're out of money, you should probably go home.");
                Console.WriteLine("<Press Enter to continue>");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}
    

