using System.Text;
using System.Text.Json;

using GeekShooping.MessageBus;

using GeekShopping.CartAPI.Messages;

using RabbitMQ.Client;

namespace GeekShopping.CartAPI.RabbitMQSender;

public class RabbitMQMessageSender : IRabbitMQMessageSender
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _userName;
    private IConnection _connection;

    public RabbitMQMessageSender()
    {
        _hostName = "localhost";
        _password = "guest";
        _userName = "guest";
    }

    public void SendMessage(BaseMessage message, string queueName)
    {
        if (ConnectionExists())
        {
            using var channel = _connection.CreateModel();
            channel.QueueDeclare(queueName, false, false, false, null);
            var body = GetMessageAsByteArray(message);
            channel.BasicPublish(
                "", queueName, null, body);
        }
    }

    private byte[] GetMessageAsByteArray(BaseMessage message)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize((CheckoutHeaderVO)message, options);
        var body = Encoding.UTF8.GetBytes(json);
        return body;
    }

    private void CreateConnection()
    {
        try
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password
            };
            _connection = factory.CreateConnection();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    private bool ConnectionExists()
    {
        if (_connection != null)
        {
            return true;
        }

        CreateConnection();
        return _connection != null;
    }

    
}
