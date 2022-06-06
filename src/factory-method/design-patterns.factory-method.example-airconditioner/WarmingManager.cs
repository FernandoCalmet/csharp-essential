namespace design_patterns.factory_method.example_airconditioner;

public class WarmingManager : IAirConditioner
{
    private readonly double _temperature;

    public WarmingManager(double temperature)
    {
        _temperature = temperature;
    }

    public void Operate()
    {
        Console.WriteLine($"Warming the room to the required temperature of {_temperature} degrees.");
    }
}