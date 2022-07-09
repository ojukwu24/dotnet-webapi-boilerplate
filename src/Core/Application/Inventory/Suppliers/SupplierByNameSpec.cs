using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.Suppliers;
public class SupplierByNameSpec : Specification<Supplier>, ISingleResultSpecification
{
    public SupplierByNameSpec(string name) => Query.Where(x => x.Name == name);
}
