using System;

namespace TextAnalysisTool
{
    internal class BinaryTree
    {
        private Node root;
        private int occurence;
        public BinaryTree()
        {
            root = null;
        }
        public BinaryTree(Node node)

        {
            root = node;
        }

        public void InOrder()
        {
            inOrder(root);
        }

        private void inOrder(Node tree)
        {
            if (tree != null)
            {
                inOrder(tree.Left);
                Console.Write("The word '" + tree.Data.Word + "' has a length of " + tree.Data.Length + ", and occurs " + tree.Data.Occurences);
                if (tree.Data.Occurences > 1)
                {
                    Console.Write(" times on lines ");
                }
                else
                {
                    Console.Write(" time on line ");
                }    
                occurence = 0;
                foreach (int line in tree.Data.Lines)
                {
                    occurence ++;
                    Console.Write(line);
                    if (occurence == tree.Data.Occurences)
                    {
                        Console.Write(".");
                    }
                    else if (occurence == tree.Data.Occurences - 1)
                    {
                        Console.Write(" and ");
                    }
                    else if (tree.Data.Occurences > 1)
                    {
                        Console.Write(", ");
                    }
                }
                Console.WriteLine();
                inOrder(tree.Right);
            }


        }
        private void insertItem(wordRecord item, ref Node tree)
        {
            if (tree == null)
            {
                tree = new Node(item);
            }
            else
            {
                if (String.Compare(item.Word, tree.Data.Word, true) < 0)
                {
                    insertItem(item, ref tree.Left);
                }
                else if (String.Compare(item.Word, tree.Data.Word, true) > 0)
                {
                    insertItem(item, ref tree.Right);
                }
                else
                {
                    tree.Data.Occurences++;
                    tree.Data.Lines.Add(item.Lines[0]);
                }
            }
        }

        public void InsertItem(wordRecord item)
        {
            insertItem(item, ref root);
        }

        public int Count()
        {
            return count(root);
        }

        private int count(Node tree)
        {
            if (tree == null)
            {
                return 0;
            }
            return count(tree.Left) + count(tree.Right) + 1;
        }
        public wordRecord LongestWord()
        {
            return longestWord(root);
        }

        private wordRecord longestWord(Node tree)
        {
            wordRecord longest;
            if (tree == null)
            {
                return null;
            }
            longest = tree.Data;
            wordRecord left = longestWord(tree.Left);
            if (left != null)
            {
                if (left.Length > longest.Length)
                {
                    longest = left;
                }
            }
            wordRecord right = longestWord(tree.Right);
            if (right != null)
            {
                if (right.Length > longest.Length)
                {
                    longest = right;
                }
            }

            return longest;
        }

        public wordRecord MostFrequent()
        {
            return mostFrequent(root);
        }

        private wordRecord mostFrequent(Node tree)
        {
            wordRecord frequent;
            if (tree == null)
            {
                return null;
            }
            frequent = tree.Data;
            wordRecord left = mostFrequent(tree.Left);
            if (left != null)
            {
                if (left.Occurences > frequent.Occurences)
                {
                    frequent = left;
                }
            }
            wordRecord right = longestWord(tree.Right);
            if (right != null)
            {
                if (right.Occurences > frequent.Occurences)
                {
                    frequent = right;
                }
            }

            return frequent;
        }

        public void FindLines(string word)
        {
            findLines(root, word);
        }

        private void findLines(Node tree, string word)
        {
            if (tree != null)
            {
                if (tree.Data.Word == word.ToLower())
                {
                    occurence = 0;
                    Console.Write("The word '" + word + "' was found on line number ");
                    foreach (int line in tree.Data.Lines)
                    {
                        occurence++;
                        Console.Write(line);
                        if (occurence == tree.Data.Occurences)
                        {
                            Console.Write(".");
                        }
                        else if (occurence == tree.Data.Occurences - 1)
                        {
                            Console.Write(" and ");
                        }
                        else if (tree.Data.Occurences > 1)
                        {
                            Console.Write(", ");
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    findLines(tree.Left, word);
                    findLines(tree.Right, word);
                }
            }
        }

        public void FindFrequency(string word)
        {
            findFrequency(root, word);
        }

        private void findFrequency(Node tree, string word)
        {
            if (tree == null)
            {
                Console.WriteLine("The specified word does not appear in the text.");
            }
            else
            {
                if (String.Compare(tree.Data.Word, word.ToLower(), true) == 0)
                {
                    Console.WriteLine("The word '" + word + "' has a frequency of " + tree.Data.Occurences);
                }
                else if (String.Compare(tree.Data.Word, word.ToLower(), true) > 0)
                {
                    findFrequency(tree.Left, word);
                }
                else
                {
                    findFrequency(tree.Right, word);
                }
            }
        }
    }
}