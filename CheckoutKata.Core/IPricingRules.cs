namespace CheckoutKata.Core;

/// <summary>
/// Contract for pricing rules
/// </summary>
public interface IPricingRules
{
    /// <summary>
    /// Calculate the total price for the cart
    /// </summary>
    int CalculatePrice(IReadOnlyDictionary<string, int> itemCounts);
}