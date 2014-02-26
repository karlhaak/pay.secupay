using System.Data.Entity.ModelConfiguration;

namespace pay.secupay.Model.Mapping
{
    public abstract class PaySecupayBaseMap<T> : EntityTypeConfiguration<T> where T : PaySecupayBase
    {
        protected PaySecupayBaseMap()
        {
            Ignore(t => t.DbGuid);

            // Properties

            Property(t => t.CreatedBy)
                .IsRequired()
                .HasMaxLength(50);

            Property(t => t.ChangedBy)
                .HasMaxLength(50);

            Property(t => t.DeletedBy)
                .HasMaxLength(50);

            Property(t => t.RowVersion)
                .IsRequired()
                .IsFixedLength()
                .HasMaxLength(8)
                .IsRowVersion()
                .IsConcurrencyToken();

            // Table & Column Mappings
            Property(t => t.CreatedAt).HasColumnName("CreatedAt");
            Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            Property(t => t.ChangedAt).HasColumnName("ChangedAt");
            Property(t => t.ChangedBy).HasColumnName("ChangedBy");
            Property(t => t.DeletedAt).HasColumnName("DeletedAt");
            Property(t => t.DeletedBy).HasColumnName("DeletedBy");
            Property(t => t.RowVersion).HasColumnName("RowVersion");
        }
    }
}