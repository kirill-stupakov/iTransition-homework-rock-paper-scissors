using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace GeneralizedRockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length % 2 == 0)
            {
                Console.WriteLine("Invalid options: number of moves must be odd.");
                return;
            }

            if (args.Length != args.Distinct().Count())
            {
                Console.WriteLine("Invalid options: moves must not repeat.");
                return;
            }

            var sec = new Security();
            var a = new Table(args);
            var judge = new Judge(args.Length);

            bool gameFinished = false;

            while (!gameFinished)
            {
                var key = sec.GenerateKey();
                var computerMove = RandomNumberGenerator.GetInt32(args.Length);
                var hmac = sec.GenerateHMAC(key, args[computerMove]);

                Console.WriteLine("HMAC: " + hmac);

                Console.WriteLine("Available Moves:");
                for (int i = 0; i < args.Length; i++)
                {
                    Console.WriteLine(i + 1 + " - " + args[i]);
                }
                Console.WriteLine("0 - Exit");
                Console.WriteLine("? - Help");

                Console.Write("Enter your move: ");
                var ans = Console.ReadLine();

                if (ans == "?")
                {
                    a.Print();
                    continue;
                }

                if (ans == "0")
                {
                    gameFinished = true;
                    continue;
                }

                int playerMove = 0;

                if (!int.TryParse(ans, out playerMove) || playerMove <= 0 || playerMove > args.Length)
                {
                    continue;
                }

                Console.WriteLine("Your move: " + args[playerMove - 1]);
                Console.WriteLine("Computer move: " + args[computerMove]);

                switch (judge.Decide(computerMove, playerMove - 1))
                {
                    case Outcome.WIN:
                        Console.WriteLine("You won!");
                        break;

                    case Outcome.LOSE:
                        Console.WriteLine("You lost!");
                        break;

                    default:
                        Console.WriteLine("Draw!");
                        break;
                }

                Console.WriteLine("HMAC key: " + key);

                Console.WriteLine();
                Console.WriteLine();
            }
        }
    }
}
