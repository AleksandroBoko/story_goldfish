using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    interface IWishable
    {
        Wish AskAboutWish();
        void ResetWishes();
        bool HasNewWish();
        void AddWish(Wish wish);
        bool CanWish { get; }
    }
}
