using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public struct Score
    {
        public Score(int guesses, double totalTime)
        {
            Guesses = guesses;
            TotalTime = totalTime;
        }

        public readonly int Guesses;
        public readonly double TotalTime;
    }
}
