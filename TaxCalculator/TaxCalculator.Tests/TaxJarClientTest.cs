using Microsoft.VisualStudio.TestTools.UnitTesting;
using TaxCalculator.TaxJar;

namespace TaxCalculator.Tests
{
    [TestClass]
    public class TaxJarClientTest
    {
        [TestMethod]
        public void TestGetLocationTaxRate()
        {
            var client = new TaxJarClient();
            var taxRate = client.GetLocationTaxRate("33441");

            Assert.IsNotNull(taxRate);
            Assert.AreEqual(0.07f, taxRate);
        }

        [TestMethod]
        public void TestCalculateOrderTaxes()
        {
            var client = new TaxJarClient();
            var orderTaxes = client.CalculateOrderTaxes("US", "CA", "92093", 100f, 10f);

            Assert.IsNotNull(orderTaxes);
            Assert.AreEqual(0f, orderTaxes);
        }
    }
}