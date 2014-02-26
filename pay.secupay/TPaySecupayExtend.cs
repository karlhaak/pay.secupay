namespace pay.secupay.Model
{
    using System;

    public static class TPaySecupayExtend
    {
        public static T SetNew<T>(this T item, string username) where T : PaySecupayBase, IPaySecupay
        {
            item.DbGuid = Guid.NewGuid();
            item.CreatedAt = DateTime.Now;
            item.CreatedBy = username;
            return item;
        }
    }
}