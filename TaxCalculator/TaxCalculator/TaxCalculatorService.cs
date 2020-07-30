namespace TaxCalculator
{
    public class TaxCalculatorService : ITaxCalculatorService
    {
        private ITaxCalculatorService clientClass { get; set; }

        public TaxCalculatorService(ITaxCalculatorService taxCalculatorClient)
        {
            clientClass = taxCalculatorClient;
        }

        public float GetLocationTaxRate(string zipCode)
        {
            return clientClass.GetLocationTaxRate(zipCode);
        }

        public float CalculateOrderTaxes(string countryCode, string stateCode, string zipCode, float orderAmount, float shippingRate)
        {
            return clientClass.CalculateOrderTaxes(countryCode, stateCode, zipCode, orderAmount, shippingRate);
        }
    }
}