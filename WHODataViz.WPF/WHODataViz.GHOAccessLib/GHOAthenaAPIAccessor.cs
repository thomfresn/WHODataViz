using System.IO;
using System.Net;

namespace WHODataViz.GHOAccessLib
{
    public class GHOAthenaAPIAccessor
    {
        public Facts GetFacts(string code)
        {
            string url = $"http://apps.who.int/gho/athena/api/GHO/{code}.json?profile=simple";
            return GetResponse<Facts>(url);
        }
        
        public Codes GetCodes()
        {
            string url = @"http://apps.who.int/gho/athena/api/GHO.json";
            return GetResponse<Codes>(url);
        }

        private T GetResponse<T>(string url) where T : new()
        {
            WebRequest request = WebRequest.Create(url);
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    if (dataStream == null)
                    {
                        return new T();
                    }
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        return JsonHelper.ToClass<T>(responseFromServer);
                    }
                }
            }
        }
    }
}