using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public class Scoring
    {
        private string name;
        private Score score;
        public Scoring(string name, Score score)
        {
            this.name = name;
            this.score = score;
        }

        public string Name { get { return this.name; } }
        public Score Score { get { return this.score; } }

        public override string ToString()
        {
            return string.Join(",",
                name,
                score.Guesses,
                score.TotalTime.ToString(CultureInfo.InvariantCulture)
            );
        }

        public static Scoring Parse(string s)
        {
            var arr = s.Split(',');
            var name = arr[0];
            var guesses = int.Parse(arr[1]);
            var totalTime = double.Parse(arr[2], CultureInfo.InvariantCulture);

            var score = new Score(guesses, totalTime);
            var scoring = new Scoring(name, score);

            return scoring;
        }
    }
}
