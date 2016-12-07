using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public class InMemoryStorage : IHighScoreStorage
    {
        private static List<Scoring> Scorings = new List<Scoring>();

        public List<Scoring> Load()
        {
            return Scorings;
        }

        public void Save(List<Scoring> scorings)
        {
            Scorings = scorings;
        }
    }
}
