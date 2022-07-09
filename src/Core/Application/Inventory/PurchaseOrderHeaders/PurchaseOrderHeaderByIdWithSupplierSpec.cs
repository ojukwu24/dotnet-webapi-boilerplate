using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderByIdWithSupplierSpec : Specification<PurchaseOrderHeader, PurchaseOrderHeaderDetailsDto>, ISingleResultSpecification
{
    public PurchaseOrderHeaderByIdWithSupplierSpec(Guid id) =>
        Query.Where(c => c.Id == id)
        .Include(c => c.Supplier);
}
