using solid_principles.dip.example_employees;

var empManager = new EmployeeManager();
empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.Female, Position = Position.Manager });
empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.Male, Position = Position.Administrator });
var stats = new EmployeeStatistics(empManager);
Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManagers()}");