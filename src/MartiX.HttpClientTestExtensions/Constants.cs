using System.Text.Json;

namespace MartiX.HttpClientTestExtensions;

public static class Constants
{
  public static JsonSerializerOptions DefaultJsonOptions = new JsonSerializerOptions
  {
    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
  };
}
