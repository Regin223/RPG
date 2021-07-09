using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class Mage : Hero
    {
        public Mage(string name)
        {
            this.Name = name;
            this.Level = 1;
            this.BasePrimaryAttributes = new PrimaryAttributes { Vitality = 5, Strength = 1, Dexterity = 1, Intelligence = 8 };
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
            this.BasePrimaryAttributes.Dexterity += levels * 1;
            this.BasePrimaryAttributes.Intelligence += levels * 5;
            // add for armor aswell 
            this.SecondarAttributes = new SecondarAttributes
            {
                Health = this.BasePrimaryAttributes.Vitality * 10,
                ArmorRating = this.BasePrimaryAttributes.Strength + this.BasePrimaryAttributes.Dexterity,
                ElementalResistance = this.BasePrimaryAttributes.Intelligence,
            };
             
        }
    
        

    }
}
