using System.ServiceModel;

namespace TaxCalculator
{
    /// <summary>
    /// Every time a new Tax Calculator provider is added a
    /// new client class will be created implementing this interface.
    /// </summary>
    [ServiceContract]
    public interface ITaxCalculatorService
    {
        [OperationContract]
        float GetLocationTaxRate(string zipCode);
        [OperationContract]
        float CalculateOrderTaxes(string countryCode, string stateCode, string zipCode, float orderAmount, float shippingRate);
    }
}