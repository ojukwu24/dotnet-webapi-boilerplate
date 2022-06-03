namespace FSH.WebApi.Application.Catalog.Categories;

public class CategoryByNameSpec : Specification<Category>, ISingleResultSpecification
{
    public CategoryByNameSpec(string name) => Query.Where(c => c.Name == name);
}