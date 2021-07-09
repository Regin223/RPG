using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public override void LevelUp(int levels)
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
    }
}
