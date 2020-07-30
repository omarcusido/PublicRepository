namespace TaxCalculator.TaxJar
{
    // The following are the request and response classes used by TaxJar API.
    // I have created simplified versions with only the required data for the purpose of this demonstration.
    public class TaxJarTaxesRequest
    {
        public string to_country { get; set; }
        public string to_zip { get; set; }
        public string to_state { get; set; }
        public float shipping { get; set; }
        public float amount { get; set; }
    }

    public class TaxJarTaxesResponse
    {
        public TaxJarTaxDetail tax { get; set; }
    }

    public class TaxJarTaxDetail
    {
        public float amount_to_collect { get; set; }
        public bool freight_taxable { get; set; }
        public bool has_nexus { get; set; }
        public float order_total_amount { get; set; }
        public float rate { get; set; }
        public float shipping { get; set; }
        public string tax_source { get; set; }
        public float taxable_amount { get; set; }
    }

    public class TaxJarRatesResponse
    {
        public TaxJarRateDetail rate { get; set; }
    }

    public class TaxJarRateDetail
    {
        public string city { get; set; }
        public float city_rate { get; set; }
        public float combined_district_rate { get; set; }
        public float combined_rate { get; set; }
        public string country { get; set; }
        public float country_rate { get; set; }
        public string county { get; set; }
        public float county_rate { get; set; }
        public bool freight_taxable { get; set; }
        public string state { get; set; }
        public float state_rate { get; set; }
        public string zip { get; set; }
    }
}