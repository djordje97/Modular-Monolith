using SharedKernels.Events;

namespace SharedKernels.Models;

public abstract class Entity(Guid id, DateTime occuredAt)
{
    public Guid Id { get; set; } = id;
    public DateTime OccuredAt { get; set; } = occuredAt;
    private List<IDomainEvent> _domainEvents = [];
    public IReadOnlyCollection<IDomainEvent> DomainEvents => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    protected void ClearDomainEvents()  
    {
        _domainEvents.Clear();
    }
}