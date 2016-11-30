using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public class PsychicSally
    {
        public enum GuessResult {
            TooLow = -1,
            TooHigh = 1,
            Correct = 0
        }

        private static readonly Random random = new Random();

        private int numberToGuess;
        private int guesses;
        private DateTime startTime;
        private DateTime endTime;
        private bool guessedCorrectly;

        public int MaxTries { get; set; }

        public PsychicSally()
        {
            MaxTries = 10;
        }

        public void Start()
        {
            startTime = DateTime.Now;
            numberToGuess = random.Next(0, 100);
            guessedCorrectly = false;
            for (var i = 0; i < MaxTries; i++)
            {
                MakeNewGuess();
                if (guessedCorrectly)
                {
                    break;
                }
            }
        }

        private void MakeNewGuess()
        {
            guesses++;

            var result = Guess();
            HandleResult(result);
        }

        private void HandleResult(GuessResult result)
        {
            switch (result)
            {
                case GuessResult.TooLow:
                    Console.WriteLine("Du gjettet for lavt");
                    break;
                case GuessResult.TooHigh:
                    Console.WriteLine("Du gjettet for høyt");
                    break;
                case GuessResult.Correct:
                    guessedCorrectly = true;
                    Stop();
                    HandleCorrectGuess();
                    break;
            }
        }

        private void HandleCorrectGuess()
        {
            var totalTime = endTime.Subtract(startTime).TotalSeconds;
            Console.WriteLine(
                "Gratulerer! Du gjettet riktig på {0} forsøk og brukte {1} sekunder",
                guesses,
                totalTime);
        }

        private void Stop()
        {
            endTime = DateTime.Now;
        }

        private GuessResult Guess()
        {
            int guessedNumber = ReadNumber();
            int guessResult = guessedNumber.CompareTo(numberToGuess);

            var result = (GuessResult)guessResult;

            return result;
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
