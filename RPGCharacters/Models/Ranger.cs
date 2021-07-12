using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class Ranger : Hero
    {
        public Ranger(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.BasePrimaryAttributes = new PrimaryAttributes { Vitality = 8, Strength = 1, Dexterity = 7, Intelligence = 1 };
            this.SecondarAttributes = new SecondarAttributes
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
        }

        public override void Equip(Weapon weapon)
        {
            if (weapon.Type == WeaponType.Bow)
            {
                if (weapon.Slot == Slot.Weapon)
                {
                    if (this.Inventory.ContainsKey(weapon.Slot))
                    {
                        this.Inventory[weapon.Slot] = weapon;
                    }
                    else
                    {
                        this.Inventory.Add(Slot.Weapon, weapon);
                    }
                }
                else
                {
                    Console.WriteLine($"Throw exeption, can not add weapon to {weapon.Slot}, slot must = Weapon");
                }
            }
            else
            {
                Console.WriteLine("Throw not vaild weapon");
            }
        }

        public override void Equip(Armor armor)
        {
            if (armor.Type == ArmorType.Leather || armor.Type == ArmorType.Mail)
            {
                if (armor.Slot == Slot.Head || armor.Slot == Slot.Body || armor.Slot == Slot.Legs)
                {
                    if (this.Inventory.ContainsKey(armor.Slot))
                    {
                        this.Inventory[armor.Slot] = armor;
                    }
                    else
                    {
                        this.Inventory.Add(armor.Slot, armor);
                    }
                }
                else
                {
                    Console.WriteLine($"Throw exeption, can not add armor to {armor.Slot}, slot must = Head, body or legs");
                }
            }
            else
            {
                Console.WriteLine("Throw not valid armor");
            }
        }

        public override void LevelUp(int levels)
        {
            this.Level += levels; // add exeeption for adding invalid level
            this.BasePrimaryAttributes.Vitality += levels * 2;
            this.BasePrimaryAttributes.Strength += levels * 1;
            this.BasePrimaryAttributes.Dexterity += levels * 5;
            this.BasePrimaryAttributes.Intelligence += levels * 1;
            // add for armor aswell 
            this.SecondarAttributes = new SecondarAttributes
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence
            };
        }
    }
}
