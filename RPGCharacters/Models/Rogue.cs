using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacters.Exceptions;

namespace RPGCharacters.Models
{
    class Rogue : Hero
    {
        public Rogue(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.BasePrimaryAttributes = new PrimaryAttributes { Vitality = 8, Strength = 2, Dexterity = 6, Intelligence = 1 };
            
            this.SecondarAttributes = new SecondarAttributes
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
        }

        public override void Equip(Weapon weapon)
        {
            if((weapon.Type == WeaponType.Dagger || weapon.Type == WeaponType.Sword) && weapon.RequiredLevel <= this.Level)
            {
                if(weapon.Slot == Slot.Weapon)
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
                    throw new InvalidSlotException();
                }
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        public override void Equip(Armor armor)
        {
            if (armor.Type == ArmorType.Leather || armor.Type == ArmorType.Mail)
            {
                if(armor.Slot == Slot.Head || armor.Slot == Slot.Body || armor.Slot == Slot.Legs)
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
                    throw new InvalidSlotException();
                }
            }
            else
            {
                throw new InvalidArmorException();
            }
        }

        public override void LevelUp(int levels)
        {
            if (levels > 0)
            {
                this.Level += levels; // add exeeption for adding invalid level
                this.BasePrimaryAttributes.Vitality += levels * 3;
                this.BasePrimaryAttributes.Strength += levels * 1;
                this.BasePrimaryAttributes.Dexterity += levels * 4;
                this.BasePrimaryAttributes.Intelligence += levels * 1;
                // add for armor aswell 
                this.SecondarAttributes = new SecondarAttributes
                {
                    Health = this.BasePrimaryAttributes.Vitality * 10,
                    ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                    ElementalResistance = this.BasePrimaryAttributes.Intelligence
                };

            }
            else
            {
                throw new ArgumentException();
            }

        }
    }
}
