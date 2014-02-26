using System;


namespace pay.secupay.Model
{
    public abstract class PaySecupayBase : IPaySecupay
    {
        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ChangedAt { get; set; }
        public string ChangedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }
        public byte[] RowVersion { get; set; }

        public abstract Guid DbGuid { get; set; }
    }
}