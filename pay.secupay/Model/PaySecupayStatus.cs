namespace pay.secupay.Model
{
    using System;

    public partial class PaySecupayStatus : PaySecupayBase
    {
        public Guid PaySecupayStatusGuid { get; set; }
        public string ApiKey { get; set; }
        public string ApiUrl { get; set; }
        public string Hash { get; set; }
        public string Status { get; set; }
        public string Errors { get; set; }

        public string ResponseHash { get; set; }
        public string ResponsePaymentStatus { get; set; }
        public string ResponseStatus { get; set; }
        public DateTime? ResponseCreated { get; set; }
        public string ResponseDemo { get; set; }
        public string ResponseTransId { get; set; }
        public long? ResponseAmount { get; set; }
        public string ResponseOpt { get; set; }

        public string JsonOut { get; set; }
        public string JsonIn { get; set; }


    }
}