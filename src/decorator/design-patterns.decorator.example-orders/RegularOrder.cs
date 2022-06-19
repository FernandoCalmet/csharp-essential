namespace design_patterns.decorator.example_orders;

public class RegularOrder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a regular order");
        return products.Sum(x => x.Price);
    }
}