using System.Text.Json;

namespace Ambev.DeveloperEvaluation.WebApi.Extension;

public static class JsonExtension
{
    private static readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    internal static string ToJson<T>(this T @object) where T : class
        => JsonSerializer.Serialize(@object, Options);
}
