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
        public int BoothId => boothId;

        private int capacity;
        public int Capacity
        {
            get => capacity;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.CapacityLessThanOne);
                }
                capacity = value;
            }
        }

        private IRepository<IDelicacy> delicacyMenu;
        public IRepository<IDelicacy> DelicacyMenu => delicacyMenu;

        private IRepository<ICocktail> cocktailMenu;
        public IRepository<ICocktail> CocktailMenu => cocktailMenu;

        private double currentBill;
        public double CurrentBill => currentBill;

        private double turnover;
        public double Turnover => turnover;

        private bool isReserved;
        public bool IsReserved => isReserved;

        public void ChangeStatus()
        {
            isReserved = !isReserved;
        }

        public void Charge()
        {
            turnover += currentBill;
            currentBill = 0;
        }

        public void UpdateCurrentBill(double amount)
        {
            currentBill += amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Booth: {boothId}");
            sb.AppendLine($"Capacity: {capacity}");
            sb.AppendLine($"Turnover: {turnover:F2} lv");
            sb.AppendLine("-Cocktail menu:");
            foreach (var cocktail in cocktailMenu.Models)
            {
                sb.AppendLine($"--{cocktail.ToString()}");
            }
            sb.AppendLine("-Delicacy menu:");
            foreach (var delicacy in delicacyMenu.Models)
            {
                sb.AppendLine($"--{delicacy.ToString()}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}