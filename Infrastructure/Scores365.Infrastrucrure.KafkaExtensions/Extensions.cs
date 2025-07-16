using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scores365.Infrastrucrure.KafkaExtensions.Serialization;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Scores365.Infrastrucrure.KafkaExtensions
{
    public static class Extensions
    {
        public static IServiceCollection AddProducer<T>(this IServiceCollection serviceCollection, Action<ProducerConfig>? configure = null)
        {
            serviceCollection.TryAddSingleton<ISerializer<string>, ASCIIStringSerializer>(); // It's fine to have asci, no need Utf8 for headers
            serviceCollection.TryAddSingleton<ISerializer<T>, DefaultJsonSerializer<T>>();

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092, localhost:9093",
            };

            if (configure != null)
                configure(config);

            return serviceCollection.AddSingleton(provider => 
            {
                return new ProducerBuilder<string, T>(config)
                .SetKeySerializer(provider.GetRequiredService<ISerializer<string>>())
                .SetValueSerializer(provider.GetRequiredService<ISerializer<T>>())
                .Build();
            });
        }

        public static IServiceCollection AddConsumer<T>(this IServiceCollection serviceCollection, Action<ConsumerConfig>? configure = null)
        {
            serviceCollection.TryAddSingleton<IDeserializer<string>, ASCIIStringDeserializer>(); // It's fine to have asci, no need Utf8 for headers
            serviceCollection.TryAddSingleton<IDeserializer<T>, DefaultJsonDeserializer<T>>();

            var config = new ConsumerConfig
            {
                BootstrapServers = "localhost:9092, localhost:9093",
            };

            if (configure != null)
                configure(config);

            return serviceCollection.AddSingleton(provider =>
            {
                return new ConsumerBuilder<string, T>(config)
                .SetKeyDeserializer(provider.GetRequiredService<IDeserializer<string>>())
                .SetValueDeserializer(provider.GetRequiredService<IDeserializer<T>>())
                .Build();
            });
        }

        public static string GetKafkaTopicName(this object obj)
        {
            if (obj == null)
                throw new NullReferenceException("Type can't be null for GetKafkaTopicName");

            return obj.GetType().FullName;
        }
    }
}
