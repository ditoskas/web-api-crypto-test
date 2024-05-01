using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Utilities
{
    public static class Serializer
    {
        private static readonly JsonSerializerSettings SnakeCaseSettings = new JsonSerializerSettings
        {
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new SnakeCaseNamingStrategy()
            },
            Error = (se, ev) => { ev.ErrorContext.Handled = true; }
        };

        public static T? DeserializeObjectSnakeCase<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value, SnakeCaseSettings);
        }
    }
}
