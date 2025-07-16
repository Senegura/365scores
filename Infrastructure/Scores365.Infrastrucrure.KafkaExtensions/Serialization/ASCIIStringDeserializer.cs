using Confluent.Kafka;
using System.Text;

namespace Scores365.Infrastrucrure.KafkaExtensions.Serialization
{
    public class ASCIIStringDeserializer : IDeserializer<string>
    {
        public string Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return Encoding.ASCII.GetString(data);
        }
    }
}
