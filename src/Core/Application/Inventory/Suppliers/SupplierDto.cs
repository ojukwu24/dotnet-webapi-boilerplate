namespace FSH.WebApi.Application.Inventory.Suppliers;
public class SupplierDto : IDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string ContactPerson { get; set; } = default!;
    public string ContactEmail { get; set; } = default!;
    public string ContactPhoneNumber { get; set; } = default!;
}
