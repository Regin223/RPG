using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPGCharacters.Exceptions
{
    public class InvalidSlotException : Exception
    {
        public override string Message => "Not vaild slot for this item";
    }
}
