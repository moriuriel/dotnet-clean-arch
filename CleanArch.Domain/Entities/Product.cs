using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Product : Entity
{
    public string Name { get; private set; } = string.Empty;

    public string Description { get; private set; } = string.Empty;

    public decimal Price { get; private set; }

    public int Stock { get; private set; }

    public Guid CategoryId { get; set; }

    public Category Category { get; set; }

    public Product(string name, string description, decimal price, int stock)
    {
        ValidateDomain(name, description, price, stock);
    }

    public Product(Guid id, string name, string description, decimal price, int stock)
    {
        ValidateDomain(name, description, price, stock);
        DomainExceptionValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id value");
        Id = id;
    }

    public void Update(string name, string description, decimal price, int stock, Guid categoryId)
    {
        ValidateDomain(name, description, price, stock);
        DomainExceptionValidation.When(string.IsNullOrEmpty(categoryId.ToString()), "Invalid Id value");
        CategoryId = categoryId;
    }

    private void ValidateDomain(string name, string description, decimal price, int stock)
    {
        DomainExceptionValidation.When(
            hasError: string.IsNullOrEmpty(name),
            error: "Invalid name. Name is required");
        DomainExceptionValidation.When(
            hasError: name.Length < 3,
            error: "Invalid name, too short, minimum 3 characters");
        DomainExceptionValidation.When(
            hasError: string.IsNullOrEmpty(description),
            error: "Invalid description. Description is required");
        DomainExceptionValidation.When(
            hasError: price < 0,
            error: "Invalid price ammount");
        DomainExceptionValidation.When(
          hasError: stock < 0,
          error: "Invalid stock value");

        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }
}
