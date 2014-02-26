namespace pay.secupay.Model.Mapping
{
    public class PaySecupayStatusMap : PaySecupayBaseMap<PaySecupayStatus>
    {
        public PaySecupayStatusMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayStatusGuid);

            // Properties
            Property(t => t.ApiKey).IsRequired().HasMaxLength(50);
            Property(t => t.ApiUrl).IsRequired().HasMaxLength(50);
            Property(t => t.Hash).IsRequired().HasMaxLength(50);
            Property(t => t.Status).HasMaxLength(50);
            Property(t => t.Errors);
            Property(t => t.ResponseHash).HasMaxLength(50);
            Property(t => t.ResponsePaymentStatus).HasMaxLength(500);
            Property(t => t.ResponseStatus).HasMaxLength(50);
            //Property(t => t.ResponseCreated);
            //Property(t => t.ResponseAmount);
            Property(t => t.ResponseDemo).HasMaxLength(50);
            Property(t => t.ResponseTransId).HasMaxLength(50);
            //Property(t => t.ResponseOpt);
            //Property(t => t.JsonOut);
            //Property(t => t.JsonIn);

        }
    }
}