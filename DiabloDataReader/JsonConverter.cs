using System.Text.Encodings.Web;
using System.Text.Json;

namespace DiabloDataReader;

public class JsonConverter
{
    public string Serialize<T>(T source)
    => JsonSerializer.Serialize
    (
        source,
        new JsonSerializerOptions
        {
            Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            WriteIndented = true
        }
    );
}