namespace solid_principles.ocp.example_computer_monitors_filter;

public interface ISpecification<T>
{
    bool isSatisfied(T item);
}