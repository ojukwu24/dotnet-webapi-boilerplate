using FSH.WebApi.Application.Inventory.Suppliers;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderDetailsDto
{
    public Guid Id { get; set; }
    public SupplierDto Supplier { get; set; } = default!;
    public DateTime PurchaseOrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Code { get; set; } = default!;
    public string Note { get; set; } = default!;
}
