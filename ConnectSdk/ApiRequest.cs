using System;
using System.Collections.Generic;
using System.Linq;
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
                                d.Value.ToString().ToLowerInvariant().Replace(SpaceString, string.Empty))))
                .Union(keyValuePairs
                    .Where(v => v.Value is IEnumerable<string>)
                    .Select(
                        d => new KeyValuePair<string, string>(d.Key, string.Join(",", (IEnumerable<string>) d.Value))))
                .AsEnumerable();
        }
    }
}