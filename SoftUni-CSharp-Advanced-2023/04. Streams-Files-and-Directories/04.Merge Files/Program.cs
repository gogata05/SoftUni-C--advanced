using System;
using System.IO;

namespace MergeFiles
{
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";
            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            
            using (StreamReader reader1 = new StreamReader(firstInputFilePath))
            using (StreamReader reader2 = new StreamReader(secondInputFilePath))
            using (StreamWriter writer = new StreamWriter(outputFilePath))
            {
                string line1, line2 = null;
                while ((line1 = reader1.ReadLine()) != null || (line2 = reader2.ReadLine()) != null)
                {
                    if (line1 != null)
                    {
                        writer.WriteLine(line1);
                    }

                    if (line2 != null)
                    {
                        writer.WriteLine(line2);
                    }
                }
            }
        }
    }
}