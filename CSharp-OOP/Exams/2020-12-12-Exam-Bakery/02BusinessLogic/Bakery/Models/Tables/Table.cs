using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Bakery.Models.BakedFoods.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Utilities.Messages;
namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            foodOrders = new List<IBakedFood>();
            drinkOrders = new List<IDrink>();
            TableNumber = tableNumber;
            Capacity = capacity;
            PricePerPerson = pricePerPerson;
        }
        private int tableNumber;
        public int TableNumber
        {
            get => tableNumber;
            private set => tableNumber = value;
        }
        private int capacity;
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }
                capacity = value;
            }
        }
        private int numberOfPeople;
        public int NumberOfPeople
        {
            get => numberOfPeople;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }
                numberOfPeople = value;
            }
        }
        private decimal pricePerPerson;
        public decimal PricePerPerson
        {
            get => pricePerPerson;
            private set => pricePerPerson = value;
        }
        private bool isReserved;
        public bool IsReserved
        {
            get => isReserved;
            private set => isReserved = value;
        }
        private List<IBakedFood> foodOrders;
        private List<IDrink> drinkOrders;
        public decimal Price
        => PricePerPerson * NumberOfPeople + foodOrders.Select(x => x.Price).Sum()
                                           + drinkOrders.Select(x => x.Price).Sum();
        public void Reserve(int numberOfPeople)
        {
            IsReserved = true;
            NumberOfPeople = numberOfPeople;
        }
        public void OrderFood(IBakedFood food)
        {
            foodOrders.Add(food);
        }
        public void OrderDrink(IDrink drink)
        {
            drinkOrders.Add(drink);
        }
        public decimal GetBill()
            => Price;
        public void Clear()
        {
            foodOrders.Clear();
            drinkOrders.Clear();
            IsReserved = false;
            numberOfPeople = 0;
        }
        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Table: {TableNumber}");
            sb.AppendLine($"Type: {GetType().Name}");
            sb.AppendLine($"Capacity: {Capacity}");
            sb.AppendLine($"Price per Person: {PricePerPerson}");
            return sb.ToString().TrimEnd();
        }
    }
}