using System.Text.Json;
using System.Text.RegularExpressions;

namespace Viriplaca.Common.Extensions;

public static partial class StringExtensions
{
    public static bool IsNullOrWhiteSpace(this string? value)
    {
        return string.IsNullOrWhiteSpace(value);
    }

    public static string ToPascalCase(this string? value)
    {
        if (value is null)
        {
            return string.Empty;
        }

        return FirstLetterRegex().Replace(value, x => x.Value.ToUpper());
    }

    public static string ToCamelCase(this string? value)
    {
        if (value is null)
        {
            return string.Empty;
        }

        return JsonNamingPolicy.CamelCase.ConvertName(value);
    }

    [GeneratedRegex(@"\b\w")]
    private static partial Regex FirstLetterRegex();
}
