using KafkaExemplo.Messaging.Consumer;
using KafkaExemplo.Messaging.Interface;
using KafkaExemplo.Messaging.Producer;
using Microsoft.Extensions.DependencyInjection;

namespace KafkaExemplo.Infra
{
    public static class IoC
    {
        public static IServiceCollection ConfigureRegister(this IServiceCollection services)
        {
            services.AddScoped<IKafkaProducer, KafkaProducer>();
            services.AddScoped<IKafkaConsumer, KafkaConsumer>();

            return services;
        }
    }
}