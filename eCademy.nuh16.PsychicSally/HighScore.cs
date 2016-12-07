using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public class HighScore
    {
        private int size = 10;
        private List<Scoring> scores;
        private readonly IHighScoreStorage storage;

        public HighScore(IHighScoreStorage storage)
        {
            this.storage = storage;
            Load();
        }

        public void Save()
        {
            storage.Save(scores);
        }

        public void Load()
        {
            scores = storage.Load();
        }

        public void AddScore(string name, Score score)
        {
            scores.Add(new Scoring(name, score));
            ReorderAndResizeHistgScoreList();
            Save();
        }

        private void ReorderAndResizeHistgScoreList()
        {
            scores = scores
                .OrderBy(s => s.Score.Guesses)
                .ThenBy(s => s.Score.TotalTime)
                .Take(size)
                .ToList();
        }

        public bool IsScoreHighEnough(Score score)
        {
            if (HighScoreNotFull())
                return true;

            if (AnyScoreWithMoreGuesses(score))
                return true;

            if (AnyScoresWithLongerTime(score))
                return true;

            return false;
        }

        private bool AnyScoresWithLongerTime(Score score)
        {
            return scores.Any(s =>
                s.Score.Guesses == score.Guesses &&
                s.Score.TotalTime > score.TotalTime);
        }

        private bool AnyScoreWithMoreGuesses(Score score)
        {
            return scores.Any(s => s.Score.Guesses > score.Guesses);
        }

        private bool HighScoreNotFull()
        {
            return scores.Count < size;
        }

        public void Print()
        {
            var hallOfFame = ToHallOfFame();

            Console.WriteLine(hallOfFame);
        }

        private object ToHallOfFame()
        {
            var sb = new StringBuilder();
            sb.AppendLine("  -----------------------------  ");
            sb.AppendLine(" | Psycic Sally - Hall of Fame | ");
            sb.AppendLine(" |-----------------------------| ");
            for (int i = 0; i < scores.Count; i++)
            {
                var score = scores[i];
                sb.AppendFormat(
                    " | {0:00}. {1,-11}{2,4}{3,8:0.000} | ",
                    i + 1,
                    score.Name,
                    score.Score.Guesses,
                    score.Score.TotalTime);
                sb.AppendLine();
            }
            sb.AppendLine("  -----------------------------  ");
            sb.AppendLine();

            return sb.ToString();
        }
    }
}
