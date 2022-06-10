namespace FSH.WebApi.Domain.Catalog;

public class Product : AuditableEntity, IAggregateRoot
{
    public string Name { get; private set; } = default!;
    public string? Description { get; private set; }
    public decimal Rate { get; private set; }
    public string? ImagePath { get; private set; }
    public Guid BrandId { get; private set; }
    public virtual Brand Brand { get; private set; } = default!;
    public Guid CategoryId { get; private set; }
    public virtual Category Category { get; private set; } = default!;
    public Guid UnitOfMeasurementId { get; private set; }
    public virtual UnitOfMeasurement UnitOfMeasurement { get; private set; } = default!;
    public Product(string name, string? description, decimal rate, Guid brandId, Guid categoryId, Guid unitOfMeasurementId, string? imagePath)
    {
        Name = name;
        Description = description;
        Rate = rate;
        ImagePath = imagePath;
        BrandId = brandId;
        CategoryId = categoryId;
        UnitOfMeasurementId = unitOfMeasurementId;
    }

    public Product Update(string? name, string? description, decimal? rate, Guid? brandId, Guid? categoryId, Guid? unitOfMeasurementId, string? imagePath)
    {
        if (name is not null && Name?.Equals(name) is not true) Name = name;
        if (description is not null && Description?.Equals(description) is not true) Description = description;
        if (rate.HasValue && Rate != rate) Rate = rate.Value;
        if (brandId.HasValue && brandId.Value != Guid.Empty && !BrandId.Equals(brandId.Value)) BrandId = brandId.Value;
        if (categoryId.HasValue && categoryId.Value != Guid.Empty && !Category.Equals(categoryId.Value)) CategoryId = categoryId.Value;
        if (unitOfMeasurementId.HasValue && unitOfMeasurementId.Value != Guid.Empty && !UnitOfMeasurement.Equals(unitOfMeasurementId.Value)) UnitOfMeasurementId = unitOfMeasurementId.Value;
        if (imagePath is not null && ImagePath?.Equals(imagePath) is not true) ImagePath = imagePath;
        return this;
    }

    public Product ClearImagePath()
    {
        ImagePath = string.Empty;
        return this;
    }
}