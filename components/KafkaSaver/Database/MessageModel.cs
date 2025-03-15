namespace KafkaSaver.Database;

public class MessageModel
{
    public long Id { get; set; }
    public string Key { get; set; } = null!;
    public string Message { get; set; } = null!;
}