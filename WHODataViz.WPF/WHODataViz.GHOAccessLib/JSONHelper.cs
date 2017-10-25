using Newtonsoft.Json;

namespace WHODataViz.GHOAccessLib
{
    public static class JsonHelper
    {
        public static T ToClass<T>(string data, JsonSerializerSettings jsonSettings = null)
        {
            var response = default(T);

            if (!string.IsNullOrEmpty(data))
                response = jsonSettings == null
                    ? JsonConvert.DeserializeObject<T>(data)
                    : JsonConvert.DeserializeObject<T>(data, jsonSettings);

            return response;
        }
    }
}