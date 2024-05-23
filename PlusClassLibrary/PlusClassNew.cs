using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;

namespace PlusClassLibrary

{
    public class PlusClassNew : IPlugin
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public PlusClassNew(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Execute(int[] array, int i)
        {
            int maxA = array.Max();
            return maxA + i;
        }
    }
}
