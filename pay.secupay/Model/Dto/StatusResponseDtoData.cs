namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StatusResponseDtoData
    {
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "payment_status")]
        public string PaymentStatus { get; set; }

        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "created")]
        public string Created { get; set; }

        [DataMember(Name = "demo")]
        public string Demo { get; set; }

        [DataMember(Name = "trans_id")]
        public string TransId { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "opt")]
        public string Opt { get; set; }
    }
}
