namespace pay.secupay.test
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class TestConfig
    {
        [TestMethod]
        public void TestConfigWriteRead()
        {
            TPaySecupayConfig config = new TPaySecupayConfig
            {
                ApiKey = "133cb4492ced4f3f95a0b8e2823e301d", 
                ConnectionString = "data source=localhost;initial catalog=Secupay;integrated security=True;multipleactiveresultsets=True;application name=EntityFramework",
                UrlSuccess = "http://www.shop.de/success.aspx",
                UrlFailure = "http://www.shop.de/failure.aspx",
                UrlPush = "http://www.shop.de/push.aspx",
                Demo = 1,
                SendDeliveryAddress = true,
                Username = "pay.secupay"
            };

            config.WriteToFile("secupay.xml");

            TPaySecupayConfig config2 = TPaySecupayConfig.LoadFromFile("secupay.xml");
            Assert.IsNotNull(config2);

            TPaySecupayConfig config3 = TPaySecupayConfig.LoadFromFile();
            Assert.IsNotNull(config3);
        }
    }
}
