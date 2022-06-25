namespace FSH.WebApi.Domain.Catalog;
public class UnitOfMeasurement : AuditableEntity, IAggregateRoot
{
    public string Name { get; set; }

    public UnitOfMeasurement(string name)
    {
        Name = name;
    }

    public UnitOfMeasurement Update(string? name)
    {
        if(name is not null && Name?.Equals(name) is not true) Name = name;
        return this;
    }
}
