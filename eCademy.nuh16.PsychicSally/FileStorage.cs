using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eCademy.nuh16.PsychicSally
{
    public class FileStorage : IHighScoreStorage
    {
        private string filename;

        public FileStorage(string filename)
        {
            this.filename = filename;
        }
        public List<Scoring> Load()
        {
            throw new NotImplementedException();
        }

        public void Save(List<Scoring> scores)
        {
            throw new NotImplementedException();
        }
    }
}
