using PosSystem.Common.Dto.Cashier;
using PosSystem.Common.Exceptions;
using PosSystem.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Services
{
    public class CashierService : ICashierService
    {
        private readonly IEnumerable<MoneyElement> availableMoneyElements;

        public CashierService(IEnumerable<MoneyElement> availableMoneyElements)
        {
            this.availableMoneyElements = availableMoneyElements
                .OrderByDescending(moneyElement => moneyElement.Denomination);
        }

        public IEnumerable<MoneyElement> Purchase(IEnumerable<double> prices, IEnumerable<MoneyElement> moneyElements)
        {
            if(prices == null) throw new ArgumentNullException(nameof(prices));
            if (moneyElements == null) throw new ArgumentNullException(nameof(moneyElements));

            var totalPrice = prices.Sum();
            var paid = moneyElements.Sum(moneyElement => moneyElement.Denomination);

            if (totalPrice == 0) throw new NothingToPayPosException();
            if(paid < totalPrice) throw new IncompletePaymentPosException(totalPrice, paid);

            var changeToReturn = paid - totalPrice;

            if(changeToReturn == 0) return new MoneyElement[0];

            var optimizedMoneyElements= GetOptimizedMoneyElements(changeToReturn);

            return GetMoneyElementsDictionaryAsIEnumerable(optimizedMoneyElements);
        }

        /// <summary>
        /// Get optimized set of bills and coins to represent the price
        /// </summary>
        /// <param name="price">The price</param>
        /// <returns>Dictionary with MoneyElement as key and how many items as value</returns>
        private IDictionary<MoneyElement, int> GetOptimizedMoneyElements(double price)
        {
            var result = new Dictionary<MoneyElement, int>();

            var remaining = price;

            foreach(var moneyElement in availableMoneyElements)
            {
                while(moneyElement.Denomination <= remaining)
                {
                    remaining -= moneyElement.Denomination;
                    if (result.ContainsKey(moneyElement))
                    {
                        result[moneyElement]++;
                    }
                    else {
                        result[moneyElement] = 1;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Converts from Dictionary<MoneyElement, HowMany> to a IEnumerable<MoneyElements>
        /// </summary>
        /// <param name="dictionary">Dictionary with MoneyLeement as Key and how many as value</param>
        /// <returns></returns>
        private IEnumerable<MoneyElement> GetMoneyElementsDictionaryAsIEnumerable(IDictionary<MoneyElement, int> dictionary)
        {
            List<MoneyElement> list = new List<MoneyElement>();

            foreach (var moneyElement in dictionary.Keys)
            {
                var howMany = dictionary[moneyElement];
                var elements = Enumerable.Range(0, howMany)
                    .Select(n => new MoneyElement(moneyElement.ElementType, moneyElement.Denomination, moneyElement.Name));

                list.AddRange(elements);
            }

            return list;
        }
    }
}
