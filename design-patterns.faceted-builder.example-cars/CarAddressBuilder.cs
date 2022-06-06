namespace design_patterns.faceted_builder.example_cars;

public class CarAddressBuilder : CarBuilderFacade
{
    public CarAddressBuilder(Car car)
    {
        Car = car;
    }

    public CarAddressBuilder InCity(string city)
    {
        Car.City = city;
        return this;
    }

    public CarAddressBuilder AtAddress(string address)
    {
        Car.Address = address;
        return this;
    }
}