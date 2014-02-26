namespace pay.secupay
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Runtime.Serialization.Json;
    using System.Text;
    using Model.Dto;
    
    public static class TJson
    {
        public static string ToJsonString<T>(this T data) where T : IPaySecupayDto
        {
            byte[] json;
            using (MemoryStream ms = new MemoryStream())
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
                ser.WriteObject(ms, data);
                json = ms.ToArray();
                ms.Close();
            }
            string s = Encoding.UTF8.GetString(json, 0, json.Length);
            return s;
        }

        public static T FromJsonToObject<T>(this string json)
        {
            DataContractJsonSerializer deserializer = new DataContractJsonSerializer(typeof(T));
            using (MemoryStream stream = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                T result = (T)deserializer.ReadObject(stream);
                return result;
            }
        }

        public static DateTime? FromJsonToDateTime(this string data)
        {
            // 2014-02-04 14:10:59
            DateTime d;
            if (DateTime.TryParseExact(data, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out d))
            {
                return d;
            }
            return null;
        }

        public static DateTime UnixTimeStampToDateTime(this long unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
    }
}
