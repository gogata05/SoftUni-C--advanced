
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CocktailParty
{
    public class Cocktail
    {
        private readonly List<Ingredient> ingredients;

        public Cocktail(string name, int capacity, int maxAlcoholLevel)
        {
            this.Name = name;
            this.Capacity = capacity;
            this.MaxAlcoholLevel = maxAlcoholLevel;
            this.ingredients = new List<Ingredient>();
        }

        public string Name { get; set; }

        public int Capacity { get; set; }

        public int MaxAlcoholLevel { get; set; }

        public int CurrentAlcoholLevel => this.ingredients.Sum(x => x.Alcohol);

        public void Add(Ingredient ingredient)
        {
            if (!this.ingredients.Any(x => x.Name == ingredient.Name)
                && this.ingredients.Count < this.Capacity
                && this.CurrentAlcoholLevel + ingredient.Alcohol <= this.MaxAlcoholLevel)
            {
                this.ingredients.Add(ingredient);
            }
        }

        public bool Remove(string name)
        {
            Ingredient ingredient = this.ingredients.FirstOrDefault(x => x.Name == name);
            if (ingredient != null)
            {
                this.ingredients.Remove(ingredient);
                return true;
            }

            return false;
        }

        public Ingredient FindIngredient(string name)
        {
            return this.ingredients.FirstOrDefault(x => x.Name == name);
        }

        public Ingredient GetMostAlcoholicIngredient()
        {
            return this.ingredients.OrderByDescending(x => x.Alcohol).FirstOrDefault();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Cocktail: {this.Name} - Current Alcohol Level: {this.CurrentAlcoholLevel}");
            foreach (var ingredient in this.ingredients)
            {
                sb.AppendLine(ingredient.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
