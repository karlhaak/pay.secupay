namespace pay.secupay.test
{
    public class TestBase
    {
        protected const string ConfigFileName = "secupay.xml";

        protected TestBase()
        {
            // HACK: Copies EntityFramework.SqlServer.dll to Test Dir
            var instance = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

    }
}
