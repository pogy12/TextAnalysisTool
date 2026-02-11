namespace TextAnalysisTool
{
    internal class Node
    {
        private wordRecord data;
        public Node Left, Right;

        public Node(wordRecord item)
        {
            data = item;
            Left = null;
            Right = null;
        }

        public wordRecord Data
        {
            set { data = value; }
            get { return data; }
        }

    }
}
