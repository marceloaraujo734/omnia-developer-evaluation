using System.Text.Json;

namespace Ambev.DeveloperEvaluation.Application.Extensions;

public static class JsonExtension
{
    private static readonly JsonSerializerOptions Options = new() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

    public static string ToJson<T>(this T @object) where T : class
        => JsonSerializer.Serialize(@object, Options);
}
