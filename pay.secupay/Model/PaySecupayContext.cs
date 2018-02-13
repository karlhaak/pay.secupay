using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using pay.secupay.Model.Mapping;

namespace pay.secupay.Model
{
    public class PaySecupayContext : DbContext
    {
        public PaySecupayContext(string connectionString, string username)
            : base(connectionString)
        {
            Username = username;
            //Database.SetInitializer(new DropCreateDatabaseIfModelChanges<PaySecupayContext>());
        }

        private string Username { get; set; }

        public DbSet<PaySecupayGetTypes> PaySecupayGetTypes { get; set; }
        public DbSet<PaySecupayInit> PaySecupayInit { get; set; }
        public DbSet<PaySecupayStatus> PaySecupayStatus { get; set; }
        public DbSet<PaySecupayPush> PaySecupayPush { get; set; }

        public override int SaveChanges()
        {
            foreach (
                DbEntityEntry ent in
                    ChangeTracker.Entries().Where(p => p.State == EntityState.Added || p.State == EntityState.Modified))
            {
                var paySecupayEntity = ent.Entity as PaySecupayBase;
                if (paySecupayEntity != null)
                {
                    if (ent.State == EntityState.Added)
                    {
                        paySecupayEntity.CreatedAt = DateTime.Now;
                        paySecupayEntity.CreatedBy = Username;
                    }
                    if (ent.State == EntityState.Modified)
                    {
                        paySecupayEntity.ChangedAt = DateTime.Now;
                        paySecupayEntity.ChangedBy = Username;
                    }
                }
            }
            return base.SaveChanges();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Configurations.Add(new PaySecupayPayGetTypesMap());
            modelBuilder.Configurations.Add(new PaySecupayPayInitMap());
            modelBuilder.Configurations.Add(new PaySecupayStatusMap());
            modelBuilder.Configurations.Add(new PaySecupayPushMap());
            modelBuilder.Configurations.Add(new PaySecupayBasketMap());
            modelBuilder.Configurations.Add(new PaySecupayDeliveryAddressMap());
        }
    }
}