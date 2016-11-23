using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    class Program
    {
        public static void Main(string[] args)
        {
            var maxTries = 5;
            foreach (var argument in args)
            { 
                var argumentParts = argument.Split('=');
                if (argument.ToLower().StartsWith("-maxtries"))
                {
                    var argumentName = argumentParts[0];
                    var argumentValue = argumentParts[1];
                    maxTries = int.Parse(argumentValue);
                }
            }
            var random = new Random();
            var numberToGuess = random.Next(0, 100);

            for (var i=0; i < maxTries; i++)
            {
                int guessedNumber = ReadNumber();

                if (guessedNumber > numberToGuess)
                {
                    Console.WriteLine("Du gjettet for høyt");
                }
                else if (guessedNumber < numberToGuess)
                {
                    Console.WriteLine("Du gjettet for lavt");
                }
                else
                {
                    Console.WriteLine("Gratulerer!");
                    break;
                }
            }

            Console.WriteLine("Trykk en tast for å avslutte");
            Console.ReadKey();
        }

        private static int ReadNumber()
        {
            Console.Write("Skriv inn et tall mellom 1 og 100: ");
            var input = Console.ReadLine();
            int guessedNumber;
            if (int.TryParse(input, out guessedNumber))
            {
                return guessedNumber;
            }
            else
            {
                Console.WriteLine("Du må skrive inn et gyldig heltall!");
                return ReadNumber();
            }
        }
    }
}
