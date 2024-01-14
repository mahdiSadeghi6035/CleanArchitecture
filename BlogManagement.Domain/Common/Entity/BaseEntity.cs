namespace BlogManagement.Domain.Common.Entity;

public abstract class BaseEntity<T>
{
    public T Id { get; set; }
}
