using System.Threading.Tasks;

namespace KafkaExemplo.Messaging.Interface
{
    public interface IKafkaConsumer
    {
        Task<T> ConsumerAsync<T>(string topic);
    }
}