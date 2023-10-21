using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;
namespace ChristmasPastryShop.Models.Cocktails.Models
{
    public abstract class Cocktail : ICocktail
    {
        protected Cocktail(string name, string size, double price)
        {
            Name = name;
            Size = size;
            Price = price;
        }

        private string name;
        public string Name
        {
            get => name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.NameNullOrWhitespace));
                }
                name = value;
            }
        }

        private string size;
        public string Size
        {
            get => size;
            private set => size = value;
        }

        private double price;
        public double Price
        {
            get => price;
            private set
            {
                if (Size == "Small")
                {
                    value /= 3;
                }
                else if (Size == "Middle")
                {
                    value = (value / 3) * 2;
                }

                price = value;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
