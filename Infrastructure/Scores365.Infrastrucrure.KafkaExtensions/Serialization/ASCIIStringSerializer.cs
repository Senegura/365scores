using Confluent.Kafka;
using System.Text;

namespace Scores365.Infrastrucrure.KafkaExtensions.Serialization
{
    public class ASCIIStringSerializer : ISerializer<string>
    {
        public byte[] Serialize(string data, SerializationContext context)
        {
            // For key serializer we don't need to use UTF8, ASCII fine since we don't want non English keys
            return Encoding.ASCII.GetBytes(data);
        }
    }
}
