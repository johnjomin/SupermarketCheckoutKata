namespace CheckoutKata.Core;

public class Checkout
{
    private int _totalPrice = 0;

    public void Scan(string item)
    {
        if (item == "A")
        {
            _totalPrice += 50;
        }
    }

    public int GetTotalPrice()
    {
        return _totalPrice;
    }
}