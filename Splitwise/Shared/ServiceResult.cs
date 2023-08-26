namespace Splitwise.Shared;

public class ServiceResult<T>
{
    public ServiceResult(T value)
    {
        Value = value;
    }

    public ServiceResult(Error error)
    {
        Error = error;
    }

    public T Value { get; }
    public Error Error { get; }

    public bool IsError => Error != null;
}