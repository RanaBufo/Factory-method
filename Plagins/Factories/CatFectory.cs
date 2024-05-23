using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Plagins;
using Interfaces;

namespace Plagins.Factories 
{
    public abstract class CatFactory 
    {
        public abstract IPlugin GetCat(); 
    }
}
