using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class UpdateUnitOfMeasurementRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}

public class UpdateUnitOfMeasurementRequestValidator : CustomValidator<UpdateUnitOfMeasurementRequest>
{
    public UpdateUnitOfMeasurementRequestValidator(IRepository<UnitOfMeasurement> repository, IStringLocalizer<UpdateUnitOfMeasurementRequestValidator> T) =>
        RuleFor(p => p.Name)
        .NotEmpty()
        .MaximumLength(75)
        .MustAsync(async (uom, name, ct) =>
            await repository.GetBySpecAsync(new UnitOfMeasurementByNameSpec(name), ct)
                is not UnitOfMeasurement existingUoM || existingUoM.Id == uom.Id)
                .WithMessage((_, name) => T["Unit of Measurement {0} already Exists.", name]);
}

public class UpdateUnitOfMeasurementRequestHandler : IRequestHandler<UpdateUnitOfMeasurementRequest, Guid>
{
    private readonly IRepositoryWithEvents<UnitOfMeasurement> _repository;
    private readonly IStringLocalizer _t;

    public UpdateUnitOfMeasurementRequestHandler(IRepositoryWithEvents<UnitOfMeasurement> repository, IStringLocalizer<UpdateUnitOfMeasurementRequestHandler> localizer) =>
        (_repository, _t) = (repository, localizer);
    public async Task<Guid> Handle(UpdateUnitOfMeasurementRequest request, CancellationToken cancellationToken)
    {
        var uom = await _repository.GetByIdAsync(request.Id, cancellationToken);
        _ = uom ?? throw new NotFoundException(_t["Unit of Measurement {0} Not Found.", request.Id]);

        uom.Update(request.Name);

        await _repository.UpdateAsync(uom, cancellationToken);
        return request.Id;
    }
}
