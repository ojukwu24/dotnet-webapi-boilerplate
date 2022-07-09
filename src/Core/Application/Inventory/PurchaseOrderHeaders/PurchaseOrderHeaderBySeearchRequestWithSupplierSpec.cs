using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.PurchaseOrderHeaders;
public class PurchaseOrderHeaderBySeearchRequestWithSupplierSpec : EntitiesByPaginationFilterSpec<PurchaseOrderHeader, PurchaseOrderHeaderDto>
{
    public PurchaseOrderHeaderBySeearchRequestWithSupplierSpec(SearchPurchaseOrderHeadersRequest request)
        : base(request) => Query.Include(p => p.Supplier);
}
