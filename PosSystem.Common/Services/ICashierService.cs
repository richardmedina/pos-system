using PosSystem.Common.Dto.Cashier;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Services
{
    public interface ICashierService
    {
        /// <summary>
        /// Purchase Process to calculate optimized bamount of bills and coins as the change
        /// of the change to return
        /// </summary>
        /// <param name="prices">Array of prices, each one is an article's price</param>
        /// <param name="moneyElements">List of bills and coins that the client is paying to</param>
        /// <returns>List of bills and coins which represent the change</returns>
        public IEnumerable<MoneyElement> Purchase(IEnumerable<double> prices, IEnumerable<MoneyElement> moneyElements);
    }
}
