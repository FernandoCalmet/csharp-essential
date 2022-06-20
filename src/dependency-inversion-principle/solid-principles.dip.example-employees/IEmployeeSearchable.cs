namespace solid_principles.dip.example_employees;

public interface IEmployeeSearchable
{
    IEnumerable<Employee> GetEmployeesByGenderAndPosition(Gender gender, Position position);
}