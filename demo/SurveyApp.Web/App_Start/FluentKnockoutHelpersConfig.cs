using System.Web.Http;
using FluentKnockoutHelpers.Core;
using FluentKnockoutHelpers.Core.TypeMetadata;
using Newtonsoft.Json;

namespace SurveyApp.Web
{
    public static class FluentKnockoutHelpersConfig
    {
        public static void Configure()
        {
            GlobalSettings.JsonSerializer = new JsonDotNetSerializer();
            TypeMetadataHelper.BuildFor<ApiController>();
        }
    }

    /// <summary>
    /// Use JSON.NET for serialization for FluentKnockoutHelpers
    /// </summary>
    public class JsonDotNetSerializer : IJsonSerializer
    {
        public string ToJsonString(object toSerialize)
        {
            return JsonConvert.SerializeObject(toSerialize);
        }
    }
}