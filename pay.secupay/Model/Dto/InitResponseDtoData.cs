using System.Runtime.Serialization;

namespace pay.secupay.Model.Dto
{
    [DataContract]
    public class InitResponseDtoData
    {
        [DataMember(Name = "hash")]
        public string Hash { get; set; }

        [DataMember(Name = "iframe_url")]
        public string IFrameUrl { get; set; }

    }
}
