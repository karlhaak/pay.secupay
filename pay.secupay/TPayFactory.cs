namespace pay.secupay
{
    using System;
    using System.Reflection;
    using pay.secupay.Model;

    public class TPayFactory
    {
        #region ### Member ###

        private readonly TPaySecupayConfig Config;

        #endregion

        #region ### Ctor ###

        public TPayFactory(TPaySecupayConfig config)
        {
            Config = config;
        }

        #endregion

        #region ### Public ###

        /// <summary>
        ///     Erzeugt eine neues Initialisierungs Objekte für den angegebenen Betrag.
        ///     Grundlegenden Parameter werden aus der Config entnommen
        /// </summary>
        public PaySecupayInit CreateSecupayInit(decimal amount)
        {
            PaySecupayInit paySecupayInit = new PaySecupayInit
            {
                ApiKey = Config.ApiKey,
                ApiVersion = Config.ApiVersion,
                Amount = (int) Math.Abs(amount*100m),
                Currency = "EUR",
                ApiUrl = Config.SecupayUrl,
                UrlSuccess = Config.UrlSuccess,
                UrlFailure = Config.UrlFailure,
                UrlPush = Config.UrlPush,
                Langauge = "de_DE",
                Shop = Config.Shop,
                ShopVersion = Config.Shop + " " + Assembly.GetExecutingAssembly().GetName().Version,
                ModulVersion = Config.Shop + " " + Assembly.GetExecutingAssembly().GetName().Version
            }.SetNew(Config.Username);

            return paySecupayInit;
        }

        /// <summary>
        ///     Erzeugt eine SecuPay Statusanfrage
        ///     Als Schlüssel dient der Hashkey, der während der Init Phase vom Gateway gesendet wurde
        ///     ApiKey und Gateway Url werden aus der config entnommen
        /// </summary>
        public PaySecupayStatus CreateSecupayStatus(string hash)
        {
            PaySecupayStatus paySecupayStatus = new PaySecupayStatus
            {
                ApiKey = Config.ApiKey,
                ApiUrl = Config.SecupayUrl,
                Hash = hash
            }.SetNew(Config.Username);

            return paySecupayStatus;
        }

        #endregion
    }
}