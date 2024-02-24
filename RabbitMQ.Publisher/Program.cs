﻿using RabbitMQ.Client;
using System;
using System.Text;

namespace RabbitMQ.Publisher
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
                channel.QueueDeclare("hello-queue", true, false, false);
                var message = "Hello World";
                var messageBody = Encoding.UTF8.GetBytes(message);
                channel.BasicPublish(string.Empty, "hello-queue", null, messageBody);
                Console.WriteLine("Mesaj Gönderildi.");
                Console.ReadLine();
            }

        }
    }
}
