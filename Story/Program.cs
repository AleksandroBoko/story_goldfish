using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Story
{
    class Program
    {
        static Organism oldWoman;
        static Organism oldMan;
        static Organism fish;

        static void Main(string[] args)
        {
            CreatePersons();
            StartDescribing();
            StartWomanWishing();

            Console.ReadKey();
        }

        static void CreatePersons()
        {
            oldWoman = new OldWoman() { Name = "Марья" };
            oldMan = new OldMan() { Name = "Иван" };
            fish = new GoldFish() { Name = "Золотая рыбка" };

            InitOldWoman();
        }

        static void InitOldWoman()
        {
            OldWoman woman = oldWoman as OldWoman;
            if (woman != null)
            {
                woman.AddWish(new Wish() { Name = "iPhone X", IsConfirmed = false });
                woman.AddWish(new Wish() { Name = "Ford Mustang", IsConfirmed = false });
                woman.AddWish(new Wish() { Name = "Country House", IsConfirmed = false });
                woman.AddWish(new Wish() { Name = "To be the president of Microsoft", IsConfirmed = false });
            }
        }

        static void StartDescribing()
        {
            Console.WriteLine(oldMan.GetInfo());
            Console.WriteLine(oldWoman.GetInfo());
            Console.WriteLine(fish.GetInfo());
        }

        static void StartWomanWishing()
        {
            IWishable woman = oldWoman as IWishable;
            if (woman == null)
                return;

            Console.WriteLine($"Слышала {oldWoman.Name}, что есть в синем море {fish.Name}, которая желания исполняет");
            bool wasTry = false;
            while (woman.HasNewWish() && woman.CanWish)
            {
                string str = wasTry ? $"И снова {oldMan.Name} пошел испытывать удачу" :
                                      $"И отправила {oldWoman.Name} своего мужа словить рыбку";
                Console.WriteLine(str);
                StartCatching(woman);
                wasTry = true;
            }

            if (wasTry)
            {
                if (woman.CanWish)
                    Console.WriteLine($"Больше не стала испытывать судьбу {oldWoman.Name}. Поблагодарила рыбку за все добро!");
            }
            else
            {
                Console.WriteLine("Слышать слышала, но с мужем решили не тратить время на поиски рыбки... ");
            }
        }

        static void StartCatching(IWishable woman)
        {
            OldMan man = oldMan as OldMan;
            GoldFish gfish = fish as GoldFish;
            Wish wish = woman.AskAboutWish();
            if (man == null || gfish == null || wish == null)
                return;

            Console.WriteLine($"И забросил невод {man.Name}"); 
            if (man.Catch(gfish))
            {
                Console.WriteLine($"И словил {man.Name} золотую рыбку");
                Console.WriteLine($"Обратился {man.Name} к рыбке с просьбой исполнить желание жены - {wish.Name}");
                if (StartManWishing(wish, gfish))
                {
                    Console.WriteLine($"Порадовал {man.Name} свою жену, исполнил ее желание");
                }
                else
                {
                    Console.WriteLine($"Вот так и остались {man.Name} и {oldWoman.Name} ни с чем...");
                    woman.ResetWishes();
                }
            }
            else
            {
                Console.WriteLine($"И ничего не словил {man.Name}");
            }
        }

        static bool StartManWishing(Wish wish, GoldFish gfish)
        {
            bool result = gfish.ConfirmWish(wish);
            if (result)
            {
                Console.WriteLine($"Согласилась {gfish.Name} исполнить желание в обмен на свою свободу");
                Console.WriteLine("Поблагодарил рыбку человек и отпустил ее в море");
                wish.IsConfirmed = true;
            }
            else
            {
                Console.WriteLine($"Отказалась {gfish.Name} исполнять очередное желание человека, слишком много их было");
                Console.WriteLine("Выскользнула рыбка из рук, упав в море... вслед за ней исчезло все, что было загадано ранее");
            }
            return result;
        }
    }
}
