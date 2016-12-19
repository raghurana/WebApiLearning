using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace Api.Classic
{
    public static class HttpRequestMessageExtensions
    {
        public static int GetRequestedApiVersion(this HttpRequestMessage request, int defaultVersion = 1)
        {
            IEnumerable<string> headerValues;
            if (!request.Headers.TryGetValues("x-api-version", out headerValues))
                return defaultVersion;

            if (headerValues == null)
                return defaultVersion;

            var valuesArray = headerValues.ToArray();
            if (!valuesArray.Any())
                return defaultVersion;

            int requestedVersion;
            return
                Int32.TryParse(valuesArray.FirstOrDefault(), out requestedVersion)
                    ? requestedVersion
                    : defaultVersion;
        }
    }
}