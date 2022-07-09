using FSH.WebApi.Domain.Common.Events;
using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class DeletePurchaseOrderHeaderRequest : IRequest<Guid>
{
    public Guid Id { get; set; }
    public DeletePurchaseOrderHeaderRequest(Guid id) => Id = id;
}

public class DeletePurchaseOrderHeaderRequestHandler : IRequestHandler<DeletePurchaseOrderHeaderRequest, Guid>
{
    private readonly IRepository<PurchaseOrderHeader> _repository;
    private readonly IStringLocalizer _t;

    public DeletePurchaseOrderHeaderRequestHandler(IRepository<PurchaseOrderHeader> repository, IStringLocalizer<DeletePurchaseOrderHeaderRequestHandler> t)
    {
        _repository = repository;
        _t = t;
    }

    public async Task<Guid> Handle(DeletePurchaseOrderHeaderRequest request, CancellationToken cancellationToken)
    {
        var purchaseOrderHeader = await _repository.GetByIdAsync(request.Id, cancellationToken);

        _ = purchaseOrderHeader ?? throw new NotFoundException(_t["Purchase Order Header {0} not found"]);
        purchaseOrderHeader.DomainEvents.Add(EntityDeletedEvent.WithEntity(purchaseOrderHeader));

        await _repository.DeleteAsync(purchaseOrderHeader, cancellationToken);
        return request.Id;
    }
}
