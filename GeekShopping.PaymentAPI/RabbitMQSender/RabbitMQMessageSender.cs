using System.Text;
using System.Text.Json;

using GeekShooping.MessageBus;

using GeekShopping.PaymentAPI.Messages;

using RabbitMQ.Client;

namespace GeekShopping.PaymentAPI.RabbitMQSender;

public class RabbitMQMessageSender : IRabbitMQMessageSender
{
    private readonly string _hostName;
    private readonly string _password;
    private readonly string _userName;
    private IConnection _connection;
    private const string EXCHANGE_NAME = "DirectPaymentUpdateExchange";
    private const string PAYMENT_EMAIL_UPDATE_QUEUE_NAME = "DirectEmailUpdateExchange";
    private const string PAYMENT_ORDER_UPDATE_QUEUE_NAME = "DirectOrderUpdateExchange";

    public RabbitMQMessageSender()
    {
        _hostName = "localhost";
        _password = "guest";
        _userName = "guest";
    }

    public void SendMessage(BaseMessage message)
    {
        if (ConnectionExists())
        {
            using var channel = _connection.CreateModel();
            channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct, durable: false);
            channel.QueueDeclare(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, false, false, false, null);
            channel.QueueDeclare(PAYMENT_ORDER_UPDATE_QUEUE_NAME, false, false, false, null);
            
            channel.QueueBind(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, EXCHANGE_NAME, "PaymentEmail");
            channel.QueueBind(PAYMENT_ORDER_UPDATE_QUEUE_NAME, EXCHANGE_NAME, "PaymentOrder");
            var body = GetMessageAsByteArray(message);
            channel.BasicPublish(
                EXCHANGE_NAME, "PaymentEmail", null, body);
            
            channel.BasicPublish(
                EXCHANGE_NAME, "PaymentOrder", null, body);
        }
    }

    private byte[] GetMessageAsByteArray(BaseMessage message)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize((UpdatePaymentResultMessage)message, options);
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
