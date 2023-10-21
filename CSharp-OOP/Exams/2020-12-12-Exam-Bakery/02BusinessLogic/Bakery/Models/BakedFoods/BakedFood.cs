﻿using System;
using System.Collections.Generic;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Utilities.Messages;
namespace Bakery.Models.BakedFoods
{
    public abstract class BakedFood : IBakedFood
    {
        public BakedFood(string name, int portion, decimal price)
        {
            Name = name;
            Portion = portion;
            Price = price;
        }
        private string name;
        public string Name
        {
            get=> name;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidName);
                }
                name = value;
            }
        }
        private int portion;
        public int Portion
        {
            get=> portion;
            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.InvalidPortion);
                portion = value;
            }
            
        }
        private decimal price;
        public decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0) throw new ArgumentException(ExceptionMessages.InvalidPrice);
                price = value;
            }
        }
        public override string ToString()
        => $"{Name}: {Portion}g - {Price:f2}";
    }
}
