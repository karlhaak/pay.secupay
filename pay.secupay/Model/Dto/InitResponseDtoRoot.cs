using System.Runtime.Serialization;

namespace pay.secupay.Model.Dto
{
    [DataContract]
    public class InitResponseDtoRoot
    {
        [DataMember(Name = "status")]
        public string Status { get; set; }

        [DataMember(Name = "data")]
        public InitResponseDtoData Data { get; set; }

        [DataMember(Name = "errors")]
        public string Errors { get; set; }
    }
}
