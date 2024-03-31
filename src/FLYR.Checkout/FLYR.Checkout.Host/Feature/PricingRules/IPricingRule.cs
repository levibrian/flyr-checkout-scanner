namespace FLYR.Checkout.Host.Feature.Pricing;

public interface IPricingRule
{
    decimal CalculatePrice(int quantity, decimal unitPrice);
}