namespace CheckoutKata.Core;

public class Checkout : ICheckout
{
    private readonly IPricingRules _pricingRules;
    private readonly Dictionary<string, int> _itemCounts = new();

    public Checkout() : this(new BasicPricingRules())
    {
    }

    public Checkout(IPricingRules pricingRules)
    {
        _pricingRules = pricingRules ?? throw new ArgumentNullException(nameof(pricingRules));
    }

    public void Scan(string item)
    {
        if (string.IsNullOrWhiteSpace(item))
            return; // Ignore invalid input

        if (_itemCounts.ContainsKey(item))
            _itemCounts[item]++;
        else
            _itemCounts[item] = 1;
    }

    public int GetTotalPrice()
    {
        return _pricingRules.CalculatePrice(_itemCounts);
    }
}