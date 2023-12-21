using CleanArch.Tests.Commons;
using CleanArch.Domain.Entities;

namespace CleanArch.Tests.Domain.Entities.Products;

internal sealed class ProductBuilder : BuilderBase<Product>
{
    public ProductBuilder()
    {
        _name = FakerSingleton.GetInstance().Faker.Commerce.Product();
        _price = FakerSingleton.GetInstance().Faker.Random.Decimal(min: 1, max: 50);
        _stock = FakerSingleton.GetInstance().Faker.Random.Int(min: 0);
        _id = FakerSingleton.GetInstance().Faker.Random.Guid();
        _description = FakerSingleton.GetInstance().Faker.Lorem.Word();
    }

    public override Product Build()
        => new Product(
            id: _id,
            name: _name,
            description: _description,
            price: _price,
            stock: _stock);

    private Guid _id;

    private string _name;

    private string _description;

    private decimal _price;

    private int _stock;

    public ProductBuilder WithName(string name)
    {
        _name = name;
        return this;
    }

    public ProductBuilder WithDescription(string description)
    {
        _description = description;
        return this;
    }

    public ProductBuilder WithPrice(decimal price)
    {
        _price = price;
        return this;
    }

    public ProductBuilder WithStock(int stock)
    {
        _stock = stock;
        return this;
    }
}