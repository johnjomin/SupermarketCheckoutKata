namespace CheckoutKata.Core;

public class Checkout
{
    private int _countA = 0;
    private int _countB = 0;
    private int _countC = 0;
    private int _countD = 0;

    public void Scan(string item)
    {
        if (item == "A")
        {
            _countA++;
        }
        else if (item == "B")
        {
            _countB++;
        }
        else if (item == "C")
        {
            _countC++;
        }
        else if (item == "D")
        {
            _countD++;
        }
    }

    public int GetTotalPrice()
    {
        int total = 0;

        // Item A: 50 each, 3 for 130
        int specialOfferA = _countA / 3;
        int remainingA = _countA % 3;
        total += specialOfferA * 130 + remainingA * 50;

        // Item B: 30 each
        total += _countB * 30;

        // Item C: 20 each
        total += _countC * 20;

        // Item D: 15 each
        total += _countD * 15;

        return total;
    }
}