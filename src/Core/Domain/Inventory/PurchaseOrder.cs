using FSH.WebApi.Domain.Catalog;

namespace FSH.WebApi.Domain.Inventory;
public class PurchaseOrder : AuditableEntity, IAggregateRoot
{
    public Guid PurchaseOrderHeaderId { get; private set; }
    public decimal UnitPrice { get; private set; }
    public int Quantity { get; private set; }
    public Guid ProductId { get; private set; }
    public virtual Product Product { get; private set; } = default!;
    public virtual PurchaseOrderHeader PurchaseOrderHeader { get; private set; } = default!;


    public PurchaseOrder(Guid purchaseOrderHeaderId, decimal unitPrice, int quantity, Guid productId)
    {
        PurchaseOrderHeaderId = purchaseOrderHeaderId;
        UnitPrice = unitPrice;
        Quantity = quantity;
        ProductId = productId;
    }

    public PurchaseOrder Update(Guid? purchaseOrderHeaderId, decimal? unitPrice, int? quantity, Guid? productId)
    {
        if(purchaseOrderHeaderId.HasValue && purchaseOrderHeaderId.Value != Guid.Empty && !PurchaseOrderHeaderId.Equals(purchaseOrderHeaderId.Value)) PurchaseOrderHeaderId = purchaseOrderHeaderId.Value;
        if (productId.HasValue && productId.Value != Guid.Empty && !ProductId.Equals(productId.Value)) ProductId = productId.Value;
        if (unitPrice.HasValue && UnitPrice != unitPrice) UnitPrice = unitPrice.Value;
        if (quantity.HasValue && Quantity != quantity) Quantity = quantity.Value;

        return this;
    }
}
