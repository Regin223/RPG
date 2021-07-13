using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class PrimaryAttributes
    {
        public static PrimaryAttributes operator +(PrimaryAttributes lhs, PrimaryAttributes rhs)
        {
            return new PrimaryAttributes
            {
                Strength = lhs.Strength + rhs.Strength,
                Dexterity = lhs.Dexterity + rhs.Dexterity,
                Intelligence = lhs.Intelligence + rhs.Intelligence,
                Vitality = lhs.Vitality + rhs.Vitality
            };
        }
        public double Strength { get; set; }

        public double Dexterity { get; set; }

        public double Intelligence { get; set; }

        public double Vitality { get; set; }
    }
}
