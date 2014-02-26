namespace pay.secupay.Model.Mapping
{
    public class PaySecupayPayGetTypesMap : PaySecupayBaseMap<PaySecupayGetTypes>
    {
        public PaySecupayPayGetTypesMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayGetTypesGuid);

            // Properties
            Property(t => t.ApiKey).IsRequired().HasMaxLength(50);
            Property(t => t.ApiUrl).IsRequired().HasMaxLength(50);
            Property(t => t.ResponsePaymentTypes).HasMaxLength(500);
            Property(t => t.ResponseErrors).HasMaxLength(500);
            Property(t => t.ResponseStatus).HasMaxLength(50);
            Property(t => t.JsonOut).HasMaxLength(500);
            Property(t => t.JsonIn).HasMaxLength(500);
        }
    }
}