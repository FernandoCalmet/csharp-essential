namespace design_patterns.fluent_builder_generics.example_employers;

public class EmployeeInfoBuilder<T> : EmployeeBuilder where T : EmployeeInfoBuilder<T>
{
    public T SetName(string name)
    {
        employee.Name = name;
        return (T)this;
    }
}