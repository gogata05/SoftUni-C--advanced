using System;
using System.Collections.Generic;
using System.Linq;

namespace PokemonTrainer;

public class Startup
{
    static void Main(string[] args)
    {
        List<Trainer> trainers = new();

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "Tournament")
            {
                break;
            }

            string[] commandArray = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Trainer trainer = trainers.SingleOrDefault(t => t.Name == commandArray[0]);

            if (trainer == null)
            {
                trainer = new(commandArray[0]);
                trainer.Pokemons.Add(new(commandArray[1], commandArray[2], int.Parse(commandArray[3])));
                trainers.Add(trainer);
            }
            else
            {
                trainer.Pokemons.Add(new(commandArray[1], commandArray[2], int.Parse(commandArray[3])));
            }
        }

        while (true)
        {
            string command = Console.ReadLine();

            if (command == "End")
            {
                break;
            }

            foreach (var trainer in trainers)
            {
                trainer.CheckPokemon(command);
            }
        }

        foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
        {
            Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
        }
    }
}