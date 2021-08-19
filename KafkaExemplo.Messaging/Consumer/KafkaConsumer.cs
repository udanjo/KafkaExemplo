using Confluent.Kafka;
using KafkaExemplo.Messaging.Interface;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace KafkaExemplo.Messaging.Consumer
{
    public class KafkaConsumer : IKafkaConsumer
    {
        public async Task<T> ConsumerAsync<T>(string topic)
        {
            ConsumerConfig config = new(GetConfig());

            using var c = new ConsumerBuilder<Ignore, string>(config).Build();
            {
                c.Subscribe(topic);

                var cr = c.Consume();

                return JsonConvert.DeserializeObject<T>(cr.Message.Value);
            }
        }

        public ClientConfig GetConfig()
        {
            return new ConsumerConfig
            {
                GroupId = "Person",
                BootstrapServers = "host.docker.internal:9092",
                SaslMechanism = SaslMechanism.Plain,
                SecurityProtocol = SecurityProtocol.Plaintext,               
                //AutoOffsetReset = AutoOffsetReset.Earliest, //Caso queira pegar desdo Inicio
            };
        }
    }
}