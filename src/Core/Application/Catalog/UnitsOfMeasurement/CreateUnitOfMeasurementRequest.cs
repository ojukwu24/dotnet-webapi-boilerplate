using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.UnitsOfMeasurement;
public class CreateUnitOfMeasurementRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
}

public class CreateUnitOfMeasurementRequestValidator : CustomValidator<CreateUnitOfMeasurementRequest>
{
    public CreateUnitOfMeasurementRequestValidator(IReadRepository<UnitOfMeasurement> repository, IStringLocalizer<CreateUnitOfMeasurementRequestValidator> T) =>
        RuleFor(p => p.Name)
        .NotEmpty()
        .MaximumLength(75)
        .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new UnitOfMeasurementByNameSpec(name), ct) is null)
        .WithMessage((_, name) => T["Unit of Measurement {0} already exists.", name]);
}

public class CreateUnitOfMeasurementRequestHandler : IRequestHandler<CreateUnitOfMeasurementRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<UnitOfMeasurement> _repository;

    public CreateUnitOfMeasurementRequestHandler(IRepositoryWithEvents<UnitOfMeasurement> repository) => _repository = repository;
    public async Task<Guid> Handle(CreateUnitOfMeasurementRequest request, CancellationToken cancellationToken)
    {
        var unitOfMeasurement = new UnitOfMeasurement(request.Name);

        await _repository.AddAsync(unitOfMeasurement, cancellationToken);

        return unitOfMeasurement.Id;
    }
}
