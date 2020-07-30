using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.TaxJar;

namespace TaxCalculator.Tests
{
    [TestClass]
    public class TaxCalculatorServiceTest
    {
        [TestMethod]
        public void TestGetLocationTaxRate()
        {
            var service = new TaxCalculatorService(new TaxJarClient());
            var taxRate = service.GetLocationTaxRate("33441");

            Assert.IsNotNull(taxRate);
            Assert.AreEqual(0.07f, taxRate);
        }

        [TestMethod]
        public void TestCalculateOrderTaxes()
        {
            var service = new TaxCalculatorService(new TaxJarClient());
            var orderTaxes = service.CalculateOrderTaxes("US", "CA", "92093", 100f, 10f);

            Assert.IsNotNull(orderTaxes);
            Assert.AreEqual(0f, orderTaxes);
        }
    }
}