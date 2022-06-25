using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.UoMConversions;
public class GetUoMConversionRequest : IRequest<UoMConversionDto>
{
    public Guid Id { get; set;}

    public GetUoMConversionRequest(Guid id) => Id = id;
}

public class UomConversionByIdSpec : Specification<UoMConversion, UoMConversionDto>, ISingleResultSpecification
{
    public UomConversionByIdSpec(Guid id) =>
        Query.Where(p => p.Id == id);
}

public class GetUoMConversionRequestHandler : IRequestHandler<GetUoMConversionRequest, UoMConversionDto>
{
    private readonly IRepository<UoMConversion> _repository;
    private readonly IStringLocalizer _t;

    public GetUoMConversionRequestHandler(IRepository<UoMConversion> repository, IStringLocalizer<GetUoMConversionRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<UoMConversionDto> Handle(GetUoMConversionRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<UoMConversion, UoMConversionDto>)new UomConversionByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Category {0} Not Found.", request.Id]);
}
