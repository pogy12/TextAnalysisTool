using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextAnalysisTool
{
    internal class Program
    {
        static string fileName = "sherlock.txt"; //file to read
        static string[] linesInFile;
        static void Main(string[] args)
        {

            BinaryTree binTree = readFileWords();

            int numWords = binTree.Count();
            Console.WriteLine("There are " + numWords + " unique words in this text");
            Console.WriteLine();
            binTree.InOrder();
            Console.WriteLine();

            wordRecord longest = binTree.LongestWord();
            Console.WriteLine("The longest word stored is '" + longest.Word + "', with a length of " + longest.Length + " and " + longest.Occurences + " occurences");
            Console.WriteLine();

            wordRecord frequent = binTree.MostFrequent();
            Console.WriteLine("The most frequent word stored is '" + frequent.Word + "', with " + frequent.Occurences + " occurences");
            Console.WriteLine();

            Console.WriteLine("Enter word:");
            string specificWord = Console.ReadLine();
            binTree.FindLines(specificWord);
            Console.WriteLine();
            binTree.FindFrequency(specificWord);
            //Console.WriteLine("frequency= " + frequency);
            Console.ReadKey();
        }

        static Boolean isWord(string str) //uses regular expression to check str is a letters only
        {
            return Regex.IsMatch(str, @"\b(?:[a-z]{2,}|[ai])\b", RegexOptions.IgnoreCase);
        }

        static BinaryTree readFileWords()
        {
            linesInFile = File.ReadAllLines(fileName);
            int lineNumber = 0;
            BinaryTree tree = new BinaryTree();
            //delimiters are chars that split words in a text file
            char[] delimiters = { ' ', ',', '"', ':', ';', '?', '!', '-', '.', '\'', '*' };
            foreach (string line in linesInFile) //take each line string form the file one at a time
            {
                lineNumber++; //increment the current line number
                              //split up line into separate words using any delimiter - array of strings, each element is a word on the current line
                string[] wordsInLine = line.Split(delimiters, System.StringSplitOptions.RemoveEmptyEntries);
                //Console.Write(lineNumber + ":"); //display file line number
                foreach (string word in wordsInLine)
                {
                    if (isWord(word))
                    {
                        wordRecord record = new wordRecord(word.ToLower(), lineNumber);
                        tree.InsertItem(record);
                    }
                }
            }
            return tree;
        }
    }
}