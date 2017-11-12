using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    abstract class Organism
    {
        public string Name { get; set; }

        public abstract string GetInfo();
    }
}
