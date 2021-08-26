using Framework.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Microsoft.Net.Http.Headers;
using System.Threading.Tasks;

namespace ChatBotMVC.Infrastructure.Extensions
{
    public static class HttpRequestExtensions
    {

        /// <summary>
        /// get header based on supplied key
        /// </summary>
        /// <param name="request"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetHeaderRequest(this HttpRequest request, string key)
        {
            return request.Headers.FirstOrDefault(x => x.Key == key).Value.FirstOrDefault();
        }

        /// <summary>
        /// get specific language sent by custom header language
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static string GetLanguageCultures(this HttpRequest request)
        {
            var requestedLanguages = request.Headers["Language"];
            if (StringValues.IsNullOrEmpty(requestedLanguages) || requestedLanguages.Count == 0)
            {   
                return null;
            }

            var preferredCultures = requestedLanguages.ToString().Split(',')
            // Parse the header values
            .Select(s => new StringSegment(s))
            .Select(StringWithQualityHeaderValue.Parse)
            // Ignore the "any language" rule
            .Where(sv => sv.Value != "*")
            // Remove duplicate rules with a lower value
            .GroupBy(sv => sv.Value).Select(svg => svg.OrderByDescending(sv => sv.Quality.GetValueOrDefault(1)).First())
            // Sort by preference level
            .OrderByDescending(sv => sv.Quality.GetValueOrDefault(1))
            .Select(sv => new CultureInfo(sv.Value.ToString()))
            .ToList();

            return StringConverterExtension.ToSafeString(preferredCultures.FirstOrDefault()).ToLower();
        }

        /// <summary>
        /// Get list of accepted language send by default header Accept-Language
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static IList<CultureInfo> GetListAcceptedLanguageCultures(this HttpRequest request)
        {
            var requestedLanguages = request.Headers["Accept-Language"];
            if (StringValues.IsNullOrEmpty(requestedLanguages) || requestedLanguages.Count == 0)
            {
                return null;
            }

            var preferredCultures = requestedLanguages.ToString().Split(',')
            // Parse the header values
            .Select(s => new StringSegment(s))
            .Select(StringWithQualityHeaderValue.Parse)
            // Ignore the "any language" rule
            .Where(sv => sv.Value != "*")
            // Remove duplicate rules with a lower value
            .GroupBy(sv => sv.Value).Select(svg => svg.OrderByDescending(sv => sv.Quality.GetValueOrDefault(1)).First())
            // Sort by preference level
            .OrderByDescending(sv => sv.Quality.GetValueOrDefault(1))
            .Select(sv => new CultureInfo(sv.Value.ToString()))
            .ToList();

            return preferredCultures;
        }

    }
}
