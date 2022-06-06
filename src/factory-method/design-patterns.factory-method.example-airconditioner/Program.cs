using design_patterns.factory_method.example_airconditioner;

AirConditioner
    .InitializeFactories()
    .ExecuteCreation(Actions.Cooling, 22.5)
    .Operate();