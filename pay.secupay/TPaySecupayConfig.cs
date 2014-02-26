using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace pay.secupay
{
    public class TPaySecupayConfig
    {
        #region ### Properties ###

        public string Username { get; set; }
        public string ConnectionString { get; set; }

        public string Shop { get; set; }
        public string ApiKey { get; set; }
        public string ApiVersion { get; set; }

        public int Demo { get; set; }

        public string SecupayUrl { get; set; }

        public string UrlSuccess { get; set; }
        public string UrlFailure { get; set; }
        public string UrlPush { get; set; }

        public bool SendDeliveryAddress { get; set; }

        #endregion

        #region ### Ctor ###

        public TPaySecupayConfig()
        {
            SecupayUrl = "https://api-dist.secupay-ag.de";
            Username = "Secupay.NET";
        }

        #endregion

        #region ### Private ###

        private static TPaySecupayConfig Read(string fullFilePath)
        {
            var reader =
                new XmlSerializer(typeof (TPaySecupayConfig));
            TPaySecupayConfig config;
            using (var file = new StreamReader(fullFilePath))
            {
                config = (TPaySecupayConfig) reader.Deserialize(file);
            }

            return config;
        }

        #endregion

        #region ### Methods ###

        public void WriteToFile(string fullFilePath)
        {
            var x = new XmlSerializer(GetType());
            using (var file = new StreamWriter(fullFilePath))
            {
                x.Serialize(file, this);
            }
        }

        public static TPaySecupayConfig LoadFromFile(string fullFileName = "")
        {
            if (String.IsNullOrWhiteSpace(fullFileName))
            {
                string baseDir = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
                fullFileName = Path.Combine(baseDir, "secupay.xml");
            }

            if (File.Exists(fullFileName))
                return Read(fullFileName);
            throw new FileNotFoundException(fullFileName);
        }

        #endregion
    }
}