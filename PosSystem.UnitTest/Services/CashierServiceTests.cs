using PosSystem.Common.Dto.Cashier;
using PosSystem.Common.Enums;
using PosSystem.Common.Exceptions;
using PosSystem.Common.Factories;
using PosSystem.Common.Services;
using PosSystem.Factories.Cashier;
using PosSystem.Services;

namespace PosSystem.UnitTest.Services
{
    [TestClass]
    public class CashierServiceTests
    {
        private ICashierFactory cashierFactory;

        [TestInitialize]
        public void Initialize()
        {
            cashierFactory = new CashierFactory();
        }


        [TestMethod]
        public void ShouldReturnTwoCoins_OneOf10Cents_OneOf25Cents()
        {
            // Arrange
            ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);
            double[] articlePrices = { 0.10, 0.50, 0.25 };
            List<MoneyElement> paidByUser = new List<MoneyElement>
            {
                new MoneyElement(MoneyElementType.Bill, 1),
            };

            var expectedTotalCoins = 2;
            var expectedCoinsOf25Cents = 1;
            var expectedCoinsOf10Cents = 1;

            // Act
            var change = cashierService.Purchase(articlePrices, paidByUser);

            // Assert
            Assert.AreEqual(expectedTotalCoins, change.Count());
            Assert.AreEqual(expectedCoinsOf10Cents, change.Count(coin => coin.Denomination == 0.10));
            Assert.AreEqual(expectedCoinsOf25Cents, change.Count(coin => coin.Denomination == 0.05));
        }

        [TestMethod]
        public void PricesIsNull_ShouldReturn_ArgumentNullException()
        {
            // Arrange
            ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);
            double[] articlePrices = null;
            List<MoneyElement> paidByUser = new List<MoneyElement>
            {
                new MoneyElement(MoneyElementType.Bill, 1),
            };

            // Act
            var action = () => cashierService.Purchase(articlePrices, paidByUser);

            // Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void PaidByUserIsNull_ShouldReturn_ArgumentNullException()
        {
            // Arrange
            ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);
            double[] articlePrices = { 0.10, 0.50, 0.25 };
            List<MoneyElement> paidByUser = null;

            // Act
            var action = () => cashierService.Purchase(articlePrices, paidByUser);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        public void UserNotPayingCompleteAmount_ShouldThrowException()
        {
            // Arrange
            ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);
            double[] articlePrices = { 0.10, 0.50, 0.25 };
            List<MoneyElement> paidByUser = new List<MoneyElement>
            {
                new MoneyElement(MoneyElementType.Coin, 0.10),
            };

            // Act
            var action = () => cashierService.Purchase(articlePrices, paidByUser);

            // Assert
            Assert.ThrowsException<IncompletePaymentPosException>(action);
        }

        [TestMethod]
        public void ProductPricesArrayIsEmpty_ShouldReturnNothingToPayException()
        {
            // Arrange
            ICashierService cashierService = cashierFactory.CreateInstance(CountryType.UnitedStates);
            double[] articlePrices = { };
            List<MoneyElement> paidByUser = new List<MoneyElement>
            {
                new MoneyElement(MoneyElementType.Bill, 1),
            };

            // Act
            var action = () => cashierService.Purchase(articlePrices, paidByUser);

            // Assert
            Assert.ThrowsException<NothingToPayPosException>(action);
        }
    }
}