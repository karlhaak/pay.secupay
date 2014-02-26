namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class StatusRequestDtoData
    {
        [DataMember(Name = "apikey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "hash")]
        public string Hash { get; set; }
    }
}
