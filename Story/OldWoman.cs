using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    class OldWoman:Organism, IWishable
    {
        public List<Wish> Wishes { private set; get; }
        public bool CanWish { private set; get; }

        Random rand;

        public OldWoman()
        {
            Wishes = new List<Wish>();
            rand = new Random();
            CanWish = true;
        }

        public override string GetInfo()
        {
            return "Жила была " + Name;
        }

        public Wish AskAboutWish()
        {
            Wish result = null;
            foreach(var wish in Wishes)
            {
                if(!wish.IsConfirmed)
                {
                    result = wish;
                    break;
                }
            }
            return result;
        }

        public void AddWish(Wish wish)
        {
            if(Wishes != null)
            {
                Wishes.Add(wish);
            }
        }

        public bool HasNewWish()
        {
            return rand.Next(0, 100) > 10;
        }

        public void ResetWishes()
        {
            foreach(Wish wish in Wishes)
            {
                wish.IsConfirmed = false;
            }

            CanWish = false;
        }

    }
}
