using CleanArch.Domain.Validation;
using CleanArch.Tests.Commons;
using FluentAssertions;
namespace CleanArch.Tests.Domain.Entities.Products;

public class ProductTest
{
    [Fact]
    public void CreateProduct_WithValidValues_ResultObjectValidState()
    {
        //Arrange / Act
        Action action = () => new ProductBuilder().Build();

        //Assert
        action.Should().NotThrow<DomainExceptionValidation>();
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CreateProduct_WithInvalidDescription_DomainExceptionDescriptionIsRequired(string description)
    {
        //Arrange / Act
        Action action = () => new ProductBuilder().WithDescription(description).Build();

        //Assert
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid description. Description is required");
    }

    [Theory]
    [InlineData("")]
    [InlineData(null)]
    public void CreateProduct_WithInvalidName_DomainExceptionNameIsRequired(string name)
    {
        //Arrange / Act
        Action action = () => new ProductBuilder().WithName(name).Build();

        //Assert
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }

    [Fact]
    public void CreateProduct_WithInvalidName_DomainExceptionShortName()
    {
        //Arrange / Act
        Action action = () => new ProductBuilder().WithName("Bu").Build();

        //Assert
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid name, too short, minimum 3 characters");
    }

    [Fact]
    public void CreateProduct_WithInvalidPrice_DomainExceptionInvalidPrice()
    {
        //Arrange / Act
        var price = FakerSingleton.GetInstance().Faker.Random.Decimal(max: -10);

        Action action = () => new ProductBuilder().WithPrice(price).Build();

        //Assert
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid price ammount");
    }

    [Fact]
    public void CreateProduct_WithInvalidStock_DomainExceptionInvalidStock()
    {
        //Arrange / Act
        var stock = FakerSingleton.GetInstance().Faker.Random.Int(max: -10);

        Action action = () => new ProductBuilder().WithStock(stock).Build();

        //Assert
        action.Should()
            .Throw<DomainExceptionValidation>()
            .WithMessage("Invalid stock value");
    }
}