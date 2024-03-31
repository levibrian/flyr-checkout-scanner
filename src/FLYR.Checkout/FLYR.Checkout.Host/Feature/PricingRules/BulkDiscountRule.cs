using FLYR.Checkout.Host.Feature.Pricing;

namespace FLYR.Checkout.Host.Feature.PricingRules;

public class BulkDiscountRule : IPricingRule
{
    private readonly int bulkQuantity;
    private readonly decimal discountedPrice;

    public BulkDiscountRule(int bulkQuantity, decimal discountedPrice)
    {
        this.bulkQuantity = bulkQuantity;
        this.discountedPrice = discountedPrice;
    }

    public decimal CalculatePrice(int quantity, decimal unitPrice)
    {
        if (quantity >= bulkQuantity)
        {
            return quantity * discountedPrice;
        }
        return quantity * unitPrice;
    }
}