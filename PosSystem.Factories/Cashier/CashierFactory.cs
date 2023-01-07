using PosSystem.Common.Dto.Cashier;
using PosSystem.Common.Enums;
using PosSystem.Common.Factories;
using PosSystem.Common.Services;
using PosSystem.Services;

namespace PosSystem.Factories.Cashier
{
    public class CashierFactory : ICashierFactory
    {
        private readonly Dictionary<CountryType, List<MoneyElement>> globalConfigs;
        public CashierFactory()
        {
            globalConfigs = new Dictionary<CountryType, List<MoneyElement>>();

            globalConfigs[CountryType.UnitedStates] = new List<MoneyElement>() {
                    new MoneyElement(MoneyElementType.Coin, 0.01, "Penny"),
                    new MoneyElement(MoneyElementType.Coin, 0.05, "Nickel"),
                    new MoneyElement(MoneyElementType.Coin, 0.10, "Dime"),
                    new MoneyElement(MoneyElementType.Coin, 0.25, "Quarter"),
                    new MoneyElement(MoneyElementType.Coin, 0.50, "HalfDollar"),

                    new MoneyElement(MoneyElementType.Bill, 1, "1 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 2, "2 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 5, "5 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 10, "10 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 20, "20 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 50, "50 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 100, "100 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 500, "500 Dollar Bill"),
                    new MoneyElement(MoneyElementType.Bill, 1000, "1K Dollar Bill")
                };

            globalConfigs[CountryType.Mexico] = new List<MoneyElement> {
                    new MoneyElement(MoneyElementType.Coin, 0.10, "Moneda de 10 Centavos"),
                    new MoneyElement(MoneyElementType.Coin, 0.25, "Moneda de 20 Centavos"),
                    new MoneyElement(MoneyElementType.Coin, 0.50, "Moneda de 50 Centavos"),
                    new MoneyElement(MoneyElementType.Coin, 1, "Moneda de 1 Peso"),
                    new MoneyElement(MoneyElementType.Coin, 2, "Moneda de 2 Pesos"),
                    new MoneyElement(MoneyElementType.Coin, 10, "Moneda de 10 Pesos"),

                    new MoneyElement(MoneyElementType.Bill, 20, "Billete de 20 Pesos"),
                    new MoneyElement(MoneyElementType.Bill, 50, "Billete de 50 Pesos"),
                    new MoneyElement(MoneyElementType.Bill, 100, "Billete de 100 Pesos"),
                    new MoneyElement(MoneyElementType.Bill, 200, "Billete de 200 Pesos"),
                    new MoneyElement(MoneyElementType.Bill, 500, "Billete de 500 Pesos"),
                    new MoneyElement(MoneyElementType.Bill, 1000, "Billete de 1000 Pesos")
                };

        }
        public ICashierService CreateInstance(CountryType countryType)
        {
            return new CashierService(globalConfigs[countryType]);
        
        }
    }
}
