using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.Suppliers;
public class DeleteSupplierRequest : IRequest<Guid>
{
    public Guid Id { get; set; }

    public DeleteSupplierRequest(Guid id) => Id = id;
}

public class DeleteSupplierRequestHandler : IRequestHandler<DeleteSupplierRequest, Guid>
{
    // Add Domain Events automatically by using IRepositoryWithEvents
    private readonly IRepositoryWithEvents<Supplier> _supplierRepo;
    private readonly IStringLocalizer _t;

    public DeleteSupplierRequestHandler(IRepositoryWithEvents<Supplier> supplierRepo, IStringLocalizer<DeleteSupplierRequestHandler> localizer) =>
        (_supplierRepo, _t) = (supplierRepo, localizer);
    public async Task<Guid> Handle(DeleteSupplierRequest request, CancellationToken cancellationToken)
    {
       var supplier = await _supplierRepo.GetByIdAsync(request.Id, cancellationToken);

       _ = supplier ?? throw new NotFoundException(_t["Supplier {0} Not Found."]);

       await _supplierRepo.DeleteAsync(supplier, cancellationToken);

       return request.Id;
    }
}
