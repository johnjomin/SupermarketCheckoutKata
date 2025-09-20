namespace CheckoutKata.Core;

/// <summary>
/// Checkout system that scans items and works out the total
/// </summary>
public class Checkout : ICheckout
{
    private readonly IPricingRules _pricingRules;
    private readonly Dictionary<string, int> _itemCounts = new();

    /// <summary>
    /// default checkout
    /// </summary>
    public Checkout() : this(new BasicPricingRules())
    {
    }

    /// <summary>
    /// Checkout with custom pricing rules
    /// </summary>
    public Checkout(IPricingRules pricingRules)
    {
        _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
    }

    /// <inheritdoc />
    public void Scan(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
            return;

        _itemCounts[item] = _itemCounts.GetValueOrDefault(item, 0) + 1;
    }

    /// <inheritdoc />
    public int GetTotalPrice()
    {
        return _pricingRules.CalculatePrice(_itemCounts);
    }
}