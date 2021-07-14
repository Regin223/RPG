using RPGCharacters.Models;
using System;
using System.Collections.Generic;
using RPGCharacters.Exceptions;

namespace RPGCharacters
{
    class Program
    {
        static void Main(string[] args)
        {
            // Added som code to get use of the to´String method that shows the heros stats. 

            Warrior warrior = new Warrior("Warrior");
            warrior.LevelUp(2);
            Weapon testAxe = new Weapon()
            {
                Name = "Common axe",
                RequiredLevel = 1,
                Slot = Slot.Weapon,
                Type = WeaponType.Axe,
                WeaponAttributes = new WeaponAttributes() { Damage = 7, AttackSpeed = 1.1 }
            };
            warrior.Equip(testAxe);
            Console.WriteLine(warrior.ToString());

        }
        }
}
