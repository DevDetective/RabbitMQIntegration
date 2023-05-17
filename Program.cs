using Cambifi.RabbitMQ.Plugin.Activities;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Diagnostics;
using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        var connectionFactory = new ConnectionFactory
        {
            Uri = new Uri($"amqp://guest:guest@localhost:5672")
        };

        using var connection = connectionFactory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare("QueueName", true, false, false, null);
        UiPathNotifierContract temp = new() { Message = "\"ST293\" + \" \" + \"Data import failed\"", switchID = Guid.Parse("8D9BB208-9542-D2E8-C2A9-3A09D36EAB63") };
        var body = JsonConvert.SerializeObject(temp);
        var body2 = System.Text.Encoding.UTF8.GetBytes(body);
        channel.BasicPublish(string.Empty, "QueueName", null, body2);


    }
}
