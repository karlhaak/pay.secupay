namespace pay.secupay.Model.Mapping
{
    public class PaySecupayPushMap : PaySecupayBaseMap<PaySecupayPush>
    {
        public PaySecupayPushMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayPushGuid);

            // Properties
            Property(t => t.Referrer).IsRequired().HasMaxLength(250);
            Property(t => t.PushUrl).IsRequired().HasMaxLength(250);

            Property(t => t.ApiKey).HasMaxLength(50);
            Property(t => t.Hash).HasMaxLength(50);
            Property(t => t.StatusId).HasMaxLength(50);
            Property(t => t.StatusDescription).HasMaxLength(500);
            Property(t => t.PaymentStatus).HasMaxLength(50);
            Property(t => t.Hint).HasMaxLength(500);
            Property(t => t.Ack).HasMaxLength(100);
            Property(t => t.Error).HasMaxLength(250);
 
        }
    }
}