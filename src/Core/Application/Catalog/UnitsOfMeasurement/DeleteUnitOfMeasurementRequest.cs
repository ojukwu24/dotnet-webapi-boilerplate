using FSH.WebApi.Application.Catalog.Products;

namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class DeleteUnitOfMeasurementRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeleteUnitOfMeasurementRequest(Guid id) => Id = id;
}

public class DeleteUnitOfMeasurementRequestHandler : IRequestHandler<DeleteUnitOfMeasurementRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<UnitOfMeasurement> _repository;
    private readonly IReadRepository<Product> _productRepo;

    private readonly IStringLocalizer _t;

    public DeleteUnitOfMeasurementRequestHandler(IRepositoryWithEvents<UnitOfMeasurement> repository, IReadRepository<Product> productRepo, IStringLocalizer<DeleteUnitOfMeasurementRequestHandler> localizer) =>
        (_repository, _productRepo, _t) = (repository,productRepo, localizer);
    public async Task<Guid> Handle(DeleteUnitOfMeasurementRequest request, CancellationToken cancellationToken)
    {
        if (await _productRepo.AnyAsync(new ProductByUnitOfMeasurementSpec(request.Id), cancellationToken))
        {
            throw new ConflictException(_t["Unit of Measurement cannot be deleted as it's being used."]);
        }

        var uom = await _repository.GetByIdAsync(request.Id, cancellationToken);
       _ = uom ?? throw new NotFoundException(_t["Unit of Measurement {0} Not Found."]);
       await _repository.DeleteAsync(uom, cancellationToken);

       return request.Id;
    }
}
