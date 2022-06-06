namespace design_patterns.factory_method.example_airconditioner;

public class AirConditioner
{
    private readonly Dictionary<Actions, AirConditionerFactory> _factories;

    private AirConditioner()
    {
        _factories = new Dictionary<Actions, AirConditionerFactory>();

        foreach (Actions action in Enum.GetValues(typeof(Actions)))
        {
            var factory = (AirConditionerFactory)Activator.CreateInstance(Type.GetType("FactoryMethod." + Enum.GetName(typeof(Actions), action) + "Factory"));
            _factories.Add(action, factory);
        }
    }

    public static AirConditioner InitializeFactories() => new();

    public IAirConditioner ExecuteCreation(Actions action, double temperature) => _factories[action].Create(temperature);
}