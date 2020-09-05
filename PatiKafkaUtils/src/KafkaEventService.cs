using Confluent.Kafka;
using Pati.Infrastructure;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Pati.KafkaUtils
{
    /// <summary>
    /// Class that implements the IEventService for kafka.
    /// </summary>
    public class KafkaEventService: IEventService
    {
        private readonly string _connectionStr;

        public KafkaEventService(string connectionStr)
        {
            _connectionStr = connectionStr;
        }

        public async Task SendEventAsync<T>(string topic, string eventKey, T eventInstance)
        {
            var config = new ProducerConfig
            {
                BootstrapServers = _connectionStr,
                Acks = Acks.Leader,
                MessageTimeoutMs = 1000
            };

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var result = await producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = eventKey,
                    Value = JsonConvert.SerializeObject(eventInstance)
                });
            }
        }
    }
}
