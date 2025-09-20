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
}