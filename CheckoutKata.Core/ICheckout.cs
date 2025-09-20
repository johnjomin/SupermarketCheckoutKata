namespace CheckoutKata.Core;

/// <summary>
/// Contract for a checkout system
/// </summary>
public interface ICheckout
{
    /// <summary>
    /// Scan an item
    /// </summary>
    void Scan(string item);

    /// <summary>
    /// Get the total price for everything scanned + special offer
    /// </summary>
    int GetTotalPrice();
}