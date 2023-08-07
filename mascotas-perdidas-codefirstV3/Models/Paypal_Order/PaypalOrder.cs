using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationpaypal_1.Models.Paypal_Order
{
    public class PaypalOrder
    {
        public string intent { get; set; }
        public ApplicationContext application_context { get; set; }
        public List<PurchaseUnit> purchase_units { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Amount
    {
        public string currency_code { get; set; }
        public string value { get; set; }
    }

    public class ApplicationContext
    {
        public string return_url { get; set; }
        public string cancel_url { get; set; }
    }

    public class PurchaseUnit
    {
        public Amount amount { get; set; }
    }
}