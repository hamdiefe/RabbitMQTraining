using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;

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
                channel.BasicQos(0, 1, false);

                var consumer = new EventingBasicConsumer(channel);

                channel.BasicConsume("hello-queue", false, consumer);

                consumer.Received += (object sender, BasicDeliverEventArgs e) =>
                {
                    var message = Encoding.UTF8.GetString(e.Body.ToArray());
                    Thread.Sleep(1500);
                    Console.WriteLine("Gelen mesaj:" + message);
                    channel.BasicAck(e.DeliveryTag, false);
                };
                Console.ReadLine();
            }
        }

       
    }
}
