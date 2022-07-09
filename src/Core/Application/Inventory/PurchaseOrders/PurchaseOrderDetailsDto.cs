using FSH.WebApi.Domain.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Inventory.PurchaseOrders;
public class PurchaseOrderDetailsDto : IDto
{
    public Guid Id { get; set; }
    public PurchaseOrderHeader PurchaseOrderHeader { get; set; } = default!;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
    public Product Product { get; set; } = default!;
}
