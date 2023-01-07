using PosSystem.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosSystem.Common.Dto.Cashier
{
    /// <summary>
    /// Data Transfer Object to handle MoneyElement,
    /// A MoneyElement can be either Bill with denomination or coin with denomination
    /// </summary>
    /// <param name="ElementType">Bill or Coin is supported</param>
    /// <param name="Denomination">Value for the bill or coin</param>
    /// <param name="Name">Name of bill/coin</param>
    public record MoneyElement(MoneyElementType ElementType, double Denomination, string Name = "");
}
