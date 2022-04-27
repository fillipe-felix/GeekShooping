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
    private const string EXCHANGE_NAME = "FanoutPaymentUpdateExchange";
    private string queueName = "";

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
        _channel.ExchangeDeclare(EXCHANGE_NAME, ExchangeType.Fanout);
        queueName = _channel.QueueDeclare().QueueName;
        _channel.QueueBind(queueName, EXCHANGE_NAME, "");
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

        _channel.BasicConsume(queueName, false, consumer);
        
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