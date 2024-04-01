using FLYR.Checkout.Host.Feature.Checkout.Models;
using FLYR.Checkout.Host.Feature.Pricing;

namespace FLYR.Checkout.Host.Feature.Checkout.Services;

public class CheckoutService
{
    private readonly Dictionary<string, IProduct> products;
    private readonly Dictionary<string, IPricingRule> pricingRules;
    private readonly Dictionary<string, int> cart = new();

    public CheckoutService(Dictionary<string, IProduct> products, Dictionary<string, IPricingRule> pricingRules)
    {
        this.products = products;
        this.pricingRules = pricingRules;
    }

    public void Scan(string productCode)
    {
        if (products.ContainsKey(productCode))
        {
            cart.TryAdd(productCode, 0);
            cart[productCode]++;
        }
        else
        {
            throw new ArgumentException("Invalid product code");
        }
    }

    public decimal Total()
    {
        var totalPrice = 0m;
        foreach (var (productCode, quantity) in cart)
        {
            var product = products[productCode];
            var unitPrice = product.Price;

            if (pricingRules.TryGetValue(productCode, out var rule))
            {
                totalPrice += rule.CalculatePrice(quantity, unitPrice);
            }
            else
            {
                totalPrice += quantity * unitPrice;
            }
        }
        return totalPrice;
    }
}