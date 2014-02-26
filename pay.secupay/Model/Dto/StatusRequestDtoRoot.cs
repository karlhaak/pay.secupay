namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StatusRequestDtoRoot : IPaySecupayDto
    {
        [DataMember(Name = "data")]
        public StatusRequestDtoData Data { get; set; }
    
    }
}
