namespace pay.secupay.Model.Mapping
{
    public class PaySecupayPayInitMap : PaySecupayBaseMap<PaySecupayInit>
    {
        public PaySecupayPayInitMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayInitGuid);

            // Properties
            Property(t => t.ApiUrl).HasMaxLength(250);

            Property(t => t.ApiKey).IsRequired().HasMaxLength(50);
            Property(t => t.Demo).HasMaxLength(1);
            Property(t => t.PaymentType).HasMaxLength(50);
            Property(t => t.PaymentAction).HasMaxLength(50);
            Property(t => t.ApiVersion).HasMaxLength(50);
            Property(t => t.Amount).IsRequired();
            Property(t => t.Currency).HasMaxLength(10);
            Property(t => t.UrlSuccess).HasMaxLength(250);
            Property(t => t.UrlFailure).HasMaxLength(250);
            Property(t => t.UrlPush).HasMaxLength(250);
            Property(t => t.Shop).HasMaxLength(250);
            Property(t => t.ShopVersion).HasMaxLength(50);
            Property(t => t.Langauge).HasMaxLength(10);
            Property(t => t.ModulVersion).HasMaxLength(100);
            Property(t => t.Title).HasMaxLength(50);
            Property(t => t.Firstname).HasMaxLength(100);
            Property(t => t.Lastname).HasMaxLength(100);
            Property(t => t.Company).HasMaxLength(100);
            Property(t => t.Housenumber).HasMaxLength(50);
            Property(t => t.Zip).HasMaxLength(50);
            Property(t => t.City).HasMaxLength(200);
            Property(t => t.Country).HasMaxLength(200);
            Property(t => t.Telephone).HasMaxLength(100);
            Property(t => t.Dob).HasMaxLength(50);
            Property(t => t.Email).HasMaxLength(250);
            Property(t => t.Ip).HasMaxLength(20);
            Property(t => t.Purpose).HasMaxLength(500);
            Property(t => t.OrderId).HasMaxLength(100);
            Property(t => t.Note).HasMaxLength(500);

            Property(t => t.ResponseStatus).HasMaxLength(50);
            Property(t => t.ResponseHash).HasMaxLength(30);
            Property(t => t.ResponseIFrameUrl).HasMaxLength(250);
            Property(t => t.ResponseErrors).HasMaxLength(500);

        }
    }
}