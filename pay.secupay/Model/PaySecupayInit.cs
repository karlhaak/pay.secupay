using System;
using System.Collections.Generic;

namespace pay.secupay.Model
{
    public partial class PaySecupayInit : PaySecupayBase
    {
        public PaySecupayInit()
        {
            Basket = new List<PaySecupayBasket>();
        }

        public Guid PaySecupayInitGuid { get; set; }
        public string ApiUrl { get; set; }
        public string ApiKey { get; set; }
        public string Demo { get; set; }
        public string PaymentType { get; set; }
        public string PaymentAction { get; set; }
        public string ApiVersion { get; set; }
        public long Amount { get; set; }
        public string Currency { get; set; }
        public string UrlSuccess { get; set; }
        public string UrlFailure { get; set; }
        public string UrlPush { get; set; }
        public string Shop { get; set; }
        public string ShopVersion { get; set; }
        public string Langauge { get; set; }
        public string ModulVersion { get; set; }
        public string Title { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Telephone { get; set; }
        public string Dob { get; set; }
        public string Email { get; set; }
        public string Ip { get; set; }
        public string Purpose { get; set; }
        public string OrderId { get; set; }
        public string Note { get; set; }

        public string ResponseStatus { get; set; }
        public string ResponseHash { get; set; }
        public string ResponseIFrameUrl { get; set; }
        public string ResponseErrors { get; set; }

        public string JsonOut { get; set; }
        public string JsonIn { get; set; }

        public virtual ICollection<PaySecupayBasket> Basket { get; set; }
        public PaySecupayDeliveryAddress DeliveryAddress { get; set; }
    }
}