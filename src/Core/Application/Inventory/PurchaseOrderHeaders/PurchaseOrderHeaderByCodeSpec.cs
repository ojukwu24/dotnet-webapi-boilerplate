using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderByCodeSpec : Specification<PurchaseOrderHeader>, ISingleResultSpecification
{
    public PurchaseOrderHeaderByCodeSpec(string code) => Query.Where(x => x.Code == code);
}
