namespace FSH.WebApi.Application.Catalog.Products;
public class ProductByUnitOfMeasurementSpec : Specification<Product>
{
    public ProductByUnitOfMeasurementSpec(Guid unitOfMeasurementId) =>
        Query.Where(p => p.UnitOfMeasurementId == unitOfMeasurementId);
}
