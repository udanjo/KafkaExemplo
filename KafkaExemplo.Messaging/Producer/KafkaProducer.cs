using Confluent.Kafka;
using KafkaExemplo.Messaging.Interface;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KafkaExemplo.Messaging.Producer
{
    public class KafkaProducer : IKafkaProducer
    {
        public async Task<bool> ProducerAsync<T>(string topic, T obj)
        {
            ProducerConfig config = new(GetConfig());

            using var publish = new ProducerBuilder<Null, string>(config).Build();
            {
                var result = JsonConvert.SerializeObject(obj);
                var message = new Message<Null, string> { Value = result };
                var dr = await publish.ProduceAsync(topic, message);

                return dr.Status == PersistenceStatus.Persisted;
            }
        }

        public static ClientConfig GetConfig()
        {
            return new ProducerConfig
            {
                BootstrapServers = "host.docker.internal:9092",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.Plaintext
            };
        }
    }
}