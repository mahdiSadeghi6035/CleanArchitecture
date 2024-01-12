namespace BlogManagement.Application.Common.Features;

public class OperationResult
{
    public string[] Message { get; set; }
    public bool IsSucceeded { get; set; }

    public OperationResult(IEnumerable<string> message, bool isSucceeded)
    {
        Message = message.ToArray();
        IsSucceeded = isSucceeded;
    }

    public static OperationResult Succeeded()
    {
        return new OperationResult(Array.Empty<string>(), true);
    }
    public static OperationResult Failed(params string[] message)
    {
        return new OperationResult(message, false);
    }
}
