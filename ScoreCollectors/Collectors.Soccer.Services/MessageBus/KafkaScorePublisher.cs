using Collectors.Soccer.Services.Abstract;
using Confluent.Kafka;
using Scores365.Events;
using Scores365.Infrastrucrure.KafkaExtensions;

namespace Collectors.Soccer.Services.MessageBus
{
    public class KafkaScorePublisher(IProducer<string, BaseEvent> Producer) : IScorePublisher
    {
        public void Publish(BaseEvent @event)
        {
            var topicName = @event.GetKafkaTopicName();
            var message = new Message<string, BaseEvent>() { Key = @event.EventTime.ToString(), Value = @event };
            Producer.Produce(topicName, message);
        }
    }
}
