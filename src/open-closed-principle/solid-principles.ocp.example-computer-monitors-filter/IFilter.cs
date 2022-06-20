namespace solid_principles.ocp.example_computer_monitors_filter;

public interface IFilter<T>
{
    List<T> Filter(IEnumerable<T> monitors, ISpecification<T> specification);
}