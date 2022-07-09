using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Domain.Inventory;
public class PurchaseOrderHeader : AuditableEntity, IAggregateRoot
{
    public Guid SupplierId { get; private set; }
    public virtual Supplier Supplier { get; private set; } = default!;
    public DateTime PurchaseOrderDate { get; private set; }
    public decimal TotalAmount { get; private set; }
    public string Code { get; private set; }
    public string Note { get; private set; }

    public PurchaseOrderHeader(Guid supplierId, DateTime purchaseOrderDate, decimal totalAmount, string code, string note)
    {
        SupplierId = supplierId;
        PurchaseOrderDate = purchaseOrderDate;
        TotalAmount = totalAmount;
        Code = code;
        Note = note;
    }

    public PurchaseOrderHeader Update(Guid? supplierId, DateTime? purchaseOrderDate, decimal? totalAmount, string? code, string? note)
    {
        if (supplierId.HasValue && supplierId.Value != Guid.Empty && !SupplierId.Equals(supplierId.Value)) SupplierId = supplierId.Value;
        if (purchaseOrderDate.HasValue && !PurchaseOrderDate.Equals(purchaseOrderDate.Value)) PurchaseOrderDate = purchaseOrderDate.Value;
        if (totalAmount.HasValue && TotalAmount != totalAmount) TotalAmount = totalAmount.Value;
        if (code is not null && Code?.Equals(code) is not true) Code = code;
        if (note is not null && Note?.Equals(note) is not true) Note = note;

        return this;
    }
}
