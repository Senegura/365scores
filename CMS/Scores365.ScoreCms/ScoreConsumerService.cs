using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Scores365.Events;
using static Confluent.Kafka.ConfigPropertyNames;

namespace Scores365.ScoreCms
{
    internal class ScoreConsumerService(IConsumer<string, BaseEvent> Consumer) : BackgroundService
    {
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Consumer.Subscribe(
                ["Scores365.Events.BaseBallScoreEvent",
                "Scores365.Events.FootballScoreEvent",
                "Scores365.Events.SoccerScoreEvent",
                ]);

            while (!stoppingToken.IsCancellationRequested)
            {
                ProcessKafkaMessage(stoppingToken);

                await Task.Delay(TimeSpan.FromMilliseconds(1), stoppingToken);
            }

            Consumer.Close();
        }

        public void ProcessKafkaMessage(CancellationToken stoppingToken)
        {
            try
            {
                var consumeResult = Consumer.Consume(stoppingToken);
                var message = consumeResult.Message.Value;
            }
            catch (Exception ex)
            {
            }
        }
    }
}
