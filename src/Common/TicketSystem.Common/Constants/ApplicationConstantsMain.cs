using System.Text.Json;

namespace TicketSystem.Common.Constants;

public static partial class ApplicationConstants
{
    public const short PagedListMaxPageSize = 500;

    public static JsonSerializerOptions JsonSerializerOptions = new()
    {
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };
}