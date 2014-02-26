using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayStatus
    {
        public override Guid DbGuid
        {
            get { return PaySecupayStatusGuid; }
            set { PaySecupayStatusGuid = value; }
        }
    }
}