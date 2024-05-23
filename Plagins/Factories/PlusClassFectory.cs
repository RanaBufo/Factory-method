using CatsClassLibrary;
using Interfaces;
using PlusClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagins.Factories
{
    internal class PlusClassFectory : CatFactory
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public PlusClassFectory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override IPlugin GetCat()
        {
            PlusClassNew catClass = new PlusClassNew(Name, Description); 
            return catClass;
        }
    }
}
