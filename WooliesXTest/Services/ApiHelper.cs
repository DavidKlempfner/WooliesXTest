using System.IO;
using System.Net;
using WooliesXTest.Abstract;

namespace WooliesXTest.Services
{
    public class ApiHelper : IApiHelper
    {
        public string GetJsonResponseString(string endointUrl)
        {
            WebRequest request = WebRequest.Create(endointUrl);
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                using (Stream dataStream = response.GetResponseStream())
                {
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string jsonResponseString = reader.ReadToEnd();
                        return jsonResponseString;
                    }
                }
            }
        }
    }
}