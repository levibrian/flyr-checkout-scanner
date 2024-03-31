namespace FLYR.Checkout.Host.Feature.Pricing;

public class BuyOneGetOneFreeRule : IPricingRule
{
    public decimal CalculatePrice(int quantity, decimal unitPrice)
    {
        return (quantity / 2 + quantity % 2) * unitPrice;
    }
}