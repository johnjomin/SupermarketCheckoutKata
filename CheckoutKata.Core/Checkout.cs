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
        else if (item == "B")
        {
            _totalPrice += 30;
        }
        else if (item == "C")
        {
            _totalPrice += 20;
        }
        else if (item == "D")
        {
            _totalPrice += 15;
        }
    }

    public int GetTotalPrice()
    {
        return _totalPrice;
    }
}