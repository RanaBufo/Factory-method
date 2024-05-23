using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Interfaces;

namespace CatsClassLibrary
{
    public class MeowBinClass : IPlugin
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public MeowBinClass(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public int Execute(int[] array, int i)
        {
            int k = 0;
            int minK = 0;
            int maxK = array.Length;
            while (array[k] != i)
            {
                if (maxK % 2 == 0)
                {
                    k = maxK / 2;
                }
                else
                {
                    k = maxK / 2 + 1;
                }
                if (array[k] > i)
                {
                    maxK = k;
                }
                else
                {
                    minK = k;
                }
            }
            return k;
        }
    }
}
