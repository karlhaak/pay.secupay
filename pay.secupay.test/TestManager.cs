namespace pay.secupay.test
{
    using System.Collections.Specialized;
    using System.Data.Entity.Infrastructure;
    using System.Diagnostics;
    using System.IO;
    using System.Web;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using pay.secupay.Model;

    [TestClass]
    public class TestManager : TestBase
    {
        [TestMethod]
        public void TestManagerGetTypes()
        {
            TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(ConfigFileName);

            var man = new TPaySecupayManager(config);
            PaySecupayGetTypes ret = man.GetPaymentTypes();
            Assert.AreEqual(ret.ResponseStatus, "ok");
        }

        [TestMethod]
        public void TestManagerInit()
        {
// config einladen
TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(ConfigFileName);

// Über Factory paySecupayInit Objekt erzeugen
PaySecupayInit secupayInit = new TPayFactory(config).CreateSecupayInit(1.23m);

// Daten aus Verkauf übertragen
secupayInit.Firstname = "Karl";
secupayInit.Lastname = "Mustermann";
secupayInit.Langauge = "DE";
secupayInit.Street = "Hauptstrasse";
secupayInit.Housenumber = "12";
secupayInit.Zip = "50000";
secupayInit.City = "Köln";
secupayInit.Telephone = "000-111222555";
secupayInit.Email = "";
secupayInit.PaymentAction = EnumPaymentAction.sale.ToString();
secupayInit.PaymentType = EnumPaymentType.creditcard.ToString();


// Inhalt des Warenkorbs anfügen
secupayInit.Basket.Add(new PaySecupayBasket
{
    Name = "Item1",
    ArticleNumber = "01-1111",
    Ean = "11111111111111111",
    Model = "Model",
    Price = "1.23",
    Quantity = "1",
    Tax = "19",
    Total = "100",
}.SetNew(config.Username));

// Lieferadresse übergeben
secupayInit.DeliveryAddress = new PaySecupayDeliveryAddress
{
    Firstname = secupayInit.Firstname,
    Lastname = secupayInit.Lastname,
    Company = secupayInit.Company,
    Street = secupayInit.Street,
    Housenumber = secupayInit.Housenumber,
    Zip = secupayInit.Zip,
    City = secupayInit.City,
    Country = secupayInit.Country
}.SetNew(config.Username);

// Payment beim Gateway anfordern --> Hash und IFrame Url werden geliefert
var man = new TPaySecupayManager(config);
man.InitPayment(secupayInit);

Process.Start(secupayInit.ResponseIFrameUrl);
        }

        [TestMethod]
        public void TestManagerStatus()
        {
            TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(ConfigFileName);

            // TODO: insert hashcode here
            PaySecupayStatus secupayStatus = new TPayFactory(config).CreateSecupayStatus("hashcode"); 
            var man = new TPaySecupayManager(config);
            man.StatusPayment(secupayStatus);
        }

        [TestMethod]
        public void TestManagerPush()
        {
            TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(ConfigFileName);

            var man = new TPaySecupayManager(config);

            // Der zu testenden String aus der Push Antwort vom Gateway
            const string q =
                @"hash=hhhhhhh&status_id=6&status_description=abgeschlossen&changed=1391605747&payment_status=accepted&apikey=133cb4492ced4f3f95a0b8e2823e301d&hint=";

            // Url Parameter werden in Name Value Collection gewandelt
            NameValueCollection form = HttpUtility.ParseQueryString(q);

            // Beispiel für eine Einbindung im ASHX Handler. Die Formulardatean werden mit der Seite und dem Referrer übergeben.
            man.ProcessPush(form, "/pay.secupay.web/push.ashx", "https://api-dist.secupay-ag.de/");
        }

        [TestMethod]
        public void TestCreateDb()
        {
            TPaySecupayConfig config = TPaySecupayConfig.LoadFromFile(ConfigFileName);

            var context = new PaySecupayContext(config.ConnectionString, config.Username);
            string dbCreationScript = ((IObjectContextAdapter) context).ObjectContext.CreateDatabaseScript();
            File.WriteAllText("secupay-db-create.sql", dbCreationScript);
            Process.Start("secupay-db-create.sql");
        }
    }
}