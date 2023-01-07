using PosSystem.Common.Enums;
using PosSystem.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Factories
{
    /// <summary>
    /// Factory to create ICashierService instances
    /// </summary>
    public interface ICashierFactory
    {
        /// <summary>
        /// Creates a new instance of ICashierFactory
        /// </summary>
        /// <param name="countryType">Country configuration to use on cashier creation</param>
        /// <returns>a ICashierService instance</returns>
        ICashierService CreateInstance(CountryType countryType);
    }
}
