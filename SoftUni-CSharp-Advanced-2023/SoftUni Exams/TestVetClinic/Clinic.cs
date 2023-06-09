using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VetClinic;

namespace TestVetClinic
{
    internal class Clinic
    {
        //fields
        private List<Pet> data;

        //ctor
        public Clinic(int capacity)
        {
            Capacity = capacity;
            data = new List<Pet>();
        }
       

        //prop
        public int Capacity { get;  set; }

        public int Count { get { return data.Count; } }//getter count

        //methods
        public void Add(Pet pet)
        {
            if (data.Count < Capacity)
            {
                data.Add(pet);
            }
        }

        private int name; //name

        public int Name //Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool Remove(string name)
        {
            Pet pet = data.FirstOrDefault(p => p.Name == name);
            if (pet==null)
            {
                return false;
            }

            data.Remove(pet);
            return true;
        }

        public Pet GetPet(string name,string owner)
        {
            Pet pet = data.FirstOrDefault
                (p => p.Name == name && 
                      p.Owner== owner);
            return pet;
        }

        public Pet GetOldestPet()
        {
            return data.OrderByDescending(p => p.Age).FirstOrDefault();
        }

        public string GetStatistics()
        {
            Console.WriteLine("The clinic has the following patients:");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("The clinic has the following patients:");

            foreach (var item in data)
            {
                sb.AppendLine($"Pet {item.Name} with owner: {item.Owner}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
