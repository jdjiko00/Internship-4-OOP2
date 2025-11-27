using System.Text.Json.Serialization;

namespace Internship_4_OOP2.Doimain.Common.Validation
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum ValidationSeverity
    {
        Info,
        Warning,
        Error
    }
}
