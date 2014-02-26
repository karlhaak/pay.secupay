namespace pay.secupay.Model.Mapping
{
    public class PaySecupayDeliveryAddressMap : PaySecupayBaseMap<PaySecupayDeliveryAddress>
    {
        public PaySecupayDeliveryAddressMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayInitGuid);

            // Foreign Key
            HasRequired(t => t.Init).WithRequiredDependent(t => t.DeliveryAddress);

            // Properties
            Property(t => t.Firstname).HasMaxLength(100);
            Property(t => t.Lastname).HasMaxLength(100);
            Property(t => t.Company).HasMaxLength(100);
            Property(t => t.Street).HasMaxLength(100);
            Property(t => t.Housenumber).HasMaxLength(50);
            Property(t => t.Zip).HasMaxLength(50);
            Property(t => t.City).HasMaxLength(100);
            Property(t => t.Country).HasMaxLength(100);
           
        }
    }
}