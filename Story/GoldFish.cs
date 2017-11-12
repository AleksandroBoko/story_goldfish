using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    class GoldFish:Organism
    {
        const int MAX_WISHES = 3;
        private int CountConfirmedWish = 0;

        Random rand;

        public GoldFish()
        {
            rand = new Random();
        }

        public int GetResistCatching()
        {
            return rand.Next(0, 100);
        }

        public bool ConfirmWish(Wish wish)
        {
            bool result = !isLimitWishes();
            if (result)
                CountConfirmedWish++;

            return result;
        }

        public override string GetInfo()
        {
            return "И плавала где-то в море " + Name;
        }

        private bool isLimitWishes()
        {
            return MAX_WISHES <= CountConfirmedWish;
        }
    }
}
