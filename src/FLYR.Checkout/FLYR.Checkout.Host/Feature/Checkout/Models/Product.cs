namespace FLYR.Checkout.Host.Feature.Checkout.Models;

public interface IProduct
{
    string Code { get; }
    string Name { get; }
    decimal Price { get; }
}

public class Product : IProduct
{
    public string Code { get; }
    public string Name { get; }
    public decimal Price { get; }

    public Product(string code, string name, decimal price)
    {
        Code = code;
        Name = name;
        Price = price;
    }
}