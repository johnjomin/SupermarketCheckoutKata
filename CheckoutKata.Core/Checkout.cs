namespace CheckoutKata.Core;

public class Checkout
{
    private readonly IPricingRules _pricingRules;
    private readonly Dictionary<string, int> _itemCounts = new();

    public Checkout() : this(new BasicPricingRules())
    {
    }

    public Checkout(IPricingRules pricingRules)
    {
        _pricingRules = pricingRules;
    }

    public void Scan(string item)
    {
        if (_itemCounts.ContainsKey(item))
        {
            _itemCounts[item]++;
        }
        else
        {
            _itemCounts[item] = 1;
        }
    }

    public int GetTotalPrice()
    {
        return _pricingRules.CalculatePrice(_itemCounts);
    }
}