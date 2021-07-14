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

        /// <summary>
        /// Check if level is higher or equal to itemrequired level for an item.
        /// returns true if level is higher or equal than item.requried level.
        /// returns false if level is lower than item.requriedLevel.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="level"></param>
        /// <returns>bool</returns>
        public bool CheckRequiredLevel(Item item, int level)
        {
            return level >= item.RequiredLevel;
        }

        /// <summary>
        /// Displays the characters stats.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            return $"Name: {this.Name}, Level: {this.Level}, Strength: {this.TotalPrimaryAttributes.Strength}, Dexterity: {this.TotalPrimaryAttributes.Dexterity}, " +
                $"Intelligence: {this.TotalPrimaryAttributes.Intelligence}, Health: {this.TotalPrimaryAttributes.Vitality * 10}, Armor Rating: {this.TotalPrimaryAttributes.Strength + this.TotalPrimaryAttributes.Dexterity}, " +
                $"Elemental Resistance: {this.TotalPrimaryAttributes.Intelligence}, DPS: {this.CharacterDPS}";
        }

        /// <summary>
        /// Levels up the hero.
        /// The levels param decides how many levels the hero is leveling up.
        /// </summary>
        /// <param name="levels"></param>
        /// <exception cref="ArgumentException">Throws if input value is lower than 1</exception>
        public abstract void LevelUp(int levels);
        
        /// <summary>
        /// Equips a weapon and updates affected attributes.
        /// Return message if equip was succesfull.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>string</returns>
        /// <exception cref=InvalidSlotException">Throws if slot for the weapon is invalid</exception>
        /// <exception cref="InvalidWeaponException">Throws if weapon type is not valid for the hero or if 
        /// required level for weapon is to high</exception>
        public virtual string Equip(Weapon weapon) 
        {
            if (weapon.Slot == Slot.Weapon)
            {
                if (this.Inventory.ContainsKey(weapon.Slot))
                {
                    this.Inventory[weapon.Slot] = weapon;
                    this.CharacterDPS = this.GetCharacterDPS();
                    return "New weapon equipped!";
                }
                else
                {
                    this.Inventory.Add(Slot.Weapon, weapon);
                    this.CharacterDPS = this.GetCharacterDPS();
                    return "New weapon equipped!";
                }
            }
            else
            {
                throw new InvalidSlotException();
            }
        }

        /// <summary>
        /// Equips a weapon and updates affected attributes.
        /// Return message if equip was succesfull.
        /// </summary>
        /// <param name="weapon"></param>
        /// <returns>string</returns>
        /// <exception cref=InvalidSlotException">Throws if slot for the weapon is invalid</exception>
        /// <exception cref="InvalidArmorException">Throws if armor type is not valid for the hero or if 
        /// required level for the armor is to high</exception>
        public virtual string Equip(Armor armor)
        {
            if (armor.Slot == Slot.Head || armor.Slot == Slot.Body || armor.Slot == Slot.Legs)
            {
                if (this.Inventory.ContainsKey(armor.Slot))
                {
                    this.Inventory[armor.Slot] = armor;
                    this.TotalPrimaryAttributes += armor.Armourattributes;
                    
                    return "New armour equipped!";
                }
                else
                {
                    this.Inventory.Add(armor.Slot, armor);
                    this.TotalPrimaryAttributes += armor.Armourattributes;

                    return "New armour equipped!";
                }

            }
            else
            {
                throw new InvalidSlotException();
            }
        }
        /// <summary>
        /// The method calculates and returns the characters DPS. 
        /// </summary>
        /// <returns>double</returns>
        public abstract double GetCharacterDPS();



    }
}
