namespace CheckoutKata.Core;

public class BasicPricingRules : IPricingRules
{
    public int CalculatePrice(Dictionary<string, int> itemCounts)
    {
        if (itemCounts == null)
            throw new ArgumentNullException(nameof(itemCounts));

        int totalPrice = 0;

        foreach (var item in itemCounts)
        {
            string itemCode = item.Key;
            int quantity = item.Value;

            totalPrice += itemCode switch
            {
                "A" => CalculatePriceForA(quantity),
                "B" => CalculatePriceForB(quantity),
                "C" => quantity * 20,
                "D" => quantity * 15,
                _ => 0
            };
        }

        return totalPrice;
    }

    private int CalculatePriceForA(int count)
    {
        int specialOffers = count / 3; // number of 3 for 130 offer
        int remainingItems  = count % 3; // leftover items not in an offer
        return specialOffers * 130 + remainingItems * 50;
    }

    private int CalculatePriceForB(int count)
    {
        int specialOffers = count / 2; // number of 2 for 45 offer
        int remainingItems  = count % 2; // leftover items not in an offer
        return specialOffers * 45 + remainingItems * 30;
    }
}