using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace WorkVitCenter.Core.Utilities.ExtensionMethods
{
    public static class JsonExtensions
    {
        public static string ToJson(this object target)
        {
            return JsonConvert.SerializeObject(target, Newtonsoft.Json.Formatting.None, new IsoDateTimeConverter() { DateTimeFormat = "yyyy-MM-dd HH:mm:ss" });
        }

        public static T FromJson<T>(this string target)
        {
            return JsonConvert.DeserializeObject<T>(target);
        }

    }
}