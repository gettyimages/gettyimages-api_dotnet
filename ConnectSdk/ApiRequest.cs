using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace GettyImages.Connect
{
    public class ApiRequest
    {
        private const string SpaceString = " ";
        protected string BaseUrl;
        protected Credentials Credentials;
        protected string Method;
        protected string Path;
        protected IDictionary<string, object> QueryParameters;

        public ApiRequest()
        {
            QueryParameters = new Dictionary<string, object>();
        }

        public virtual Task<dynamic> ExecuteAsync()
        {
            var helper = new WebHelper(Credentials, BaseUrl);
            switch (Method)
            {
                case "GET":
                    return helper.Get(BuildQuery(QueryParameters), Path);
                case "POST":
                    return helper.PostQuery(BuildQuery(QueryParameters), Path);
                default:
                    throw new SdkException("No appropriate HTTP method found for this request.");
            }
        }

        private static IEnumerable<KeyValuePair<string, string>> BuildQuery(
            IEnumerable<KeyValuePair<string, object>> queryParameters)
        {
            var keyValuePairs = queryParameters as KeyValuePair<string, object>[] ??
                                queryParameters.ToArray();

            return keyValuePairs.Where(v => v.Value is string || v.Value is bool || v.Value is int)
                .Select(
                    d =>
                        new KeyValuePair<string, string>(d.Key,
                            d.Value.ToString().ToLowerInvariant()))
                .Union(keyValuePairs
                    .Where(v => v.Value is Enum)
                    .Select(
                        d =>
                            new KeyValuePair<string, string>(d.Key,
                                BuildEnumString((Enum) d.Value))))
                .Union(keyValuePairs
                    .Where(v => v.Value is IEnumerable<string>)
                    .Select(
                        d => new KeyValuePair<string, string>(d.Key, string.Join(",", (IEnumerable<string>) d.Value))))
                .AsEnumerable();
        }

        private static string BuildEnumString(Enum value)
        {
            return
                value.GetType().GetTypeInfo().CustomAttributes.Where(a => a.AttributeType == typeof(FlagsAttribute)) !=
                null
                    ? string.Join(",", GetFlags(value).Select(GetEnumDescription).ToArray())
                    : value.ToString().ToLowerInvariant().Replace(SpaceString, string.Empty);
        }

        private static string GetEnumDescription(Enum value)
        {
            var fi = value.GetType().GetRuntimeFields().FirstOrDefault(f => f.Name == value.ToString());
            if (fi != null)
            {
                var attributes =
                    (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (attributes != null && attributes.Length > 0) return attributes[0].Description;
            }

            return value.ToString();
        }

        private static IEnumerable<Enum> GetFlags(Enum input)
        {
            return Enum.GetValues(input.GetType()).Cast<Enum>().Where(input.HasFlag).Where(v => Convert.ToInt64(v) != 0);
        }
    }
}