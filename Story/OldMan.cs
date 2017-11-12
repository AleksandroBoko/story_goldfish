using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    class OldMan : Organism, ICatchable
    {
        Random rand;
        
        public OldMan()
        {
            rand = new Random();
        }

        public override string GetInfo()
        {
            return $"Жил был " + Name;
        }

        public bool Catch(GoldFish fish)
        {
            return GetLuckyPerCent() > fish.GetResistCatching();  
        }

        private int GetLuckyPerCent()
        {
            return rand.Next(80, 100);
        }
         
    }
}
