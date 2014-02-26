namespace pay.secupay.Model.Dto
{
    using System.Runtime.Serialization;

    [DataContract]
    public class InitRequestDtoBasket
    {
        [DataMember(Name = "article_number")]
        public string ArticleNumber { get; set; }

        [DataMember(Name = "name")]
        public string Name { get; set; }

        [DataMember(Name = "model")]
        public string Model { get; set; }

        [DataMember(Name = "ean")]
        public string Ean { get; set; }

        [DataMember(Name = "quantity")]
        public string Quantity { get; set; }

        [DataMember(Name = "price")]
        public string Price { get; set; }

        [DataMember(Name = "total")]
        public string Total { get; set; }

        [DataMember(Name = "tax")]
        public string Tax { get; set; }


    }
}
