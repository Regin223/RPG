using RPGCharacters.Models;
using System;
using System.Collections.Generic;

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
            Weapon w3 = new Weapon
            {
                Name = "Wannding wand",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Wand,
                WeaponAttributes = new WeaponAttributes { Damage = 1, AttackSpeed = 0.2 }
            };
            mageObj1.Equip(w3);
            var foo3 = (Weapon)mageObj1.Inventory[Slot.Weapon];
            Console.WriteLine(foo3.Type);
            
            
            Console.WriteLine("-------Rogue------");
            Rogue rougeObj1 = new Rogue("Rogue1");
            Console.WriteLine(rougeObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(rougeObj1.SecondarAttributes.ArmorRating);
            rougeObj1.LevelUp(2);
            Console.WriteLine("-------------");
            Console.WriteLine(rougeObj1.BasePrimaryAttributes.Vitality);
            Console.WriteLine(rougeObj1.SecondarAttributes.ArmorRating);

            Armor armor1 = new Armor
            {
                Name = "Big plate",
                RequiredLevel = 1,
                Slot = Slot.Body,
                Type = ArmorType.Leather,
                Armourattributes = new PrimaryAttributes { Dexterity = 2, Intelligence= 1}
            };
            Console.WriteLine($"armor: {armor1.Slot}");
            Armor armor2 = new Armor
            {
                Name = "Mail body",
                RequiredLevel = 1,
                Slot = Slot.Body,
                Type = ArmorType.Mail,
                Armourattributes = new PrimaryAttributes { Dexterity = 4, Intelligence = 2 }
            };
            Console.WriteLine($"armor1: {armor1.Name}");
            rougeObj1.Equip(armor1);
            Console.WriteLine(rougeObj1.Inventory[Slot.Body].Name);
            rougeObj1.Equip(armor2);
            Console.WriteLine($"armor2: {rougeObj1.Inventory[Slot.Body].Name}");

            Weapon w1 = new Weapon
            {
                Name = "Big axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Sword,
                WeaponAttributes = new WeaponAttributes { Damage = 3, AttackSpeed = 0.7 }
            };
            Console.WriteLine($"WeaponType: {w1.Type},Name: {w1.Name}, Damage: {w1.WeaponAttributes.Damage}");

            rougeObj1.Equip(w1);
            var foo2 = (Weapon)rougeObj1.Inventory[Slot.Weapon];
            Console.WriteLine($"foo2: {foo2.Type}");

            //rougeObj1.Inventory = new Dictionary<Slot, Item>();
            //rougeObj1.Inventory.Add(Slot.Weapon, w1);

            //var foo = (Weapon)rougeObj1.Inventory[Slot.Weapon];

            Console.WriteLine("------------Warrior-----------");
            Warrior warriorObj1 = new Warrior("warre");
            Console.WriteLine(warriorObj1.BasePrimaryAttributes.Dexterity);

            Weapon w2 = new Weapon
            {
                Name = "Big axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Hammer,
                WeaponAttributes = new WeaponAttributes { Damage = 5, AttackSpeed = 1.7 }
            };
            warriorObj1.Equip(w2);
            var foo4 = (Weapon)warriorObj1.Inventory[Slot.Weapon];
            Console.WriteLine(foo4.WeaponAttributes.AttackSpeed);
            



        }
    }
}
