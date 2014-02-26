namespace pay.secupay
{
    using System;
    using System.Collections.Specialized;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Text;
    using System.Web;
    using pay.secupay.Model;
    using pay.secupay.Model.Dto;

    public class TPaySecupayManager
    {
        #region ### Member ###

        private readonly TPaySecupayConfig Config;
        private readonly PaySecupayContext Context;

        #endregion

        #region ### Ctor ###

        public TPaySecupayManager(TPaySecupayConfig config)
        {
            Config = config;
            Context = new PaySecupayContext(config.ConnectionString, config.Username);
            if (EventLog.Exists("pay.secupay")) EventLog.CreateEventSource("Application", "pay.secupay");
        }

        #endregion

        #region ### Private ###

        /// <summary>
        ///     Basis für den Austausch von JSON Nachrichten am Gateway
        /// </summary>
        private static string RunWebRequest(string url, string json)
        {
            var request = (HttpWebRequest) WebRequest.Create(url);

            // Header Informationen 
            request.ContentType = "application/json";
            request.Method = "POST";
            request.AllowAutoRedirect = false;
            request.KeepAlive = false;
            request.Timeout = 30000;
            request.ReadWriteTimeout = 30000;
            request.UserAgent = "secupay.net";
            request.Accept = "application/json";
            request.ProtocolVersion = HttpVersion.Version11;
            request.Headers.Add("Accept-Language", "de_DE");
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls;

            // Das Zertifikat wird akzeptiert ohne Prüfung
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            // JSON Anfrage wird gesendet
            byte[] bytes = Encoding.UTF8.GetBytes(json);
            request.ContentLength = bytes.Length;

            using (Stream writer = request.GetRequestStream())
            {
                writer.Write(bytes, 0, bytes.Length);
                writer.Flush();
                writer.Close();
            }

            // JSON Antwort wird empfangen
            var httpResponse = (HttpWebResponse) request.GetResponse();
            Stream httpResponseStream = httpResponse.GetResponseStream();
            if (httpResponseStream == null) return null;

            using (var streamReader = new StreamReader(httpResponseStream))
            {
                string jsonReturn = streamReader.ReadToEnd();
                return jsonReturn;
            }
        }

        /// <summary>
        ///     Führt Abfrage der vorhandenen Zahlungsmethoden durch.
        ///     Kommuniaktion erfolgt im JSON Format
        /// </summary>
        private void RunPaymentGetTypes(PaySecupayGetTypes secupayGetTypes)
        {
            // Die Initialisierung wird in ein Data Transport Objekte gewandelt, das als JSON seralisiert werden kann
            GetTypesRequestDtoRoot dto = TDtoFactory.CreateGetTypesRequestDtoRoot(secupayGetTypes);
            secupayGetTypes.ApiUrl = string.Format("{0}/payment/gettypes", secupayGetTypes.ApiUrl);
            secupayGetTypes.JsonOut = dto.ToJsonString();

            // Anfrage vorab in DB speichern
            Context.SaveChanges();

            // Anfrage am Gateway synchron durchführen und Antwort speichern
            secupayGetTypes.JsonIn = RunWebRequest(secupayGetTypes.ApiUrl, secupayGetTypes.JsonOut);
            Context.SaveChanges();

            // Einzelne Wert in Objekt übernehmen
            var response = secupayGetTypes.JsonIn.FromJsonToObject<GetTypesResponseDtoRoot>();
            secupayGetTypes.ResponseStatus = response.Status;
            secupayGetTypes.ResponsePaymentTypes = String.Join(";", response.Data);

            // Antwort in DB sichern
            Context.SaveChanges();
        }

        /// <summary>
        ///     Führt eine Initalisierung am Gateway durch.
        ///     Kommuniaktion erfolgt im JSON Format
        /// </summary>
        private void RunPaymentInit(PaySecupayInit secupayInit)
        {
            // Die Initialisierung wird in ein Data Transport Objekte gewandelt, das als JSON seralisiert werden kann
            InitRequestDtoRoot dto = TDtoFactory.CreateInitRequestDtoRoot(secupayInit, Config);
            secupayInit.ApiUrl = string.Format("{0}/payment/init", secupayInit.ApiUrl);
            secupayInit.JsonOut = dto.ToJsonString();

            // Anfrage vorab in DB speichern
            Context.SaveChanges();

            // Anfrage am Gateway synchron durchführen und Antwort speichern
            secupayInit.JsonIn = RunWebRequest(secupayInit.ApiUrl, secupayInit.JsonOut);
            Context.SaveChanges();

            // Die JSON Antwort in ein Data Transport Objekt deserialisieren
            var response = secupayInit.JsonIn.FromJsonToObject<InitResponseDtoRoot>();

            // Einzelne Wert in Objekt übernehmen
            secupayInit.ResponseStatus = response.Status;
            secupayInit.ResponseIFrameUrl = response.Data.IFrameUrl;
            secupayInit.ResponseHash = response.Data.Hash;
            secupayInit.ResponseErrors = response.Errors;

            // Antwort in DB sichern
            Context.SaveChanges();
        }

        /// <summary>
        ///     Führt eine Statusanfrage am Gateway durch.
        ///     Kommuniaktion erfolgt im JSON Format
        /// </summary>
        private void RunPaymentStatus(PaySecupayStatus secupayStatus)
        {
            // Die Statusanfrage wird in ein Data Transport Objekte gewandelt, das als JSON seralisiert werden kann
            StatusRequestDtoRoot dto = TDtoFactory.CreateStatusRequestDtoRoot(secupayStatus);
            secupayStatus.ApiUrl = string.Format("{0}/payment/status", secupayStatus.ApiUrl);
            secupayStatus.JsonOut = dto.ToJsonString();

            // Anfrage vorab in DB speichern
            Context.SaveChanges();

            // Anfrage am Gateway synchron durchführen und Antwort speichern
            secupayStatus.JsonIn = RunWebRequest(secupayStatus.ApiUrl, secupayStatus.JsonOut);
            Context.SaveChanges();

            // Die JSON Antwort in ein Data Transport Objekt deserialisieren
            var response = secupayStatus.JsonIn.FromJsonToObject<StatusResponseDtoRoot>();

            // Einzelne Wert in Objekt übernehmen
            secupayStatus.ResponseHash = response.Data.Hash;
            secupayStatus.ResponsePaymentStatus = response.Data.PaymentStatus;
            secupayStatus.ResponseStatus = response.Data.Status;
            secupayStatus.ResponseCreated = response.Data.Created.FromJsonToDateTime();
            secupayStatus.ResponseDemo = response.Data.Demo;
            secupayStatus.ResponseTransId = response.Data.TransId;
            secupayStatus.ResponseAmount = response.Data.Amount;
            secupayStatus.ResponseOpt = response.Data.Opt;

            secupayStatus.Status = response.Status;
            secupayStatus.Errors = response.Errors;

            // Antwort in DB sichern
            Context.SaveChanges();
        }

        #endregion

        #region ### Public ###

        /// <summary>
        ///     Führt Abfrage der vorhandenen Zahlungsmethoden durch.
        /// </summary>
        public PaySecupayGetTypes GetPaymentTypes()
        {
            // Anfrage erzeugen und in DB sichern
            PaySecupayGetTypes paySecupayGetTypes = new PaySecupayGetTypes
            {
                ApiKey = Config.ApiKey,
                ApiUrl = Config.SecupayUrl
            }.SetNew(Config.Username);

            Context.PaySecupayGetTypes.Add(paySecupayGetTypes);
            Context.SaveChanges();

            // Anfrage am Gateway durchführen
            RunPaymentGetTypes(paySecupayGetTypes);

            return paySecupayGetTypes;
        }

        /// <summary>
        ///     Zahlung initialisieren
        /// </summary>
        public void InitPayment(PaySecupayInit secupayInit)
        {
            // Anfrage in DB sichern
            Context.PaySecupayInit.Add(secupayInit);
            Context.SaveChanges();

            // Anfrage am Gateway durchführen
            RunPaymentInit(secupayInit);
        }

        /// <summary>
        ///     Es wird eine Statusanfrage zu eine Transaktion am Gateway durchgeführt
        /// </summary>
        /// <param name="secupayStatus"></param>
        public void StatusPayment(PaySecupayStatus secupayStatus)
        {
            // Statusanfrage in DB sichern
            Context.PaySecupayStatus.Add(secupayStatus);
            Context.SaveChanges();

            RunPaymentStatus(secupayStatus);
        }

        /// <summary>
        ///     Eingehende Daten aus Push vom Gateway werden gesichert und geprüft.
        ///     Wenn eine passende Anfrage vorhanden ist, wird entsprechend bestätigt
        /// </summary>
        public PaySecupayPush ProcessPush(NameValueCollection form, string pushUrl, string referrer)
        {
            // Eingangsparamter werden als QueryString zusammengesetzt, um diese in der DB für Analysen zu speichern
            string q = String.Join("&", form.AllKeys.Select(a => a + "=" + HttpUtility.UrlEncode(form[a])).ToArray());
            PaySecupayPush secupayPush = new PaySecupayPush
            {
                PostIn = q,
                PushUrl = pushUrl,
                Referrer = referrer
            }.SetNew(Config.Username);

            try
            {
                // Zunächst den Eingang in der DB sichern
                Context.PaySecupayPush.Add(secupayPush);
                Context.SaveChanges();

                // Einzelne Paramter aus Formdaten extrahieren
                secupayPush.ApiKey = form["apikey"];
                secupayPush.Hash = form["hash"];
                secupayPush.StatusId = form["status_id"];
                secupayPush.StatusDescription = form["status_description"];
                long l;
                if (long.TryParse(form["changed"], out l))
                {
                    secupayPush.Changed = l;
                    secupayPush.ChangedDate = l.UnixTimeStampToDateTime();
                }
                secupayPush.PaymentStatus = form["payment_status"];
                secupayPush.Hint = form["hint"];

                // Zwischenstand in DB sichern
                Context.SaveChanges();

                // Prüfen, ob eine Anfrage zu diesem Hash vorhanden ist und Rückgabewerte setzten
                if (Context.PaySecupayInit.Any(o => o.ResponseHash == secupayPush.Hash))
                {
                    secupayPush.Ack = "Approved";
                    secupayPush.Error = null;
                }
                else
                {
                    secupayPush.Ack = "Disapproved";
                    secupayPush.Error = "Hash not found";
                }

                // Rückgabe in Url Format ermitteln
                if (secupayPush.Error == null)
                    secupayPush.PostOut = string.Format("ack={0}&{1}", secupayPush.Ack, q);
                else
                    secupayPush.PostOut = string.Format("ack={0}&error={1}&{2}", secupayPush.Ack,
                        HttpUtility.UrlEncode(secupayPush.Error), q);

                // Rückgabewerte in DB sichern
                Context.SaveChanges();

                return secupayPush;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Application", ex.Message, EventLogEntryType.Error);
                secupayPush.PostOut = string.Format("ack=Disapproved&{0}", q);
                return secupayPush;
            }
        }

        #endregion
    }
}