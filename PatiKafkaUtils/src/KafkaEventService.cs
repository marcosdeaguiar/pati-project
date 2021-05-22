using Confluent.Kafka;
using Pati.Infrastructure;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Pati.KafkaUtils.Option;
using Microsoft.Extensions.Options;

namespace Pati.KafkaUtils
{
    /// <summary>
    /// Class that implements the IEventService for kafka.
    /// </summary>
    public class KafkaEventService: IEventService
    {
        private readonly KafkaSettings _kafkaSettings;

        public KafkaEventService(IOptions<KafkaSettings> kafkaSettings)
        {
            _kafkaSettings = kafkaSettings.Value;
        }

        private ProducerConfig GetProducerConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = _kafkaSettings.ConnectionString,
                Acks = Acks.Leader,
                MessageTimeoutMs = _kafkaSettings.MessageTimeoutMs
            };
        }

        public async Task SendEventAsync<T>(string topic, string eventKey, T eventInstance)
        {
            var config = GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var result = await producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = eventKey,
                    Value = JsonConvert.SerializeObject(eventInstance)
                });
            }
        }

        public async Task SendEventAsync<K,T>(string topic, K eventKey, T eventInstance)
        {
            var config = GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                var result = await producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = JsonConvert.SerializeObject(eventKey),
                    Value = JsonConvert.SerializeObject(eventInstance)
                });
            }
        }

        public void SendEvent<T>(string topic, string eventKey, T eventInstance)
        {
            var config = GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                Task res = producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = eventKey,
                    Value = JsonConvert.SerializeObject(eventInstance)
                });

                Task.WaitAll(res);
            }
        }

        public void SendEvent<K, T>(string topic, K eventKey, T eventInstance)
        {
            var config = GetProducerConfig();

            using (var producer = new ProducerBuilder<string, string>(config).Build())
            {
                Task res = producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = JsonConvert.SerializeObject(eventKey),
                    Value = JsonConvert.SerializeObject(eventInstance)
                });

                Task.WaitAll(res);
            }
        }
    }
}
