using System.Collections.Generic;
using System.Linq;
using System.Web.Routing;

namespace pay.secupay
{
    using Model;
    using Model.Dto;

    internal static class TDtoFactory
    {
        internal static GetTypesRequestDtoRoot CreateGetTypesRequestDtoRoot(PaySecupayGetTypes secupayGetTypes)
        {
            GetTypesRequestDtoRoot root = new GetTypesRequestDtoRoot
            {
                Data = new GetTypesRequestDtoData { ApiKey = secupayGetTypes.ApiKey }
            };
            return root;
        }


        internal static InitRequestDtoRoot CreateInitRequestDtoRoot(PaySecupayInit secupayInit, TPaySecupayConfig config)
        {
            InitRequestDtoRoot root = new InitRequestDtoRoot
            {
                Data = new InitRequestDtoData
                {
                    ApiKey = secupayInit.ApiKey,
                    Amount = secupayInit.Amount,
                    Currency = secupayInit.Currency,
                    ApiVersion = secupayInit.ApiVersion,

                    Title = secupayInit.Title,
                    Firstname = secupayInit.Firstname,
                    Lastname = secupayInit.Lastname,
                    Company = secupayInit.Company,
                    Street = secupayInit.Street,
                    Housenumber = secupayInit.Housenumber,
                    Zip = secupayInit.Zip,
                    City = secupayInit.City,
                    Country = secupayInit.Country,
                    Telephone = secupayInit.Telephone,
                    Dob = secupayInit.Dob,

                    Demo = secupayInit.Demo,
                    Email = secupayInit.Email,
                    Ip = secupayInit.Ip,
                    Langauge = secupayInit.Langauge,
                    ModulVersion = secupayInit.ModulVersion,
                    Note = secupayInit.Note,
                    OrderId = secupayInit.OrderId,
                    PaymentAction = secupayInit.PaymentAction,
                    PaymentType = secupayInit.PaymentType,
                    Purpose = secupayInit.Purpose,
                    Shop = secupayInit.Shop,
                    ShopVersion = secupayInit.ShopVersion,
                    UrlFailure = secupayInit.UrlFailure,
                    UrlPush = secupayInit.UrlPush,
                    UrlSuccess = secupayInit.UrlSuccess
                }
            };

            if (secupayInit.DeliveryAddress != null && config.SendDeliveryAddress)
            {
                root.Data.DeliveryAddress = new InitRequestDtoDeliveryAddress
                {
                    Firstname = secupayInit.DeliveryAddress.Firstname,
                    Lastname = secupayInit.DeliveryAddress.Lastname,
                    Company = secupayInit.DeliveryAddress.Company,
                    Street = secupayInit.DeliveryAddress.Street,
                    Housenumber = secupayInit.DeliveryAddress.Housenumber,
                    Zip = secupayInit.DeliveryAddress.Zip,
                    City = secupayInit.DeliveryAddress.City,
                    Country = secupayInit.DeliveryAddress.Country,
                };
            }

            if (secupayInit.Basket != null && secupayInit.Basket.Any())
            {
                root.Data.Basket = new List<InitRequestDtoBasket>();
                foreach (var b in secupayInit.Basket)
                {
                    root.Data.Basket.Add(new InitRequestDtoBasket
                    {
                        ArticleNumber = b.ArticleNumber,
                        Model = b.Model,
                        Ean = b.Ean,
                        Name = b.Name,
                        Price = b.Price,
                        Quantity = b.Quantity,
                        Tax = b.Tax,
                        Total = b.Total
                    });
                }
            }

            return root;
        }

        internal static StatusRequestDtoRoot CreateStatusRequestDtoRoot(PaySecupayStatus secupayStatus)
        {
            StatusRequestDtoRoot root = new StatusRequestDtoRoot
            {
                Data = new StatusRequestDtoData
                {
                    ApiKey = secupayStatus.ApiKey,
                    Hash = secupayStatus.Hash
                }
            };
            return root;
        }
    }
}
