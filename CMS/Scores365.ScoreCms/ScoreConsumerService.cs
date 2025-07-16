using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Scores365.Events;

namespace Scores365.ScoreCms
{
    internal class ScoreConsumerService(IConsumer<string, BaseEvent> Consumer) : BackgroundService
    {
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Consumer.Subscribe();
        }
    }
}
