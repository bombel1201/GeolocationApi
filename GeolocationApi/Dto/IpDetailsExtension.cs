using Newtonsoft.Json;

namespace GeolocationApi.Dto
{
    public static class IpDetailsExtension
    {
        public static IpDetails ToDetails(this string json)
        {
            if (string.IsNullOrWhiteSpace(json))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<IpDetails>(json);
        }

        public static string ToJson(this IpDetails details)
        {
            if (details == null)
            {
                return null;
            }

            return JsonConvert.SerializeObject(details);
        }
    }
}