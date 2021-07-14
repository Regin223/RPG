using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPGCharacters.Exceptions;

namespace RPGCharacters.Models
{
    public class Mage : Hero
    {
        public Mage(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.BasePrimaryAttributes = new PrimaryAttributes { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
            this.TotalPrimaryAttributes = new PrimaryAttributes { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
            this.CharacterDPS = this.SetCharacterDPS();
            this.SecondarAttributes = new SecondarAttributes 
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
        }

        public override string Equip(Weapon weapon)
        {
            if ((weapon.Type == WeaponType.Staff || weapon.Type == WeaponType.Wand) && CheckRequiredLevel(weapon, this.Level))
            {
                string returnString = base.Equip(weapon);
                this.CharacterDPS = this.SetCharacterDPS();
                return returnString;
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        public override string Equip(Armor armor)
        {
            if (armor.Type == ArmorType.Cloth && CheckRequiredLevel(armor, this.Level))
            {
                string returnString = base.Equip(armor);
                // update seondary
                this.SecondarAttributes = UpdateSecondaryAttributes();
                this.CharacterDPS = this.SetCharacterDPS();
                return returnString;
            }
            else
            {
                throw new InvalidArmorException();
            }
        }

        public override double SetCharacterDPS()
        {
            double characterDPS;
            if (this.Inventory.ContainsKey(Slot.Weapon))
            {
                Weapon weapon = (Weapon)this.Inventory[Slot.Weapon];
                double additionalDamage = 1 + (double)(this.TotalPrimaryAttributes.Intelligence / 100);
                characterDPS = weapon.GetWeaponDPS() * additionalDamage;
                return characterDPS;
            }
            else
            {
                characterDPS = 1 * (1 + this.TotalPrimaryAttributes.Intelligence / 100);
                return characterDPS;
            }
        }

        public override void LevelUp(int levels)
        {
            if(levels > 0)
            {
                this.Level += levels; 
                this.BasePrimaryAttributes.Vitality += levels * 3;
                this.BasePrimaryAttributes.Strength += levels * 1;
                this.BasePrimaryAttributes.Dexterity += levels * 1;
                this.BasePrimaryAttributes.Intelligence += levels * 5;
                // for the armor 
                this.TotalPrimaryAttributes.Vitality += levels * 3;
                this.TotalPrimaryAttributes.Strength += levels * 1;
                this.TotalPrimaryAttributes.Dexterity += levels * 1;
                this.TotalPrimaryAttributes.Intelligence += levels * 5;

                this.SecondarAttributes = UpdateSecondaryAttributes();
            }
            else
            {
                throw new ArgumentException();
            }
           
             
        }
        public SecondarAttributes UpdateSecondaryAttributes()
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
