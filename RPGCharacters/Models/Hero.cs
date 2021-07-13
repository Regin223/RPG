using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    abstract class Hero
    {
        public string Name { get; set; }

        public int Level { get; set; }
        
        public double CharacterDPS { get; set; }

        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }

        public SecondarAttributes SecondarAttributes { get; set; }

        public Dictionary<Slot, Item> Inventory { get; set; } = new Dictionary<Slot, Item>();

        public bool CheckRequiredLevel(Item item, int level)
        {
            return level >= item.RequiredLevel;
        }



        //Methods

        public override string ToString()
        {
            return $"Name: {this.Name}, Level: {this.Level}, Strength: {this.TotalPrimaryAttributes.Strength}, Dexterity: {this.TotalPrimaryAttributes.Dexterity}, " +
                $"Intelligence: {this.TotalPrimaryAttributes.Intelligence}, Health: {this.SecondarAttributes.Health}, Armor Rating: {this.SecondarAttributes.ArmorRating}, " +
                $"Elemental Resistance: {this.SecondarAttributes.ElementalResistance}, DPS: {this.CharacterDPS}";
        }

        public abstract void LevelUp(int levels);

        public abstract void Equip(Weapon weapon);

        public abstract void Equip(Armor armor);

        public abstract double SetCharacterDPS();



    }
}
