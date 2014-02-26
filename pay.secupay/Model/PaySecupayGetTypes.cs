namespace pay.secupay.Model
{
    using System;

    public partial class PaySecupayGetTypes : PaySecupayBase
    {
        public Guid PaySecupayGetTypesGuid { get; set; }
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }

        public string JsonOut { get; set; }
        public string JsonIn { get; set; }

        public string ResponseStatus { get; set; }
        public string ResponsePaymentTypes { get; set; }
        public string ResponseErrors { get; set; }
    }
}