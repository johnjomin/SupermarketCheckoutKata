using CheckoutKata.Core;

namespace CheckoutKata.Tests;

public class TestPricingRules : IPricingRules
{
    public int CalculatePrice(IReadOnlyDictionary<string, int> itemCounts)
    {
        // Simple test pricing: all items cost 10 each
        return itemCounts.Values.Sum() * 10;
    }
}