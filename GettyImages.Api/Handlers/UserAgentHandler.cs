using System;
using System.Net.Http;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace GettyImages.Api.Handlers
{
    internal class UserAgentHandler : DelegatingHandler
    {
        private static readonly string UserAgentString;

        static UserAgentHandler()
        {
            UserAgentString = "GettyImagesApiSdk" +
                              Assembly.Load(new AssemblyName("GettyImages.Api"))
                                  .GetCustomAttribute<AssemblyInformationalVersionAttribute>()
                                  .InformationalVersion +
                              " (" + OsVersion() + Framework() + ")";
        }

        private static string OsVersion()
        {
            var os = string.Empty;

            try
            {
                os = typeof (Environment).GetTypeInfo().Assembly
                    .GetType("System.Environment")
                    .GetRuntimeProperty("OSVersion")
                    .GetValue(null).ToString();
            }
            catch
            {
            }

            return string.IsNullOrEmpty(os) ? os : os + "; ";
        }

        private static string Framework()
        {
            var frameworkVersion = ".NET";

            try
            {
                frameworkVersion = " " + typeof (Environment).GetTypeInfo().Assembly
                    .GetType("System.Environment").GetRuntimeProperty("Version").GetValue(null);
            }
            catch
            {
            }

            return (Type.GetType("Mono.Runtime") != null ? "Mono" : ".NET") + frameworkVersion;
        }

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
            CancellationToken cancellationToken)
        {
            request.Headers.Add("User-Agent", UserAgentString);
            return base.SendAsync(request, cancellationToken);
        }
    }
}