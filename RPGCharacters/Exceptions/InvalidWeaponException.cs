using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Exceptions
{
    public class InvalidWeaponException : Exception
    {
        public override string Message => "Not a valid weapon for this hero";
    }
}
