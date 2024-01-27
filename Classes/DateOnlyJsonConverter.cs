using Newtonsoft.Json;

namespace MovieMateAPI.Classes
{
    //To convert DateTime of release date in TMDB to yyyy-MM-dd format
    public class DateOnlyJsonConverter : JsonConverter<DateTime>
    {
        public override void WriteJson(JsonWriter writer, DateTime value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString("yyyy-MM-dd"));
        }

        public override DateTime ReadJson(JsonReader reader, Type objectType, DateTime existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            return DateTime.Parse((string)reader.Value);
        }
    }
}
