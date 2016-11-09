using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxTries = 5;
            var random = new Random();
            var numberToGuess = random.Next(0, 100);

            for (var i=0; i < maxTries; i++)
            {
                Console.Write("Skriv inn et tall mellom 1 og 100: ");
                var input = Console.ReadLine();
                int guessedNumber;
                if (int.TryParse(input, out guessedNumber))
                {
                    if (guessedNumber > numberToGuess)
                    {
                        Console.WriteLine("Feil. Du gjettet for høyt");
                    }
                    else if (guessedNumber < numberToGuess)
                    {
                        Console.WriteLine("Feil. Du gjettet for lavt");
                    }
                    else
                    {
                        Console.WriteLine("Gratulerer!");
                        break;
                    }
                }
            }

            Console.WriteLine("Trykk en tast for å avslutte");
            Console.ReadKey();
        }
    }
}
