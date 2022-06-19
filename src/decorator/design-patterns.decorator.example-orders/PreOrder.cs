namespace design_patterns.decorator.example_orders;

public class PreOrder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a preorder.");
        return products.Sum(x => x.Price) * 0.9;
    }
}