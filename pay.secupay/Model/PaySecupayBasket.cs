using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayBasket : PaySecupayBase
    {
        public Guid PaySecupayBasketGuid { get; set; }
        public Guid PaySecupayInitGuid { get; set; }
        public string ArticleNumber { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Ean { get; set; }
        public string Quantity { get; set; }
        public string Price { get; set; }
        public string Total { get; set; }
        public string Tax { get; set; }

        public PaySecupayInit Init { get; set; }

        
    }
}