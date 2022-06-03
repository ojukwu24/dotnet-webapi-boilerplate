namespace FSH.WebApi.Application.Catalog.Products;
public class ProductByCategorySpec : Specification<Product>
{
    public ProductByCategorySpec(Guid categoryId) =>
        Query.Where(p => p.CategoryId == categoryId);
}
