using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace pay.secupay.Model.Dto
{
    [DataContract]
    public class GetTypesRequestDtoData
    {
        [DataMember(Name = "apikey")]
        public string ApiKey { get; set; }
    }
}
