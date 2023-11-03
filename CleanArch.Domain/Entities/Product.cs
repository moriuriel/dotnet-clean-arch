namespace CleanArch.Domain.Entities;

public sealed class Product
{
    public Guid Id { get; private set; }

    public string Name { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }
}
