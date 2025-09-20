# Supermarket Checkout Kata

Supermarket Checkout app in .NET 8. Scan items, gets total, and handle special offers

### Pricing Rules
- A -> 50 each or 3 for 130  
- B -> 30 each or 2 for 45  
- C -> 20 each  
- D -> 15 each  


## How?
- Checkout = scan items and get the total  
- ICheckout = the contract
- BasicPricingRules = hardcoded prices (A, B, C, D)  
- FlexiblePricingRules = lets you plug in your own prices/offers  
- ItemPrice = one items price + optional deal  


## Things it handles:
- Bulk deals (like 3 for 130/ 2 for 45)
- Order doesn’t matter when scanning
- Easy to swap in new pricing rules
- Ignores invalid input instead of crashing
- Full xUnit test coverage

## Running tests

Running all tests:
```bash
dotnet test
```
Covers basics, special offers, edge cases, order independence, and custom pricing rules.