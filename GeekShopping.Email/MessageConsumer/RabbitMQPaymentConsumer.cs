﻿using System.Text;
using System.Text.Json;

using GeekShopping.Email.Messages;
using GeekShopping.Email.Repository;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GeekShopping.Email.MessageConsumer;

public class RabbitMQPaymentConsumer : BackgroundService
{
    private readonly EmailRepository _repository;
    private IConnection _connection;
    private IModel _channel;
    private const string EXCHANGE_NAME = "DirectPaymentUpdateExchange";
    private const string PAYMENT_EMAIL_UPDATE_QUEUE_NAME = "PaymentEmailUpdateExchange";

    public RabbitMQPaymentConsumer(EmailRepository repository)
    {
        _repository = repository;
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
        
        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Direct);

        _channel.QueueDeclare(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, false, false, false, null);
        _channel.QueueBind(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, EXCHANGE_NAME, "PaymentEmail");
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, ev) =>
        {
            var content = Encoding.UTF8.GetString(ev.Body.ToArray());
            UpdatePaymentResultMessage message = JsonSerializer.Deserialize<UpdatePaymentResultMessage>(content);

            ProcessLogs(message).GetAwaiter().GetResult();
            _channel.BasicAck(ev.DeliveryTag, false);
        };

        _channel.BasicConsume(PAYMENT_EMAIL_UPDATE_QUEUE_NAME, false, consumer);
        
        return Task.CompletedTask;
    }

    private async Task ProcessLogs(UpdatePaymentResultMessage message)
    {
        try
        {
            await _repository.LogEmail(message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
