using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.Suppliers;
public class CreateSupplierRequest : IRequest<Guid>
{
    public string Name { get; set; } = default!;
    public string ContactPerson { get; set; } = default!;
    public string ContactEmail { get; set; } = default!;
    public string ContactPhoneNumber { get; set; } = default!;
}

public class CreateSupplierRequestValidator : CustomValidator<CreateSupplierRequest>
{
    public CreateSupplierRequestValidator(IReadRepository<Supplier> repository, IStringLocalizer<CreateSupplierRequestValidator> T)
    {
        RuleFor(p => p.Name)
       .NotEmpty()
       .MaximumLength(75)
       .MustAsync(async (name, ct) => await repository.GetBySpecAsync(new SupplierByNameSpec(name), ct) is null)
       .WithMessage((_, name) => T["Supplier {0} already Exists.", name]);

        RuleFor(p => p.ContactPerson)
       .NotEmpty()
       .MaximumLength(75);

        RuleFor(p => p.ContactEmail)
       .NotEmpty()
       .MaximumLength(75);

        RuleFor(p => p.ContactPhoneNumber)
       .NotEmpty()
       .MaximumLength(75);

    }
}

public class CreateBrandRequestHandler : IRequestHandler<CreateSupplierRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Supplier> _repository;

    public CreateBrandRequestHandler(IRepositoryWithEvents<Supplier> repository) => _repository = repository;

    public async Task<Guid> Handle(CreateSupplierRequest request, CancellationToken cancellationToken)
    {
        var supplier = new Supplier(request.Name, request.ContactPhoneNumber,request.ContactPerson, request.ContactEmail);

        await _repository.AddAsync(supplier, cancellationToken);

        return supplier.Id;
    }
}
