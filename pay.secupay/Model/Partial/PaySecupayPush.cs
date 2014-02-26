using System;

namespace pay.secupay.Model
{
    public partial class PaySecupayPush
    {
        public override Guid DbGuid
        {
            get { return PaySecupayPushGuid; }
            set { PaySecupayPushGuid = value; }
        }
    }
}