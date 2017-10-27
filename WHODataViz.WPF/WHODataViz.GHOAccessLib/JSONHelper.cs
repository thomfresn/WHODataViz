using Newtonsoft.Json;
using Serilog;

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
                Log.Logger.Error(e, "Failed to deserialize string {data} into object of type {Type}", data, typeof(T));
            }

            return response;
        }
    }
}