using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class GetUnitOfMeasurementRequest : IRequest<UnitOfMeasurementDto>
{
    public Guid Id { get; set; }
    public GetUnitOfMeasurementRequest(Guid id) => Id = id;
}

public class UnitOfMeasurementByIdSpec : Specification<UnitOfMeasurement, UnitOfMeasurementDto>, ISingleResultSpecification
{
    public UnitOfMeasurementByIdSpec(Guid id) =>
        Query.Where(x => x.Id == id);
}

public class GetUnitOfMeasurementRequestHandler : IRequestHandler<GetUnitOfMeasurementRequest, UnitOfMeasurementDto>
{
    private readonly IRepository<UnitOfMeasurement> _repository;
    private readonly IStringLocalizer _t;

    public GetUnitOfMeasurementRequestHandler(IRepository<UnitOfMeasurement> repository, IStringLocalizer<GetUnitOfMeasurementRequestHandler> localizer) => (_repository, _t) = (repository, localizer);

    public async Task<UnitOfMeasurementDto> Handle(GetUnitOfMeasurementRequest request, CancellationToken cancellationToken) =>
        await _repository.GetBySpecAsync(
            (ISpecification<UnitOfMeasurement, UnitOfMeasurementDto>)new UnitOfMeasurementByIdSpec(request.Id), cancellationToken)
        ?? throw new NotFoundException(_t["Unit of Measurement {0} Not Found.", request.Id]);
}
