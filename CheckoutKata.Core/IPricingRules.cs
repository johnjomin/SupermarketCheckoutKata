namespace CheckoutKata.Core;

public interface IPricingRules
{
    int CalculatePrice(Dictionary<string, int> itemCounts);
}