using Confluent.Kafka;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Scores365.Infrastrucrure.KafkaExtensions.Serialization;

namespace Scores365.Infrastrucrure.KafkaExtensions
{
    public static class Extensions
    {
        public static void AddProducer<T>(this IServiceCollection serviceCollection, Action<ProducerConfig>? configure = null)
        {
            serviceCollection.TryAddSingleton<ISerializer<string>, ASCIIStringSerializer>();
            serviceCollection.TryAddSingleton<ISerializer<T>, DefaultJsonSerializer<T>>();

            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092, localhost:9093",
            };

            if (configure != null)
                configure(config);

            serviceCollection.AddSingleton(provider => 
            {
                return new ProducerBuilder<string, T>(config)
                .SetKeySerializer(provider.GetRequiredService<ISerializer<string>>())
                .SetValueSerializer(provider.GetRequiredService<ISerializer<T>>())
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
