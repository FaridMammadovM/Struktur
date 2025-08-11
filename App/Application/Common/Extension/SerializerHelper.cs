using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Application.Common.Extension
{
    public static class SerializerHelper
    {
        public static string Serialize(object objectToCache)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.SerializeObject(objectToCache, settings);
        }

        public static T Deserialize<T>(string redisObject)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };
            return JsonConvert.DeserializeObject<T>(redisObject, settings);
        }
    }
}
