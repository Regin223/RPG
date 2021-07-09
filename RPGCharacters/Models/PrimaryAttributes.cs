using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Models
{
    class PrimaryAttributes
    {
        public static PrimaryAttributes operator +(PrimaryAttributes one, PrimaryAttributes two)
        {
            return new PrimaryAttributes
            {
                Strength = one.Strength + two.Strength,
                Dexterity = one.Dexterity + two.Dexterity,
                Intelligence = one.Intelligence + two.Intelligence,
                Vitality = one.Vitality + two.Vitality
            };
        }
        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Intelligence { get; set; }

        public int Vitality { get; set; }
    }
}
