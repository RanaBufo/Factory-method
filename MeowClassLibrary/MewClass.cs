using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Interfaces;

namespace MewClassLibrary
{
    public class MewClass : IPlugin
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public MewClass(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public int Execute(int[] array, int i)
        {
            return array.Length;
        }
    }
}
