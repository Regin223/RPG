using RPGCharacters.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public abstract class Hero
    {
        public string Name { get; set; }

        public int Level { get; set; }
        
        public double CharacterDPS { get; set; }

        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }

        public SecondarAttributes SecondarAttributes { get; set; }

        public Dictionary<Slot, Item> Inventory { get; set; } = new Dictionary<Slot, Item>();

        //Methods

        public bool CheckRequiredLevel(Item item, int level)
        {
            return level >= item.RequiredLevel;
        }

        public override string ToString()
        {
            return $"Name: {this.Name}, Level: {this.Level}, Strength: {this.TotalPrimaryAttributes.Strength}, Dexterity: {this.TotalPrimaryAttributes.Dexterity}, " +
                $"Intelligence: {this.TotalPrimaryAttributes.Intelligence}, Health: {this.TotalPrimaryAttributes.Vitality * 10}, Armor Rating: {this.TotalPrimaryAttributes.Strength + this.TotalPrimaryAttributes.Dexterity}, " +
                $"Elemental Resistance: {this.TotalPrimaryAttributes.Intelligence}, DPS: {this.CharacterDPS}";
        }

        public abstract void LevelUp(int levels);

        public virtual void Equip(Weapon weapon) 
        {
            if (weapon.Slot == Slot.Weapon)
            {
                if (this.Inventory.ContainsKey(weapon.Slot))
                {
                    this.Inventory[weapon.Slot] = weapon;
                    this.SetCharacterDPS();
                }
                else
                {
                    this.Inventory.Add(Slot.Weapon, weapon);
                    this.SetCharacterDPS();
                }
            }
            else
            {
                throw new InvalidSlotException();
            }
        }

        public virtual void Equip(Armor armor)
        {
            if (armor.Slot == Slot.Head || armor.Slot == Slot.Body || armor.Slot == Slot.Legs)
            {
                if (this.Inventory.ContainsKey(armor.Slot))
                {
                    this.Inventory[armor.Slot] = armor;
                    this.TotalPrimaryAttributes += armor.Armourattributes;
                    //update secondary attributes
                }
                else
                {
                    this.Inventory.Add(armor.Slot, armor);
                    this.TotalPrimaryAttributes += armor.Armourattributes;
                }

            }
            else
            {
                throw new InvalidSlotException();
            }
        }

        public abstract double SetCharacterDPS();



    }
}
