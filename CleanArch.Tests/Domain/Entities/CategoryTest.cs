using CleanArch.Domain.Entities;
using CleanArch.Domain.Validation;
using FluentAssertions;

namespace CleanArch.Tests.Domain.Entities;

public class CategoryTest
{
    [Fact]
    public void CreateCategory_WithValidValues_ResultObjectValidState()
    {
        Action action = () => new Category("Category Name", Guid.NewGuid());
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Theory]
    [InlineData("P")]
    [InlineData("Pr")]
    public void CreateCategory_WithInvalidName_DomainExceptionShortName(string name)
    {
        Action action = () => new Category(name, Guid.NewGuid());
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Name too short, minimum 3 characters");
    }

    [Theory]
    [InlineData(" ")]
    [InlineData(null)]
    public void CreateCategory_WithInvalidName_DomainExceptionNameIsRequired(string? name)
    {
        Action action = () => new Category(name, Guid.NewGuid());
        action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid name. Name is required");
    }
}

