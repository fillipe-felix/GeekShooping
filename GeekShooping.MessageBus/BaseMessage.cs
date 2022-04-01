namespace GeekShooping.MessageBus;

public class BaseMessage
{
    public Guid Id { get; set; }
    public string Message { get; set; }
    public DateTime MessageCreated { get; set; }
}