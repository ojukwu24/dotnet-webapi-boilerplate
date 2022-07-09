namespace FSH.WebApi.Domain.Inventory;
public class Supplier : AuditableEntity, IAggregateRoot
{
    public Supplier(string name, string contactPerson, string contactEmail, string contactPhoneNumber)
    {
        Name = name;
        ContactPerson = contactPerson;
        ContactEmail = contactEmail;
        ContactPhoneNumber = contactPhoneNumber;
    }

    public string Name { get; private set; }
    public string ContactPerson { get; private set; }
    public string ContactEmail { get; private set; }
    public string ContactPhoneNumber { get; private set; }

    public Supplier Update(string? name, string? contactPerson, string? contactEmail, string? contactPhoneNumber)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if(contactPerson is not null && ContactEmail?.Equals(contactEmail) is not true) ContactPerson = contactPerson;
        if(contactEmail is not null && ContactEmail?.Equals(ContactEmail) is not true) ContactEmail = contactEmail;
        if(contactPhoneNumber is not null && ContactPhoneNumber?.Equals(ContactPhoneNumber) is not true) ContactPhoneNumber = contactPhoneNumber;
        return this;
    }
}
