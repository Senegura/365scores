using Confluent.Kafka;
using System.Text;
using System.Text.Json;

namespace Scores365.Infrastrucrure.KafkaExtensions.Serialization
{
    public class DefaultJsonDeserializer<T> : IDeserializer<T>
    {
        public T Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<T>(Encoding.UTF8.GetString(data));
        }
    }
}
