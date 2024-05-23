using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plagins.Factories;
using Plagins;
using Interfaces;
using CatsClassLibrary;


namespace Plugins.Factories
{
    internal class CatCatFactory : CatFactory // Исправление опечатки в названии класса
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public CatCatFactory(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override IPlugin GetCat() // Исправление опечатки в методе
        {
            MeowBinClass catClass = new MeowBinClass(Name, Description); // Исправление создания экземпляра класса
            return catClass;            
        }
    }
}
