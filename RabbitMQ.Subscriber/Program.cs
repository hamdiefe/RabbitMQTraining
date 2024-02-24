using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace RabbitMQ.Subscriber
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory();
            factory.Uri = new Uri("amqps://uoezbjbp:ISRzzK1r1kKBR46UUPc4WQpBEjcWKLW1@beaver.rmq.cloudamqp.com/uoezbjbp");


            using (var connection = factory.CreateConnection())
            {
                var channel = connection.CreateModel();
                //channel.QueueDeclare("hello-queue", true, false, false);


                var consumer = new EventingBasicConsumer(channel);

                channel.BasicConsume("hello-queue", true, consumer);

                consumer.Received += Consumer_Received;
                Console.ReadLine();
            }
        }

        private static void Consumer_Received(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body.ToArray());
            Console.WriteLine("Gelen mesaj:" + message);
        }
    }
}
