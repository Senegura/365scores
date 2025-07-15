using Confluent.Kafka;
using Scores365.Infrastructure.Tests.Models;

namespace Scores365.Infrastructure.Tests
{
    public class ProducerTests
    {
        [Fact]
        public void TestProducer()
        {
            var config = new ProducerConfig
            {
                ClientId = "producer-app",
                BootstrapServers = "localhost:9092, localhost:9093",
            };

            using (var producer = new ProducerBuilder<string, Fruit>(config)
               .SetKeySerializer(new Serialization.JsonSerializer<string>())
               .SetValueSerializer(new Serialization.JsonSerializer<Fruit>())
               .Build())
            {
                producer.Produce("fruits", new Message<string, Fruit> { Key = "1", Value = new Fruit { Id = 1, Name = "Orange"} });
            }
        }
    }
}