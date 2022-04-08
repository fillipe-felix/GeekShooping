namespace GeekShooping.MessageBus;

public class BaseMessage
{
    public long Id { get; set; }
    public string? Message { get; set; }
    public DateTime MessageCreated { get; set; }
}