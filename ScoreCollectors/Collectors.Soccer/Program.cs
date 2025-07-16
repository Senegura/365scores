using Collectors.Soccer.Services.Abstract;
using Collectors.Soccer.Services.MessageBus;
using Collectors.Soccer.Services.Soccer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Scores365.Infrastrucrure.Events;

namespace Collectors.Soccer
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
           .ConfigureServices(services =>
           {
               services
               .AddSingleton<IScorePublisher, KafkaScorePublisher>()
               .AddSingleton<ISoccerScoreCollector, SoccerScoreCollector>();
           })
           .ConfigureLogging(logging =>
           {
               logging.ClearProviders();
               logging.AddConsole();
           })
           .Build();

            var scoreCollector = host.Services.GetRequiredService<ISoccerScoreCollector>();
            var score = scoreCollector.CollectScore();

            var publisher = host.Services.GetRequiredService<IScorePublisher>();

            // TODO: use automapper or Mapperly
            publisher.Publish(new SoccerScoreEvent() { CompetitionName = score.CompetitionName, EventTime = score.EventTime, Teams = score.Teams });
        }
    }
}
