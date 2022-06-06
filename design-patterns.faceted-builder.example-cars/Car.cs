namespace design_patterns.faceted_builder.example_cars;

public class Car
{
    public string Type { get; set; } = string.Empty;
    public string Color { get; set; } = string.Empty;
    public int NumberOfDoors { get; set; }

    public string City { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;

    public override string ToString()
    {
        return $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
    }
}