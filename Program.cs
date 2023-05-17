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

        channel.QueueDeclare("FromBank_RPA_State", true, false, false, null);
        UiPathNotifierContract temp = new() { Message = "\"ST293\" + \" \" + \"Data import failed\"", switchID = Guid.Parse("8D9BB208-9542-D2E8-C2A9-3A09D36EAB63") };
        var body = JsonConvert.SerializeObject(temp);
        var body2 = System.Text.Encoding.UTF8.GetBytes(body);
        channel.BasicPublish(string.Empty, "FromBank_RPA_State", null, body2);

        //channel.QueueDeclare("SwitchACHSubsQueue", true, false, false, null);
        //UiPathNotifierContract temp = new() { Message = "ST290", switchID = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6") };
        //var body = JsonConvert.SerializeObject(temp);
        //var body2 = System.Text.Encoding.UTF8.GetBytes(body);
        //channel.BasicPublish(string.Empty, "SwitchACHSubsQueue", null, body2);


    }
}