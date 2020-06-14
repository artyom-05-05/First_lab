using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Lab5
{
    class Program8
    {
        static readonly char[] symbols = { ' ', ',', ';', ':', '"', ')', '(', '-', '+', '@', '#', '$', '%', '^', '&', '*', '\"', '№', '/', '|', '<', '>', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };

        static void Main(string[] args)
        {
            string text;

            // Read text from file
            try
            {
                text = File.ReadAllText(args[0]);

            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка: {e.Message}");
                return;
            }

            SelectSentences(text);
        }

        static void SelectSentences(string text)
        {
            // Split text into sentences
            string[] sentences = text.Split(new char[] { '.', '?', '!' }, StringSplitOptions.RemoveEmptyEntries);
            int n = sentences.Length;

            // Delete spaces from the beginning
            for (int i = 0; i < n; i++) sentences[i] = sentences[i].TrimStart();

            // Create new array of sentences to work with
            string[] sentencesCopy = new string[n];
            Array.Copy(sentences, sentencesCopy, n);

            // Delete symbols from the beginning 
            for (int i = 0; i < n; i++) sentencesCopy[i] = sentencesCopy[i].TrimStart(symbols);

            // Create an array of first_word's length
            int[] firstWordLength = new int[n];
            for (int i = 0; i < n; i++) firstWordLength[i] = FirstWordLength(sentencesCopy[i]);

            // Sort this array 
            int[] sortLength = new int[n];
            Array.Copy(firstWordLength, sortLength, n);
            Array.Sort(sortLength);

            Console.WriteLine("Отсортированный массив: ");

            for (int i = 0; i < n; i++) //sortLength array
            {
                for (int j = 0; j < n; j++) // length array
                {
                    if (sortLength[i] == firstWordLength[j])
                    {
                        Console.WriteLine(sentences[j]); //print original sentences in the right order
                        firstWordLength[j] = 0;
                        break;
                    }
                }
            }
        }

        static int FirstWordLength(string sentence)
        {
            string word = Regex.Replace(sentence.Split()[0], @"[^a-zA-Z\ ]+", "");

            return word.Length;
        }
    }
}