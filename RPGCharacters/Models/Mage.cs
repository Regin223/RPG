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
            this.CharacterDPS = 1;
            this.BasePrimaryAttributes = new PrimaryAttributes { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
            this.TotalPrimaryAttributes = new PrimaryAttributes { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
            this.SecondarAttributes = new SecondarAttributes 
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
        }

        public override void Equip(Weapon weapon)
        {
            if ((weapon.Type == WeaponType.Staff || weapon.Type == WeaponType.Wand) && CheckRequiredLevel(weapon, this.Level))
            {
                base.Equip(weapon);
            }
            else
            {
                throw new InvalidWeaponException();
            }
        }

        public override void Equip(Armor armor)
        {
            if (armor.Type == ArmorType.Cloth && CheckRequiredLevel(armor, this.Level))
            {
                base.Equip(armor);
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
                return 1;
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

                this.SecondarAttributes = new SecondarAttributes
                {
                    Health = this.BasePrimaryAttributes.Vitality * 10,
                    ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                    ElementalResistance = this.BasePrimaryAttributes.Intelligence,
                };
            }
            else
            {
                throw new ArgumentException();
            }
           
             
        }
    
        

    }
}
