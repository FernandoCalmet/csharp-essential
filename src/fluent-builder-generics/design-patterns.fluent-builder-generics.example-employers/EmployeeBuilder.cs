namespace design_patterns.fluent_builder_generics.example_employers;

public abstract class EmployeeBuilder
{
    protected Employee employee;

    public EmployeeBuilder()
    {
        employee = new Employee();
    }

    public Employee Build() => employee;
}