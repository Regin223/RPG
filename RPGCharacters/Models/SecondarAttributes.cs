using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class SecondarAttributes
    {

        public static SecondarAttributes operator +(SecondarAttributes one, SecondarAttributes two)
        {
            return new SecondarAttributes
            {
                ArmorRating = one.ArmorRating + two.ArmorRating,
                Health = one.Health + two.Health,
                ElementalResistance = one.ElementalResistance + two.ElementalResistance
            };
        }
        public int Health { get; set; }

        public int ArmorRating { get; set; }

        public int ElementalResistance { get; set; }
    }
}
