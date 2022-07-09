namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderDto : IDto
{
    public Guid Id { get; set; }
    public Guid SupplierId { get; set; }
    public string SupplierName { get; set; } = default!;
    public DateTime PurchaseOrderDate { get; set; }
    public decimal TotalAmount { get; set; }
    public string Code { get; set; } = default!;
    public string Note { get; set; } = default!;
}
