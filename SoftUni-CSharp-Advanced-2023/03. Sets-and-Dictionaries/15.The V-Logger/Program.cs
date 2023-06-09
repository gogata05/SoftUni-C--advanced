using System;
using System.Collections.Generic;
using System.Linq;

Dictionary<string, Dictionary<string, HashSet<string>>> dictVloggers = new();
//DVloggerName//followers//followings
string command = Console.ReadLine();
while (command != "Statistics")
{
    string[] inputArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    string act = inputArray[1];
    if (act == "joined")
    {
        string vloggerName = inputArray[0];
        if (!dictVloggers.ContainsKey(vloggerName))
        {
            dictVloggers.Add(vloggerName, new());
            dictVloggers[vloggerName].Add("followers", new());
            dictVloggers[vloggerName].Add("following", new());
        }
    }
    else if (act == "followed")
    {
        string vlogger = inputArray[0];
        string vloggerToFollow = inputArray[2];

        if (dictVloggers.ContainsKey(vlogger) &&
            dictVloggers.ContainsKey(vloggerToFollow) &&
            vlogger != vloggerToFollow)
        {
            dictVloggers[vlogger]["following"].Add(vloggerToFollow);
            dictVloggers[vloggerToFollow]["followers"].Add(vlogger);
        }
    }
    command = Console.ReadLine();
}
int count = 1;
Console.WriteLine($"The V-Logger has a total of {dictVloggers.Count} vloggers in its logs.");
Dictionary<string, Dictionary<string, HashSet<string>>> orderedVloggers = dictVloggers.OrderByDescending(v => v.Value["followers"].Count).ThenBy(v => v.Value["following"].Count).ToDictionary(v => v.Key, v => v.Value);
foreach (var vlogger in orderedVloggers)
{
    Console.WriteLine($"{count}. {vlogger.Key} : {vlogger.Value["followers"].Count} followers, {vlogger.Value["following"].Count} following");
    if (count == 1)
    {
        //Try SortedSet for vloggers 
        List<string> orderedFollowers = vlogger.Value["followers"].OrderBy(f => f).ToList();
        foreach (var follower in orderedFollowers)
        {
            Console.WriteLine($"*  {follower}");
        }
    }
    count++;
}