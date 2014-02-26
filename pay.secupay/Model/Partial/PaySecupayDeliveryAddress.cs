using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayDeliveryAddress
    {
        public override Guid DbGuid
        {
            get { return PaySecupayInitGuid; }
            set { PaySecupayInitGuid = value; }
        }
    }
}