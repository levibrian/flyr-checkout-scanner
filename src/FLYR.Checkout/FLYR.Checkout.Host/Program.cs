// Define interfaces for better abstraction and adherence to SOLID principles

using FLYR.Checkout.Host.Feature.Checkout.Models;
using FLYR.Checkout.Host.Feature.Checkout.Services;
using FLYR.Checkout.Host.Feature.Pricing;
using FLYR.Checkout.Host.Feature.PricingRules;

namespace FLYR.Checkout.Host;

public class Program
{
    static void Main(string[] args)
    {
        var greenTea = new Product("GR1", "Green Tea", 3.11m);
        var strawberries = new Product("SR1", "Strawberries", 5.00m);
        var coffee = new Product("CF1", "Coffee", 11.23m);

        var pricingRules = new Dictionary<string, IPricingRule>
        {
            { greenTea.Code, new BuyOneGetOneFreeRule() },
            { strawberries.Code, new BulkDiscountRule(3, 4.50m) },
            { coffee.Code, new CoffeeBulkDiscountRule() }
        };

        var co = new CheckoutService(new()
        {
            { greenTea.Code, greenTea },
            { strawberries.Code, strawberries },
            { coffee.Code, coffee }
        }, pricingRules);

        co.Scan(greenTea.Code);
        co.Scan(strawberries.Code);
        co.Scan(greenTea.Code);
        co.Scan(greenTea.Code);
        co.Scan(coffee.Code);
        co.Scan(coffee.Code);
        co.Scan(coffee.Code);

        var price = co.Total();
        Console.WriteLine($"Total price: £{price}");
    }
}