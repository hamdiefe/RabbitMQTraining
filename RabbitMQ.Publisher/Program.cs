using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ.Publisher
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://xnyudbqc:P7iGw2JCjmXYBhfU7co79ZpptepxQylq@beaver.rmq.cloudamqp.com/xnyudbqc");


            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                channel.QueueDeclare("Hello Queue", true, false, false);
                var message = "Hello World";
                var messageBody = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(string.Empty, "Hello Queue", null, messageBody);
                Console.WriteLine("Mesaj Gönderildi.");
            }

        }
    }
}
