using System.Diagnostics;
using Newtonsoft.Json;

namespace WHODataViz.GHOAccessLib
{
    public static class JsonHelper
    {
        public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null) where T : new()
        {
            var response = new T();

            try
            {
                if (!string.IsNullOrEmpty(data))
                {
                    response = jsonSettings == null ? JsonConvert.DeserializeObject<T>(data) : JsonConvert.DeserializeObject<T>(data, jsonSettings);
                }
            }
            catch (JsonReaderException e)
            {
                Debug.WriteLine(e.ToString());

            }

            return response;
        }
    }
}