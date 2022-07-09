using FSH.WebApi.Domain.Inventory;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class SearchPurchaseOrderRequest : PaginationFilter, IRequest<PaginationResponse<PurchaseOrderDto>>
{
    public Guid? ProductId { get; set;  }
    public string? PurchaseOrderHeaderCode { get; set;  }
    public DateTime? QueryStartDate { get; set; }
    public DateTime? QueryEndDate { get; set; }

}

public class SearchPurchaseOrderRequestHandler : IRequestHandler<SearchPurchaseOrderRequest, PaginationResponse<PurchaseOrderDto>>
{
    private readonly IReadRepository<PurchaseOrder> _repository;

    public SearchPurchaseOrderRequestHandler(IReadRepository<PurchaseOrder> repository) => _repository = repository;

    public async Task<PaginationResponse<PurchaseOrderDto>> Handle(SearchPurchaseOrderRequest request, CancellationToken cancellationToken)
    {
        var spec = new PurchaseOrderBySearchWithPurchaseOrderHeaderSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}
