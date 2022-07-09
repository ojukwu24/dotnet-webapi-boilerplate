using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class SearchPurchaseOrderHeadersRequest : PaginationFilter, IRequest<PaginationResponse<PurchaseOrderHeaderDto>>
{
    public Guid? SupplierId { get; set; }
}


public class SearchPurchaseOrderHeadersRequestHandler : IRequestHandler<SearchPurchaseOrderHeadersRequest, PaginationResponse<PurchaseOrderHeaderDto>>
{
    private readonly IReadRepository<PurchaseOrderHeader> _repository;

    public SearchPurchaseOrderHeadersRequestHandler(IReadRepository<PurchaseOrderHeader> repository) => _repository = repository;

    public async Task<PaginationResponse<PurchaseOrderHeaderDto>> Handle(SearchPurchaseOrderHeadersRequest request, CancellationToken cancellationToken)
    {
        var spec = new PurchaseOrderHeaderBySeearchRequestWithSupplierSpec(request);
        return await _repository.PaginatedListAsync(spec, request.PageNumber, request.PageSize, cancellationToken: cancellationToken);
    }
}
