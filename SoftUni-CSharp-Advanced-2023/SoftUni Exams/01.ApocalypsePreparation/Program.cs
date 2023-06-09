using System;
using System.Collections.Generic;
using System.Linq;

namespace Test01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> queueNumTextile = new Queue<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//20 10 40 70 20 
            Stack<int> stackNumMedicaments = new Stack<int>(Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse));//50 10 30 20 80 

            Dictionary<int, string> dictionaryList = new Dictionary<int, string>()
            {
                {30,"Patch"},
                {40,"Bandage"},
                {100,"MedKit"}
            };
            Dictionary<string, int> dictionaryToPrint = new Dictionary<string, int>() { };//empty
            while (stackNumMedicaments.Count != 0 && queueNumTextile.Count != 0)
            {
                int sum = queueNumTextile.Peek() + stackNumMedicaments.Peek();//100=20+80
                if (dictionaryList.ContainsKey(sum))//if we 
                {
                    queueNumTextile.Dequeue();
                    stackNumMedicaments.Pop();
                    if (!dictionaryToPrint.ContainsKey(dictionaryList[sum]))//?
                    {
                        dictionaryToPrint.Add(dictionaryList[sum], 0);//? medKid
                    }
                    dictionaryToPrint[dictionaryList[sum]]++;//?
                }
                else if (sum > 100)
                {
                    if (!dictionaryToPrint.ContainsKey("MedKit"))
                    {
                        dictionaryToPrint.Add(dictionaryList[sum], 0);//?
                    }
                    dictionaryToPrint["MedKit"]++;//?
                    sum -= 100;//10
                    queueNumTextile.Dequeue();
                    stackNumMedicaments.Pop();
                    int remove = stackNumMedicaments.Pop();//10
                    stackNumMedicaments.Push(sum + remove);
                }
                else
                {
                    queueNumTextile.Dequeue();
                    int value = stackNumMedicaments.Peek();
                    value += 10;
                    stackNumMedicaments.Pop();
                    stackNumMedicaments.Push(value);

                }
            }

            if (queueNumTextile.Count == 0 && stackNumMedicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }
            else if (queueNumTextile.Count == 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (stackNumMedicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }

            foreach (var item in dictionaryToPrint.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }


            if (stackNumMedicaments.Count != 0)
            {
                Console.WriteLine($"Medicaments left: {stackNumMedicaments.Pop()}");
            }
            if (queueNumTextile.Count != 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", queueNumTextile)}");
            }



        }
    }
}
