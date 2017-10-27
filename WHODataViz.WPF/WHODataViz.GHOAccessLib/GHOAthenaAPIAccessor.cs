using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace WHODataViz.GHOAccessLib
{
    public class GHOAthenaAPIAccessor
    {
        public async Task<Facts> GetFactsAsync(string code)
        {
            string url = $"http://apps.who.int/gho/athena/api/GHO/{code}.json?profile=simple";
            return await GetResponse<Facts>(url);
        }
        
        public async Task<Codes> GetCodesAsync()
        {
            string url = @"http://apps.who.int/gho/athena/api/GHO.json";
            return await GetResponse<Codes>(url);
        }

        private async Task<T> GetResponse<T>(string url) where T : new()
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse responseAsync = await request.GetResponseAsync();
            using (WebResponse webResponse = responseAsync)
            {
                using (Stream dataStream = webResponse.GetResponseStream())
                {
                    if (dataStream == null)
                    {
                        return new T();
                    }
                    using (StreamReader reader = new StreamReader(dataStream))
                    {
                        string responseFromServer = await reader.ReadToEndAsync();
                        return JsonHelper.ToClass<T>(responseFromServer);
                    }
                }
            }
        }
    }
}