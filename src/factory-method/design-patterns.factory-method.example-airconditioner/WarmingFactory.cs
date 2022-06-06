namespace design_patterns.factory_method.example_airconditioner;

public class WarmingFactory : AirConditionerFactory
{
    public override IAirConditioner Create(double temperature) => new WarmingManager(temperature);
}