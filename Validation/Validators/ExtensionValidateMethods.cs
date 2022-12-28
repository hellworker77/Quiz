using Newtonsoft.Json;

namespace Validation.Validators;

public static class ExtensionValidateMethods
{
    public static bool ValidateJsonString<T>(this string json)
    {
        try
        {
            var list = JsonConvert.DeserializeObject<T>(json);
            return true;
        }
        catch (JsonException)
        {
            return false;
        }
    }
}