namespace Domain.Contracts;
public abstract class EntityBase<TId> : IEntity<TId>
{
    public TId Id { get; set; }
}
