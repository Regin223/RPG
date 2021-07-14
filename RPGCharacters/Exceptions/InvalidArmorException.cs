using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Exceptions
{
    public class InvalidArmorException : Exception
    {
        public override string Message => "Not valid armor for this hero";
    }
}
