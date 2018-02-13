namespace pay.secupay.Model.Mapping
{
    public class PaySecupayBasketMap : PaySecupayBaseMap<PaySecupayBasket>
    {
        public PaySecupayBasketMap()
        {
            // Primary Key
            HasKey(t => t.PaySecupayBasketGuid);

            // Foreign Key
            HasRequired(t => t.Init).WithMany(t => t.Basket).HasForeignKey(t=>t.PaySecupayInitGuid);
            
            // Properties
            Property(t => t.ArticleNumber).IsRequired().HasMaxLength(200);
            Property(t => t.Name).HasMaxLength(200);
            Property(t => t.Model).HasMaxLength(200);
            Property(t => t.Ean).HasMaxLength(100);
            Property(t => t.Quantity).HasMaxLength(50);
            Property(t => t.Price).HasMaxLength(50);
            Property(t => t.Total).HasMaxLength(50);
            Property(t => t.Tax).HasMaxLength(50);

        }
    }
}