using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class Armor : Item

    {
        public PrimaryAttributes Armourattributes { get; set; }

        public ArmorType Type { get; set; }
        
    }
}
