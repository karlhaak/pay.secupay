using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayDeliveryAddress : PaySecupayBase
    {
        public Guid PaySecupayInitGuid { get; set; }

        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Company { get; set; }
        public string Street { get; set; }
        public string Housenumber { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        public PaySecupayInit Init { get; set; }
    }
}