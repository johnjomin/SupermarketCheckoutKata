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
}