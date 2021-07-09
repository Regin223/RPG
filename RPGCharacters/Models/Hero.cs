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



        //Methods

        public abstract void LevelUp(int levels);

    }
}
