using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class PurchaseOrderBySearchWithPurchaseOrderHeaderSpec : EntitiesByPaginationFilterSpec<PurchaseOrder, PurchaseOrderDto>
{
    public PurchaseOrderBySearchWithPurchaseOrderHeaderSpec(SearchPurchaseOrderRequest request)
        : base(request)
    {
        Query.Include(p => p.Product)
            .Include(p => p.PurchaseOrderHeader)
            .OrderBy(c => c.Product.Name)
            .Where(p => p.ProductId.Equals(request.ProductId), request.ProductId.HasValue)
            .Where(p => p.PurchaseOrderHeader.Code.Equals(request.PurchaseOrderHeaderCode), !string.IsNullOrEmpty(request.PurchaseOrderHeaderCode))
            .Where(p => p.PurchaseOrderHeader.PurchaseOrderDate >= request.QueryStartDate!.Value, request.QueryStartDate.HasValue)
            .Where(p => p.PurchaseOrderHeader.PurchaseOrderDate <= request.QueryEndDate!.Value, request.QueryEndDate.HasValue);
    }
}
