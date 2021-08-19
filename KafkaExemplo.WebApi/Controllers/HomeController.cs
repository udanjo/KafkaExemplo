using KafkaExemplo.Messaging.Interface;
using KafkaExemplo.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KafkaExemplo.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HomeController : ControllerBase
    {
        private readonly IKafkaProducer _producer;
        private readonly IKafkaConsumer _consumer;
        private const string _TOPIC = "Person";

        public HomeController(IKafkaProducer producer,
                              IKafkaConsumer consumer)
        {
            _producer = producer;
            _consumer = consumer;
        }

        [HttpPost]
        public async Task<IActionResult> Publish([FromBody] PersonModel request)
        {
            var result = await _producer.ProducerAsync(_TOPIC, request);

            return result
                ? Ok("Mensagem Publicada com Sucesso")
                : BadRequest("Houve algum erro ao publicar a mensagem...");
        }

        [HttpGet]
        public async Task<IActionResult> Consumer()
        {
            var result = await _consumer.ConsumerAsync<PersonModel>(_TOPIC);
            return Ok(result);
        }
    }
}