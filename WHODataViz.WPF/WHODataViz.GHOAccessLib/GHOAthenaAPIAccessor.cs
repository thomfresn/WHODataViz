using System.IO;
using System.Net;

namespace WHODataViz.GHOAccessLib
{
    public class GHOAthenaAPIAccessor
    {
        public Facts GetFacts(string url)
        {
            WebRequest request = WebRequest.Create(url);
            using (WebResponse webResponse = request.GetResponse())
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    if (dataStream == null)
                    {
                        return new Facts();
                    }
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = reader.ReadToEnd();
                        return JsonHelper.ToClass<Facts>(responseFromServer);
                    }
                }
            }
        }
    }
}