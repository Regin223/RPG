using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    public class SecondarAttributes
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
        public double Health { get; set; }

        public double ArmorRating { get; set; }

        public double ElementalResistance { get; set; }
    }
}
