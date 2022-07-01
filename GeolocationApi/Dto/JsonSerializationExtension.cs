using Newtonsoft.Json;

namespace GeolocationApi.Dto
{
    public static class JsonSerializationExtension
    {
        public static T FromJson<T>(this string json)
            where T : class
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson<T>(this T details)
            where T : class
        {
            if (details == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(details);
        }
    }
}