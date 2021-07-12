using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class Weapon : Item
    {
        public WeaponType Type { get; set; }
        
        public WeaponAttributes WeaponAttributes { get; set; }

    }
}
