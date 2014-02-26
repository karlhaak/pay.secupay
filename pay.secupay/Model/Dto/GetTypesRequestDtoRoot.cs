using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace pay.secupay.Model.Dto
{
    [DataContract]
    public class GetTypesRequestDtoRoot : IPaySecupayDto
    {
        [DataMember(Name = "data")]
        public GetTypesRequestDtoData Data { get; set; }
    }
}
