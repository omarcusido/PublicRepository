using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace TaxCalculator.TaxJar
{
    /// <summary>
    /// Client class for TaxJar Calculator API.
    /// </summary>
    public class TaxJarClient : ITaxCalculatorService
    {
        private const string BaseURL = "https://api.taxjar.com/v2/";
        private const string APIKey = "5da2f821eee4035db4771edab942a4cc";

        public float GetLocationTaxRate(string zipCode)
        {
            using (var taxClient = new HttpClient { BaseAddress = new Uri(BaseURL) })
            {
                taxClient.DefaultRequestHeaders.Accept.Clear();
                taxClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                taxClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);

                using (var apiResponse = taxClient.GetAsync($"rates/{ zipCode }").Result)
                {
                    var result = apiResponse.Content.ReadAsAsync<TaxJarRatesResponse>().Result;

                    return result.rate.combined_rate;
                }
            }
        }

        public float CalculateOrderTaxes(string countryCode, string stateCode, string zipCode, float orderAmount, float shippingRate)
        {
            using (var taxClient = new HttpClient { BaseAddress = new Uri(BaseURL) })
            {
                taxClient.DefaultRequestHeaders.Accept.Clear();
                taxClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                taxClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", APIKey);

                var requestData = new TaxJarTaxesRequest
                {
                    to_country = countryCode,
                    to_state = stateCode,
                    to_zip = zipCode,
                    amount = orderAmount,
                    shipping = shippingRate
                };

                using (var apiResponse = taxClient.PostAsync("taxes", requestData, new JsonMediaTypeFormatter()).Result)
                {
                    var result = apiResponse.Content.ReadAsAsync<TaxJarTaxesResponse>().Result;

                    return result.tax.amount_to_collect;
                }
            }
        }
    }
}