namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class PurchaseOrderDto : IDto
{
    public Guid Id { get; set; }
    public Guid PurchaseOrderHeaderId { get; set; }
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public Guid ProductId { get; set; }
    public string ProductName { get; set; } = default!;
}
