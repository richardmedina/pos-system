using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Exceptions
{
    /// <summary>
    /// Exception to throw when country configuration does not exists
    /// </summary>
    public class CountryNotFoundPosException : Exception
    {
        public CountryNotFoundPosException(string message) : base(message)
        {
        }
    }
}
