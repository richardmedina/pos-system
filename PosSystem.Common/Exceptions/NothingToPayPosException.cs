using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Exceptions
{
    public class NothingToPayPosException : PosException
    {
        public NothingToPayPosException() : base ("No Payment required amount to pay is zero")
        {

        }
    }
}
