using CheckoutKata.Core;
using Xunit;

namespace CheckoutKata.Tests;

public class CheckoutTests
{
    [Fact]
    public void CanCreateCheckout()
    {
        // Arrange & Act
        var checkout = new Checkout();

        // Assert
        Assert.NotNull(checkout);
    }

    [Fact]
    public void GetTotalPrice_NoItemsScanned_ReturnsZero()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(0, total);
    }

    [Theory]
    [InlineData("A", 50)]
    [InlineData("B", 30)]
    [InlineData("C", 20)]
    [InlineData("D", 15)]
    public void Scan_SingleItem_ReturnsCorrectPrice(string sku, int expectedPrice)
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan(sku);
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(expectedPrice, total);
    }

    [Fact]
    public void Scan_MultipleItems_AccumulatesCorrectly()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(100, total); // 50 + 30 + 20
    }

    [Theory]
    [InlineData("AAA", 130)]
    [InlineData("AAAA", 180)]
    [InlineData("AAAAA", 230)]
    [InlineData("AAAAAA", 260)]
    [InlineData("BB", 45)]
    [InlineData("BBB", 75)]
    [InlineData("BBBB", 90)]
    [InlineData("BBBBB", 120)]
    public void Scan_SpecialOffers_AppliesOptimalPricing(string items, int expectedTotal)
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        foreach (char item in items)
        {
            checkout.Scan(item.ToString());
        }
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(expectedTotal, total);
    }

    [Theory]
    [InlineData("BAB", 95)]
    [InlineData("ABB", 95)]
    [InlineData("BBA", 95)]
    [InlineData("ABAB", 125)]
    [InlineData("BABA", 125)]
    public void Scan_ItemsInDifferentOrder_SameTotal(string items, int expectedTotal)
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        foreach (char item in items)
        {
            checkout.Scan(item.ToString());
        }
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(expectedTotal, total);
    }

    [Theory]
    [InlineData("X", 0)]
    [InlineData("AXB", 80)]
    [InlineData("", 0)]
    [InlineData("a", 0)]
    [InlineData("1", 0)]
    [InlineData(" ", 0)]
    [InlineData("A B", 80)]
    public void Scan_InvalidInputs_IgnoresSilently(string items, int expectedTotal)
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        foreach (char item in items)
        {
            checkout.Scan(item.ToString());
        }
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(expectedTotal, total);
    }

    [Fact]
    public void Checkout_WithCustomPricingRules_UsesInjectedRules()
    {
        // Arrange
        var customPricing = new TestPricingRules(); // custom pricing rule object that cost 10
        var checkout = new Checkout(customPricing);

        // Act
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("C");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(30, total); // 3 items * 10 each = 30
    }

    [Fact]
    public void Checkout_WithNullPricingRules_ThrowsArgumentNullException()
    {
        // Arrange, Act & Assert
        Assert.Throws<ArgumentNullException>(() => new Checkout(null!));
    }

    [Fact]
    public void Scan_LargeQuantities_PerformanceTest()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        for (int i = 0; i < 1000; i++)
        {
            checkout.Scan("A");
            checkout.Scan("B");
        }
        var total = checkout.GetTotalPrice();

        // Assert
        /*
         1000 × A = (333 × 130) + 50 = 43,340
         1000 × B = 500 × 45 = 22,500
         Total = 65,840
        */ 
        Assert.Equal(65840, total);
    }

    [Fact]
    public void GetTotalPrice_CalledMultipleTimes_ReturnsConsistentResult()
    {
        // Arrange
        var checkout = new Checkout();
        checkout.Scan("A");
        checkout.Scan("B");
        checkout.Scan("A");

        // Act
        var total1 = checkout.GetTotalPrice();
        var total2 = checkout.GetTotalPrice();
        var total3 = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(total1, total2);
        Assert.Equal(total2, total3);
        Assert.Equal(130, total1); // 2A=100 + 1B=30
    }

    [Fact]
    public void Scan_MixedBasketWithMultipleOffers_CalculatesCorrectly()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A"); // 3A = 130
        checkout.Scan("B");
        checkout.Scan("B"); // 2B = 45
        checkout.Scan("A"); // 1A = 50
        checkout.Scan("C");
        checkout.Scan("C"); // 2C = 40
        checkout.Scan("D"); // 1D = 15
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(280, total); // 130 + 45 + 50 + 40 + 15 = 280
    }
}