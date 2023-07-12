using System;
using System.Text;
using System.Text.Json;
using RabbitMQ.Client;

namespace WebHookReceiver.Client
{
    public class MessageBusClient : IMessageBusClient
    {
        public void SendMessage(JsonElement jsonData)
        {
            var factory = new ConnectionFactory() { HostName = "localhost", Port = 5672 };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel()){
                channel.ExchangeDeclare(exchange: "preEmployeeMoved", type: ExchangeType.Fanout);

                var message = JsonSerializer.Serialize(jsonData);
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "preEmployeeMoved",
                            routingKey: "",
                            basicProperties: null,
                            body: body);

                Console.WriteLine(" --> Messagem enviada para Message Bus.");
            }
        }
    }
}