using System.Runtime.Serialization;

namespace pay.secupay.Model.Dto
{
    [DataContract]
    public class InitRequestDtoRoot : IPaySecupayDto
    {
        [DataMember(Name = "data")]
        public InitRequestDtoData Data { get; set; }
    }
}
