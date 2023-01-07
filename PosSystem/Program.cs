// See https://aka.ms/new-console-template for more information
using PosSystem.Common.Dto.Cashier;
using PosSystem.Common.Enums;
using PosSystem.Common.Factories;
using PosSystem.Common.Services;
using PosSystem.Factories.Cashier;

// We create cashierFactory to create cashierService instances
ICashierFactory cashierFactory = new CashierFactory();
ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);

double[] prices = {
    10.80, // Product 1 price
    20.30, // Product 2 price
    99.99, // Product 3 price
    55.9,  // Product 4 price
    1000,  // Product 5 price
    6000   // Product 6 price
};

// User is paying with 10 bills of 1K
List<MoneyElement> moneyElements = new() {
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
    new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"),
};

    //.Select(n => new MoneyElement(MoneyElementType.Bill, 1000, "1K Bill"));

// Purchase the items and get the change,
// change is a list of bills and coins we wil return to the customer
var changeMoneyElements = cashierService.Purchase(prices, moneyElements);

Console.WriteLine($"Cashier must return {changeMoneyElements.Count()} bills and coins as follows: ");

foreach(MoneyElement moneyElement in changeMoneyElements)
{
    Console.WriteLine($"1 {moneyElement.Name}");
}




