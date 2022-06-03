namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class SearchUnitOfMeasurementRequest : PaginationFilter, IRequest<PaginationResponse<UnitOfMeasurementDto>>
{
}

public class UnitOfMeasurementBySearchRequestSpec : EntitiesByPaginationFilterSpec<UnitOfMeasurement, UnitOfMeasurementDto>
{
    public UnitOfMeasurementBySearchRequestSpec(SearchUnitOfMeasurementRequest request)
        : base(request) =>
        Query.OrderBy(x => x.Name, !request.HasOrderBy());
}

public class SearchUnitOfMeasurementRequestHandler : IRequestHandler<SearchUnitOfMeasurementRequest, PaginationResponse<UnitOfMeasurementDto>>
{
    private readonly IReadRepository<UnitOfMeasurement> _repository;

    public SearchUnitOfMeasurementRequestHandler(IReadRepository<UnitOfMeasurement> repository) => _repository = repository;

    public async Task<PaginationResponse<UnitOfMeasurementDto>> Handle(SearchUnitOfMeasurementRequest request, CancellationToken cancellationToken)
    {
        var spec = new UnitOfMeasurementBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
