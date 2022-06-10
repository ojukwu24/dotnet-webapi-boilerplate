using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FSH.WebApi.Application.Catalog.Products;
public class ProductByUnitOfMeasurementSpec : Specification<Product>
{
    public ProductByUnitOfMeasurementSpec(Guid unitOfMeasurementId) =>
        Query.Where(p => p.UnitOfMeasurementId == unitOfMeasurementId);
}
