using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacters.Exceptions;

namespace RPGCharacters.Models
{
    public class Ranger : Hero
    {
        public Ranger(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.BasePrimaryAttributes = SetDefaultAttributes();
            this.TotalPrimaryAttributes = SetDefaultAttributes();
            this.CharacterDPS = this.GetCharacterDPS();
            this.SecondarAttributes = new SecondarAttributes
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
        }

        private PrimaryAttributes SetDefaultAttributes()
        {
            return new PrimaryAttributes { Vitality = 8, Strength = 1, Dexterity = 7, Intelligence = 1 };
        }

        public override string Equip(Weapon weapon)
        {
            if (weapon.Type == WeaponType.Bow && CheckRequiredLevel(weapon, this.Level)) 
            {
                string returnString = base.Equip(weapon);
                this.CharacterDPS = this.GetCharacterDPS();
                return returnString;
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        public override string Equip(Armor armor)
        {
            if ((armor.Type == ArmorType.Leather || armor.Type == ArmorType.Mail) && CheckRequiredLevel(armor, this.Level))
            {
                string returnString = base.Equip(armor);
                this.SecondarAttributes = UpdateSecondaryAttributes();
                this.CharacterDPS = this.GetCharacterDPS();
                return returnString;
            }
            else
            {
                throw new InvalidArmorException();
            } 
        }

        public override double GetCharacterDPS()
        {
            double characterDPS;
            if (this.Inventory.ContainsKey(Slot.Weapon))
            {
                Weapon weapon = (Weapon)this.Inventory[Slot.Weapon];
                double additionalDamage = 1 + (double)(this.TotalPrimaryAttributes.Dexterity / 100);
                characterDPS = weapon.GetWeaponDPS() * additionalDamage;
                return characterDPS;
            }
            else
            {
                characterDPS = 1 * (1 + this.TotalPrimaryAttributes.Dexterity / 100);
                return characterDPS;
            }
        }

        public override void LevelUp(int levels)
        {
            if (levels > 0)
            {
                this.Level += levels; // add exeeption for adding invalid level
                this.BasePrimaryAttributes.Vitality += levels * 2;
                this.BasePrimaryAttributes.Strength += levels * 1;
                this.BasePrimaryAttributes.Dexterity += levels * 5;
                this.BasePrimaryAttributes.Intelligence += levels * 1;
                // add for armor aswell 
                this.TotalPrimaryAttributes.Vitality += levels * 2;
                this.TotalPrimaryAttributes.Strength += levels * 1;
                this.TotalPrimaryAttributes.Dexterity += levels * 5;
                this.TotalPrimaryAttributes.Intelligence += levels * 1;

                this.SecondarAttributes = UpdateSecondaryAttributes();
            }
            else
            {
                throw new ArgumentException();
            }
         
        }
        private SecondarAttributes UpdateSecondaryAttributes()
        {
            return new SecondarAttributes
            {
                Health = this.TotalPrimaryAttributes.Vitality * 10,
                ArmorRating = this.TotalPrimaryAttributes.Strength + this.TotalPrimaryAttributes.Dexterity,
                ElementalResistance = this.TotalPrimaryAttributes.Intelligence,
            };
        }
    }
}
