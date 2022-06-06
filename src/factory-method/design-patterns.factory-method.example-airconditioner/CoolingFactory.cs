namespace design_patterns.factory_method.example_airconditioner;

public class CoolingFactory : AirConditionerFactory
{
    public override IAirConditioner Create(double temperature) => new CoolingManager(temperature);
}