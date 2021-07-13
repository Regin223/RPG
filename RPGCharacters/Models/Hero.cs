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

        public PrimaryAttributes BasePrimaryAttributes { get; set; }
        
        public PrimaryAttributes TotalPrimaryAttributes { get; set; }

        public SecondarAttributes SecondarAttributes { get; set; }

        public Dictionary<Slot, Item> Inventory { get; set; } = new Dictionary<Slot, Item>();

        public bool CheckRequiredLevel(Item item, int level)
        {
            return level >= item.RequiredLevel;
        }



        //Methods

        public abstract void LevelUp(int levels);

        public abstract void Equip(Weapon weapon);

        public abstract void Equip(Armor armor);

        public abstract double GetCharacterDPS();



    }
}
