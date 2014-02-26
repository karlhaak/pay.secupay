namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StatusResponseDtoRoot : IPaySecupayDto
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "data")]
        public StatusResponseDtoData Data { get; set; }

        [DataMember(Name = "errors")]
        public string Errors { get; set; }

    }
}
