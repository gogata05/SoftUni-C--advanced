using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zoo
{

    public class Zoo
    {
        public string Name { get; private set; }
        public int Capacity { get; private set; }
        public List<Animal> Animals { get; private set; }

        public Zoo(string name, int capacity)
        {
            Name = name;
            Capacity = capacity;
            Animals = new List<Animal>();
        }

        public string AddAnimal(Animal animal)
        {
            if (string.IsNullOrWhiteSpace(animal.Species))
            {
                return "Invalid animal species.";
            }
            if (animal.Diet != "herbivore" && animal.Diet != "carnivore")
            {
                return "Invalid animal diet.";
            }
            if (Animals.Count >= Capacity)
            {
                return "The zoo is full.";
            }

            Animals.Add(animal);
            return $"Successfully added {animal.Species} to the zoo.";
        }

        public int RemoveAnimals(string species)
        {
            var count = Animals.RemoveAll(a => a.Species == species);
            return count;
        }

        public List<Animal> GetAnimalsByDiet(string diet)
        {
            return Animals.Where(a => a.Diet == diet).ToList();
        }

        public Animal GetAnimalByWeight(double weight)
        {
            return Animals.FirstOrDefault(a => a.Weight == weight);
        }

        public string GetAnimalCountByLength(double minimumLength, double maximumLength)
        {
            var count = Animals.Count(a => a.Length >= minimumLength && a.Length <= maximumLength);
            return $"There are {count} animals with a length between {minimumLength} and {maximumLength} meters.";
        }
    }
}
