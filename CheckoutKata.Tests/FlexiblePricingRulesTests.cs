using CheckoutKata.Core;
using Xunit;

namespace CheckoutKata.Tests;

public class FlexiblePricingRulesTests
{
    [Fact]
    public void FlexiblePricingRules_WithStandardRules_MatchesBasicPricing()
    {
        // Arrange
        var flexibleRules = FlexiblePricingRules.CreateStandardRules();
        var basicRules = new BasicPricingRules();
        var itemCounts = new Dictionary<string, int>
        {
            { "A", 3 },
            { "B", 2 },
            { "C", 1 },
            { "D", 1 }
        };

        // Act
        var flexibleTotal = flexibleRules.CalculatePrice(itemCounts);
        var basicTotal = basicRules.CalculatePrice(itemCounts);

        // Assert
        Assert.Equal(basicTotal, flexibleTotal);
        Assert.Equal(200, flexibleTotal); // 130 + 45 + 20 + 15
    }

    [Fact]
    public void FlexiblePricingRules_WithCustomPrices_UsesNewConfiguration()
    {
        // Arrange
        var customPrices = new[]
        {
            new ItemPrice("A", 100), // No special offer
            new ItemPrice("B", 50, 3, 120) // Different special offer
        };
        var rules = new FlexiblePricingRules(customPrices);
        var itemCounts = new Dictionary<string, int> { { "A", 2 }, { "B", 3 } };

        // Act
        var total = rules.CalculatePrice(itemCounts);

        // Assert
        Assert.Equal(320, total); // A: 2*100=200, B: 3 for 120 = 200+120
    }
}