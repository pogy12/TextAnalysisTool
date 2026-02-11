using System.Collections.Generic;

namespace TextAnalysisTool
{
    internal class wordRecord
    {
        private string word;
        private int length, occurences;
        private int line;
        private List<int> lines;

        public wordRecord(string word, int line)
        {
            this.word = word;
            this.length = word.Length;
            this.occurences = 1;
            this.lines = new List<int> { line };
        }

        public string Word
        {
            get { return word; }
            set { this.word = value; }
        }

        public int Length
        {
            get { return length; }
            set { this.length = value; }
        }

        public int Occurences
        {
            get { return occurences; }
            set { this.occurences = value; }
        }

        public List<int> Lines
        {
            get { return lines; }
            set { lines = value; }
        }
    }
}
