using System;
using System.Collections.Generic;
using System.Text;

namespace TestRenovators
{
    public class Catalog
    {

        //fields
        private List<Renovator> renovators;
        //ctor
        public Catalog(List<Renovator> renovators)
        {
            this.renovators = renovators;
        }

      
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int neededRenovators;
        public int NeededRenovators
        {
            get { return neededRenovators; }
            set { neededRenovators = value; }
        }

        private string project;
        public string Project
        {
            get { return project; }
            set { project = value; }
        }

        //prop
        public int Count
        {
            get { return renovators.Count; }
        }

        //methods
        public string AddRenovator(Renovator renovator)
        {
            renovators.Add(renovator);
        }







    }
}
