using System.Text;
using System.Text.Json;

namespace TicketSystem.Common.Helpers;

public static class JwtHelpers
{
    public static void DecodeJwt(string token)
    {
        var parts = token.Split('.');

        if (parts.Length != 3)
        {
            Console.WriteLine("Geçersiz JWT formatı.");
            return;
        }

        string header = parts[0];
        string payload = parts[1];
        // string signature = parts[2]; // Gerekirse kullanılır

        string decodedHeader = Base64UrlDecode(header);
        string decodedPayload = Base64UrlDecode(payload);

        Console.WriteLine("Header:");
        Console.WriteLine(JsonPrettify(decodedHeader));
        Console.WriteLine("Payload:");
        Console.WriteLine(JsonPrettify(decodedPayload));
    }

    private static string Base64UrlDecode(string input)
    {
        string output = input.Replace('-', '+').Replace('_', '/');
        switch (output.Length % 4)
        {
            case 2: output += "=="; break;
            case 3: output += "="; break;
        }
        var converted = Convert.FromBase64String(output);
        return Encoding.UTF8.GetString(converted);
    }

    private static string JsonPrettify(string json)
    {
        using (var jdoc = JsonDocument.Parse(json))
        {
            return JsonSerializer.Serialize(jdoc, new JsonSerializerOptions { WriteIndented = true });
        }
    }
}