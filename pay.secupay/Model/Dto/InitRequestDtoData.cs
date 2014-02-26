using System.Collections.Generic;

namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class InitRequestDtoData
    {
        [DataMember(Name = "apikey")]
        public string ApiKey { get; set; }

        [DataMember(Name = "demo")]
        public string Demo { get; set; }

        [DataMember(Name = "payment_type")]
        public string PaymentType { get; set; }

        [DataMember(Name = "payment_action")]
        public string PaymentAction { get; set; }

        [DataMember(Name = "apiversion")]
        public string ApiVersion { get; set; }

        [DataMember(Name = "amount")]
        public long Amount { get; set; }

        [DataMember(Name = "currency")]
        public string Currency { get; set; }

        [DataMember(Name = "url_success")]
        public string UrlSuccess { get; set; }

        [DataMember(Name = "url_failure")]
        public string UrlFailure { get; set; }

        [DataMember(Name = "url_push")]
        public string UrlPush { get; set; }

        [DataMember(Name = "shop")]
        public string Shop { get; set; }

        [DataMember(Name = "shopversion")]
        public string ShopVersion { get; set; }

        [DataMember(Name = "language")]
        public string Langauge { get; set; }

        [DataMember(Name = "moduleversion")]
        public string ModulVersion { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

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

        [DataMember(Name = "telephone")]
        public string Telephone { get; set; }

        [DataMember(Name = "dob")]
        public string Dob { get; set; }

        [DataMember(Name = "email")]
        public string Email { get; set; }

        [DataMember(Name = "ip")]
        public string Ip { get; set; }

        [DataMember(Name = "purpose")]
        public string Purpose { get; set; }

        [DataMember(Name = "order_id")]
        public string OrderId { get; set; }

        [DataMember(Name = "note")]
        public string Note { get; set; }

        [DataMember(Name = "basket")]
        public List<InitRequestDtoBasket> Basket { get; set; }

        [DataMember(Name = "delivery_address")]
        public InitRequestDtoDeliveryAddress DeliveryAddress { get; set; }


    }
}
