using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class Weapon : Item
    {
        public WeaponType Type { get; set; }
        
        public WeaponAttributes WeaponAttributes { get; set; }

        /// <summary>
        /// Calculates the weapons DPS
        /// </summary>
        /// <returns>double</returns>
        public double GetWeaponDPS()
        {
            return WeaponAttributes.Damage * WeaponAttributes.AttackSpeed;
        }
    }
}
