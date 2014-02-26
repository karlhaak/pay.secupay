namespace pay.secupay.test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestConfig
    {
        [TestMethod]
        public void TestConfigWriteRead()
        {
            // neue Config Datei erzeugen
            TPaySecupayConfig config = new TPaySecupayConfig
            {
                ApiKey = "133cb4492ced4f3f95a0b8e2823e301d", 
                ConnectionString = "data source=localhost;initial catalog=Secupay;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework",
                UrlSuccess = "http://www.ihre-shop-domain.de/success.aspx",
                UrlFailure = "http://www.ihre-shop-domain.de/failure.aspx",
                UrlPush = "http://www.ihre-shop-domain.de/push.aspx",
                Demo = 1,
                SendDeliveryAddress = true,
                Username = "pay.secupay"
            };

            // Datei speichern 
            config.WriteToFile("secupay.xml");

            // Config Datei mit Dateinamen einlesen
            TPaySecupayConfig config2 = TPaySecupayConfig.LoadFromFile("secupay.xml");
            Assert.IsNotNull(config2);

            // Config Datei mit Default Dateinamen einlesen
            TPaySecupayConfig config3 = TPaySecupayConfig.LoadFromFile();
            Assert.IsNotNull(config3);
        }
    }
}
