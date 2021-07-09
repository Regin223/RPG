using RPGCharacters.Models;
using System;

namespace RPGCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            Mage mageObj1 = new Mage("Mage1");
            

            Console.WriteLine(mageObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(mageObj1.SecondarAttributes.ArmorRating);
            mageObj1.LevelUp(2);
            Console.WriteLine("-------------");
            Console.WriteLine(mageObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(mageObj1.SecondarAttributes.ArmorRating);

            Console.WriteLine("-------Rogue------");
            Rogue rougeObj1 = new Rogue("Rogue1");
            Console.WriteLine(rougeObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(rougeObj1.SecondarAttributes.ArmorRating);
            rougeObj1.LevelUp(2);
            Console.WriteLine("-------------");
            Console.WriteLine(rougeObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(rougeObj1.SecondarAttributes.ArmorRating);


        }
    }
}
