using Confluent.Kafka;
using System.Text;
using System.Text.Json;

namespace Scores365.Infrastructure.Serialization
{
    public class JsonSerializer<T> : ISerializer<T>
    {
        public byte[] Serialize(T data, SerializationContext context)
        {
            string json = JsonSerializer.Serialize(data);
            return Encoding.UTF8.GetBytes(json);
        }
    }
}
