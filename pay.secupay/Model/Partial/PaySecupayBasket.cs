using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayBasket
    {
        public override Guid DbGuid
        {
            get { return PaySecupayBasketGuid; }
            set { PaySecupayBasketGuid = value; }
        }
    }
}