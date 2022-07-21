namespace Domain.Contracts;

public interface IEntity<TId>
{
    public TId Id { get; set; }
}
