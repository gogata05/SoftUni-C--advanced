using ChristmasPastryShop.Models.Booths.Contracts;
using ChristmasPastryShop.Models.Cocktails.Contracts;
using ChristmasPastryShop.Models.Delicacies.Contracts;
using ChristmasPastryShop.Repositories.Contracts;
using ChristmasPastryShop.Repositories.Models;
using ChristmasPastryShop.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChristmasPastryShop.Models.Booths.Models
{
    public class Booth : IBooth
    {
        public Booth(int boothId, int capacity)
        {
            this.boothId = boothId;
            this.Capacity = capacity;
            this.delicacyMenu = new DelicacyRepository();
            this.cocktailMenu = new CocktailRepository();
            this.currentBill = 0;
            this.turnover = 0;
            this.isReserved = false;
        }

        private int boothId;
        public int BoothId { get => boothId; }

        private int capacity;
        public int Capacity 
        { 
            get => capacity; 
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.CapacityLessThanOne));
                }
                this.capacity = value;
            } 
        }

        private readonly IRepository<IDelicacy> delicacyMenu;
        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        private readonly IRepository<ICocktail> cocktailMenu;
        public IRepository<ICocktail> CocktailMenu => cocktailMenu;


        private double currentBill;
        public double CurrentBill => this.currentBill;

        private double turnover;
        public double Turnover => this.turnover;

        private bool isReserved;
        public bool IsReserved => this.isReserved;

        public void UpdateCurrentBill(double amount)
        {
            this.currentBill += amount;
        }

        public void ChangeStatus()
        {
            if (isReserved)
            {
                isReserved = false;
                return;
            }
            isReserved = true;
        }

        public void Charge()
        {
            this.turnover += currentBill;
            this.currentBill = 0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:f2} lv");
            sb.AppendLine($"-Cocktail menu:");
            foreach (var cocktail in CocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail}");
            }
            sb.AppendLine($"-Delicacy menu:");
            foreach (var delicacy in DelicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy}");
            }
            return sb.ToString().TrimEnd();
        }
        
    }
}
