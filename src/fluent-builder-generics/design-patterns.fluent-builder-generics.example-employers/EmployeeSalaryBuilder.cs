namespace design_patterns.fluent_builder_generics.example_employers;

public class EmployeeSalaryBuilder<T> : EmployeePositionBuilder<EmployeeSalaryBuilder<T>> where T : EmployeeSalaryBuilder<T>
{
    public T WithSalary(double salary)
    {
        employee.Salary = salary;
        return (T)this;
    }
}