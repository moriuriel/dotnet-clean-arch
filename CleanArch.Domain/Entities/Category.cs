using CleanArch.Domain.Validation;

namespace CleanArch.Domain.Entities;

public sealed class Category: Entity
{
    public string Name { get; private set; } = string.Empty;

    public ICollection<Product> Products { get; private set; }

    public Category(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    public Category(string name, Guid id)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(id.ToString()), "Invalid Id type.");

        ValidateDomain(name);
        Name = name;
        Id = id;
    }

    public void Update(string name)
    {
        ValidateDomain(name);
        Name = name;
    }

    private void ValidateDomain(string name)
    {
        DomainExceptionValidation.When(string.IsNullOrWhiteSpace(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Name too short, minimum 3 characters");
    }
}


