namespace solid_principles.isp.example_vehicles;

public class MultiFunctionalCar : IMultiFunctionalVehicle
{
    private readonly ICar _car;
    private readonly IAirplane _airplane;
    public MultiFunctionalCar(ICar car, IAirplane airplane)
    {
        _car = car;
        _airplane = airplane;
    }
    public void Drive()
    {
        _car.Drive();
    }
    public void Fly()
    {
        _airplane.Fly();
    }
}