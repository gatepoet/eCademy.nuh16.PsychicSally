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
        private int max = 100;
        private DateTime startTime;
        private DateTime endTime;
        private bool guessedCorrectly;
        private HighScore highScore;

        public int MaxTries { get; set; }

        public PsychicSally()
        {
            var storage = new InMemoryStorage();
            //var storage = new FileStorage("highscore.dat");
            MaxTries = 10;
            highScore = new HighScore(storage);
        }

        public void Start()
        {
            startTime = DateTime.Now;
            numberToGuess = random.Next(0, max);
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
            var score = GetScore();
            Console.WriteLine(
                "Gratulerer! Du gjettet riktig på {0} forsøk og brukte {1} sekunder",
                score.Guesses,
                score.TotalTime);


            //TODO: Add to highscore if good enough
            highScore.AddScore("Test", score);
            highScore.Print();
        }

        private Score GetScore()
        {
            var score = new Score();

            //TODO: Calculate total time and create Score object
            return score;
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
