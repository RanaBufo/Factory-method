using Interfaces;
using MewClassLibrary;
using PlusClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagins.Factories
{
    internal class MeowClassFectory : CatFactory
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MeowClassFectory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override IPlugin GetCat()
        {
            MewClass catClass = new MewClass(Name, Description);
            return catClass;
        }
    }
}
