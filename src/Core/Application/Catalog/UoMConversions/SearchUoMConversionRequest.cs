namespace FSH.WebApi.Application.Catalog.UoMConversions;
public class SearchUoMConversionRequest : PaginationFilter, IRequest<PaginationResponse<UoMConversionDto>>
{
}

public class UoMConversionBySearchRequestSpec : EntitiesByPaginationFilterSpec<UoMConversion, UoMConversionDto>
{
    public UoMConversionBySearchRequestSpec(SearchUoMConversionRequest request)
        : base(request) =>
        Query.OrderBy(x => x.ProductId, !request.HasOrderBy());
}

public class SearchUoMConversionRequestHandler : IRequestHandler<SearchUoMConversionRequest, PaginationResponse<UoMConversionDto>>
{
    private readonly IReadRepository<UoMConversion> _repository;
    public SearchUoMConversionRequestHandler(IReadRepository<UoMConversion> repository) => _repository = repository;
    public async Task<PaginationResponse<UoMConversionDto>> Handle(SearchUoMConversionRequest request, CancellationToken cancellationToken)
    {
        var spec = new UoMConversionBySearchRequestSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken);
    }
}
