namespace CheckoutKata.Core;

/// <summary>
/// Holds pricing info for one item (e.g. "A costs 50, 3 for 130")
/// </summary>
public record ItemPrice(string Sku, int UnitPrice, int? SpecialQuantity = null, int? SpecialPrice = null)
{
    /// <summary>
    /// Work out the price for a given quantity
    /// </summary>
    public int CalculatePrice(int quantity)
    {
        // If there's a special offer, apply it
        if (SpecialQuantity.HasValue && SpecialPrice.HasValue)
        {
            int specialOffers = quantity / SpecialQuantity.Value; // how many offers fit
            int remainder = quantity % SpecialQuantity.Value; // items outside the offer
            return specialOffers * SpecialPrice.Value + remainder * UnitPrice;
        }

        // Otherwise just unit price × quantity
        return quantity * UnitPrice;
    }
}