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
            var game = new PsychicSally();
            foreach (var argument in args)
            { 
                var argumentParts = argument.Split('=');
                if (argument.ToLower().StartsWith("-maxtries"))
                {
                    var argumentName = argumentParts[0];
                    var argumentValue = argumentParts[1];
                    game.MaxTries = int.Parse(argumentValue);
                }
            }

            game.Start();


            Console.WriteLine("Trykk en tast for å avslutte");
            Console.ReadKey();
        }
    }
}
