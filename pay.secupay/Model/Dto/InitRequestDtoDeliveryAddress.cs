namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class InitRequestDtoDeliveryAddress
    {
        [DataMember(Name = "firstname")]
        public string Firstname { get; set; }

        [DataMember(Name = "lastname")]
        public string Lastname { get; set; }

        [DataMember(Name = "company")]
        public string Company { get; set; }

        [DataMember(Name = "street")]
        public string Street { get; set; }

        [DataMember(Name = "housenumber")]
        public string Housenumber { get; set; }

        [DataMember(Name = "zip")]
        public string Zip { get; set; }

        [DataMember(Name = "city")]
        public string City { get; set; }

        [DataMember(Name = "country")]
        public string Country { get; set; }

    }
}
