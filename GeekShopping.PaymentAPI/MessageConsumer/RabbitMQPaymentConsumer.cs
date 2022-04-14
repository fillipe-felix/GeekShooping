﻿using System.Text;
using System.Text.Json;

using GeekShopping.PaymentAPI.Messages;
using GeekShopping.PaymentAPI.RabbitMQSender;
using GeekShopping.PaymentProcessor;

using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace GeekShopping.PaymentAPI.MessageConsumer;

public class RabbitMQPaymentConsumer : BackgroundService
{
    private IConnection _connection;
    private IModel _channel;
    private IRabbitMQMessageSender _rabbitMqMessageSender;
    private readonly IProcessPayment _processPayment;

    public RabbitMQPaymentConsumer(IProcessPayment processPayment, IRabbitMQMessageSender rabbitMqMessageSender)
    {
        _processPayment = processPayment;
        _rabbitMqMessageSender = rabbitMqMessageSender;
        var factory = new ConnectionFactory
        {
            HostName = "localhost",
            UserName = "guest",
            Password = "guest"
        };
        
        _connection = factory.CreateConnection();

        _channel = _connection.CreateModel();
        _channel.QueueDeclare(queue: "orderpaymentprocessqueue", false, false, false, null);
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        stoppingToken.ThrowIfCancellationRequested();

        var consumer = new EventingBasicConsumer(_channel);
        consumer.Received += (channel, ev) =>
        {
            var content = Encoding.UTF8.GetString(ev.Body.ToArray());
            PaymentMessage vo = JsonSerializer.Deserialize<PaymentMessage>(content);

            ProcessPayment(vo).GetAwaiter().GetResult();
            _channel.BasicAck(ev.DeliveryTag, false);
        };

        _channel.BasicConsume("orderpaymentprocessqueue", false, consumer);
        
        return Task.CompletedTask;
    }

    private async Task ProcessPayment(PaymentMessage vo)
    {
        var result = _processPayment.PaymentProcessor();

        UpdatePaymentResultMessage paymentResult = new()
        {
            Status = result,
            OrderId = vo.OrderId,
            Email = vo.Email
        };
        
        try
        {
            _rabbitMqMessageSender.SendMessage(paymentResult, "orderpaymentresultqueue");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
