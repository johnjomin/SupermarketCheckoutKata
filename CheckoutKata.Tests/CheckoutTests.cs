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

    [Fact]
    public void Scan_SingleItemA_Returns50()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("A");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(50, total);
    }

    [Fact]
    public void Scan_SingleItemB_Returns30()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("B");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(30, total);
    }

    [Fact]
    public void Scan_SingleItemC_Returns20()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("C");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(20, total);
    }

    [Fact]
    public void Scan_SingleItemD_Returns15()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("D");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(15, total);
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

    [Fact]
    public void Scan_ThreeAs_AppliesSpecialOffer()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(130, total); // Special offer: 3 for 130 instead of 150
    }

    [Fact]
    public void Scan_TwoBs_AppliesSpecialOffer()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("B");
        checkout.Scan("B");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(45, total); // Special offer: 2 for 45 instead of 60
    }

    [Fact]
    public void Scan_FourAs_AppliesSpecialOfferPlusOne()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        checkout.Scan("A");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(180, total); // 3 for 130 + 1 for 50 = 180
    }

    [Fact]
    public void Scan_ThreeBs_AppliesSpecialOfferPlusOne()
    {
        // Arrange
        var checkout = new Checkout();

        // Act
        checkout.Scan("B");
        checkout.Scan("B");
        checkout.Scan("B");
        var total = checkout.GetTotalPrice();

        // Assert
        Assert.Equal(75, total); // 2 for 45 + 1 for 30 = 75
    }

    [Fact]
    public void Scan_ItemsInDifferentOrder_SameTotal()
    {
        // Arrange
        var checkout1 = new Checkout();
        var checkout2 = new Checkout();

        // Act
        checkout1.Scan("B");
        checkout1.Scan("A");
        checkout1.Scan("B");
        var total1 = checkout1.GetTotalPrice();

        checkout2.Scan("A");
        checkout2.Scan("B");
        checkout2.Scan("B");
        var total2 = checkout2.GetTotalPrice();

        // Assert
        Assert.Equal(total1, total2); // Order shouldn't matter
        Assert.Equal(95, total1); // A=50 + 2B's=45 = 95
    }
}