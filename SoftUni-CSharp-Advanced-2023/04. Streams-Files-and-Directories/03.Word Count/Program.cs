
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordCount
{
    public class WordCount
    {
        static void Main()
        {
            string wordPath = @"..\..\..\Files\words.txt";
            string textPath = @"..\..\..\Files\text.txt";
            string outputPath = @"..\..\..\Files\output.txt";

            CalculateWordCounts(wordPath, textPath, outputPath);
        }

        public static void CalculateWordCounts(string wordsFilePath, string textFilePath, string outputFilePath)
        {
            
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            // Read words from words.txt and initialize word counts
            using (StreamReader reader = new StreamReader(wordsFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = line.Split(' ');

                    foreach (string word in words)
                    {
                        string lowerWord = word.ToLower();
                        if (!wordCounts.ContainsKey(lowerWord))
                        {
                            wordCounts[lowerWord] = 0;
                        }
                    }
                }
            }

          
            using (StreamReader reader = new StreamReader(textFilePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] words = Regex.Split(line, @"\W+");
                    foreach (string word in words)
                    {
                        string lowerWord = word.ToLower();
                        if (wordCounts.ContainsKey(lowerWord))
                        {
                            wordCounts[lowerWord]++;
                        }
                    }
                }
            }

            var sortedWordCounts = wordCounts.OrderByDescending(x => x.Value).ToList();

            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                foreach (var wordCount in sortedWordCounts)
                {
                    writer.WriteLine($"{wordCount.Key} - {wordCount.Value}");
                }
            }
        }
    }
}
