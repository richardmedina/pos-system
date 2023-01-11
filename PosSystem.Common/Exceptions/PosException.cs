using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Exceptions
{
    /// <summary>
    /// Base Pos System excaption
    /// </summary>
    public class PosException : Exception
    {
        public PosException()
        {
        }

        public PosException(string message) : base(message)
        {
        }

        public PosException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
