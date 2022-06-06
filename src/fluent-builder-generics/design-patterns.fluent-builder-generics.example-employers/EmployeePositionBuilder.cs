namespace design_patterns.fluent_builder_generics.example_employers;

public class EmployeePositionBuilder<T> : EmployeeInfoBuilder<EmployeePositionBuilder<T>> where T : EmployeePositionBuilder<T>
{
    public T AtPosition(string position)
    {
        employee.Position = position;
        return (T)this;
    }
}