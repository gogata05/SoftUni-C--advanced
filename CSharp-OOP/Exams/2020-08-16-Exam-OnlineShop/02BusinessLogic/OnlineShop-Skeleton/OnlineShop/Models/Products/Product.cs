﻿using System;
using System.Collections.Generic;
using System.Text;
using OnlineShop.Common.Constants;

namespace OnlineShop.Models.Products
{
    public abstract class Product : IProduct
    {
        public Product(int id, string manufacturer, string model, decimal price, double overallPerformance)
        {
            Id = id;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            OverallPerformance = overallPerformance;
        }

        private int id;
        public int Id
        {
            get => id;
            private set
            {
                if (value<=0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidProductId);
                }
                id = value;
            }
        }

        private string manufacturer;
        public string Manufacturer
        {
            get=>manufacturer;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidManufacturer);
                }
                manufacturer = value;
            }
        }

        private string model;
        public string Model
        {
            get => model;
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidModel);
                }
                model = value;
            }
        }

        private decimal price;
        public virtual decimal Price
        {
            get => price;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidPrice);
                }
                price = value;
            }
        }

        private double overallPerformance;
        public virtual double OverallPerformance
        {
            get=> overallPerformance;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidOverallPerformance);
                }
                overallPerformance = value;
            }
        }

        public override string ToString()
        => string.Format(SuccessMessages.ProductToString,
            $"{OverallPerformance:f2}", $"{Price:f2}", GetType().Name, Manufacturer, Model, Id);
    }
}
