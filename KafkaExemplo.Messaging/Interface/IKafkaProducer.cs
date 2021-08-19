using System.Threading;
using System.Threading.Tasks;

namespace KafkaExemplo.Messaging.Interface
{
    public interface IKafkaProducer
    {
        Task<bool> ProducerAsync<T>(string topic, T obj);
    }
}