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
            private set
            {
                size = value;
                UpdatePrice();
            }
        }

        private double price;
        public double Price
        {
            get => price;
            private set
            {
                price = value;
            }
        }

        // Helper method to update the price based on the size
        private void UpdatePrice()
        {
            switch (Size)
            {
                case "Small":
                    Price = 1.0 / 3.0 * Price;
                    break;
                case "Middle":
                    Price = 2.0 / 3.0 * Price;
                    break;
                case "Large":
                    // Price remains unchanged
                    break;
            }
        }

        public override string ToString()
        {
            return $"{Name} ({Size}) - {Price:f2} lv";
        }
    }
}
