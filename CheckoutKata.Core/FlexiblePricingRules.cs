namespace CheckoutKata.Core;

/// <summary>
/// Handles pricing rules for checkout
/// </summary>
public class FlexiblePricingRules : IPricingRules
{
    // All the item prices and offers, stored by SKU/itemcode
    private readonly Dictionary<string, ItemPrice> _itemPrices;

    /// <summary>
    /// Set up pricing rules (e.g. "A is 50, 3 for 130")
    /// </summary>
    public FlexiblePricingRules(IEnumerable<ItemPrice> itemPrices)
    {
        if (itemPrices == null)
            throw new ArgumentNullException(nameof(itemPrices));

        // Convert list into a dictionary for quick lookups
        _itemPrices = itemPrices.ToDictionary(rule => rule.Sku);
    }

    /// <summary>
    /// Work out total price for items in the cart
    /// </summary>
    public int CalculatePrice(IReadOnlyDictionary<string, int> itemCounts)
    {
        if (itemCounts == null)
            throw new ArgumentNullException(nameof(itemCounts));

        int total = 0;

        foreach (var item in itemCounts)
        {
            // Check if we have a rule for this SKU
            if (_itemPrices.TryGetValue(item.Key, out var itemPrice))
                total += itemPrice.CalculatePrice(item.Value); // Adds up price based on quantity and offers
        }

        return total;
    }

    /// <summary>
    /// Quick helper: create the standard rules (A, B, C, D)
    /// </summary>
    /// <returns></returns>
    public static FlexiblePricingRules CreateStandardRules()
    {
        var standardPricingRules = new[]
        {
            new ItemPrice("A", 50, 3, 130), // so basically, A cost 50 but 3 for 130
            new ItemPrice("B", 30, 2, 45), // B cost 30 but 2 for 45
            new ItemPrice("C", 20), // C cost 20
            new ItemPrice("D", 15) // D cost 15
        };

        return new FlexiblePricingRules(standardPricingRules);
    }
}