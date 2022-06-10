using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Application.Catalog.Categories;
public class DeleteCategoryRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteCategoryRequest(Guid id) => Id = id;
}


public class DeleteCategoryRequestHandler : IRequestHandler<DeleteCategoryRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Category> _categoryRepo;
    private readonly IReadRepository<Product> _productRepo;
    private readonly IStringLocalizer _t;

    public DeleteCategoryRequestHandler(IRepositoryWithEvents<Category> categoryRepo, IReadRepository<Product> productRepo, IStringLocalizer<DeleteCategoryRequestHandler> localizer) =>
        (_categoryRepo, _productRepo, _t) = (categoryRepo, productRepo, localizer);
    public async Task<Guid> Handle(DeleteCategoryRequest request, CancellationToken cancellationToken)
    {
        if (await _productRepo.AnyAsync(new ProductByCategorySpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_t["Category cannot be deleted as it's being used."]);
        }

        var category = await _categoryRepo.GetByIdAsync(request.Id, cancellationToken);

        _ = category ?? throw new NotFoundException(_t["Category {0} Not Found."]);

        await _categoryRepo.DeleteAsync(category, cancellationToken);

        return request.Id;
    }
}
