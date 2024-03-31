using FLYR.Checkout.Host.Feature.Pricing;

namespace FLYR.Checkout.Host.Feature.PricingRules;

public class CoffeeBulkDiscountRule : IPricingRule
{
    public decimal CalculatePrice(int quantity, decimal unitPrice)
    {
        if (quantity >= 3)
        {
            return quantity * (2m / 3m) * unitPrice;
        }
        return quantity * unitPrice;
    }
}