using solid_principles.isp.example_vehicles;

ICar _car = new Car();
IAirplane _airplane = new Airplane();
IMultiFunctionalVehicle vehicles = new MultiFunctionalCar(_car, _airplane);
vehicles.Drive();
vehicles.Fly();