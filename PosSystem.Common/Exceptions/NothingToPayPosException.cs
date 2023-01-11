using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Exceptions
{
    /// <summary>
    /// Exception class to throw when there is nothing to pay
    /// </summary>
    public class NothingToPayPosException : PosException
    {
        public NothingToPayPosException() : base ("No Payment required amount to pay is zero")
        {

        }
    }
}
