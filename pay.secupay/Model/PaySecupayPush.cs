namespace pay.secupay.Model
{
    using System;

    public partial class PaySecupayPush : PaySecupayBase
    {
        public Guid PaySecupayPushGuid { get; set; }
        public string PushUrl { get; set; }
        public string Referrer { get; set; }

        public string Hash { get; set; }
        public string StatusId { get; set; }
        public string StatusDescription { get; set; }
        public long? Changed { get; set; }
        public DateTime? ChangedDate { get; set; }
        public string PaymentStatus { get; set; }
        public string ApiKey { get; set; }
        public string Hint { get; set; }

        public string Ack { get; set; }
        public string Error { get; set; }

        public string PostIn { get; set; }
        public string PostOut { get; set; }
    }
}