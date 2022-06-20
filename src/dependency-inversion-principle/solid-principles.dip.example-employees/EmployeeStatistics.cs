namespace solid_principles.dip.example_employees;

public class EmployeeStatistics
{
    private readonly IEmployeeSearchable _emp;
    public EmployeeStatistics(IEmployeeSearchable emp)
    {
        _emp = emp;
    }
    public int CountFemaleManagers() =>
    _emp.GetEmployeesByGenderAndPosition(Gender.Female, Position.Manager).Count();
}