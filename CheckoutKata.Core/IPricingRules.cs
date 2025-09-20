namespace CheckoutKata.Core;

/// <summary>
/// Contract for checkout pricing rules
/// Takes in item quantities and works out the total including any special offers
/// </summary>
public interface IPricingRules
{
    /// <summary>
    /// Calculate the total price for the cart
    /// </summary>
    int CalculatePrice(Dictionary<string, int> itemCounts);
}