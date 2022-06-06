namespace design_patterns.factory_method.example_airconditioner;

public abstract class AirConditionerFactory
{
    public abstract IAirConditioner Create(double temperature);
}