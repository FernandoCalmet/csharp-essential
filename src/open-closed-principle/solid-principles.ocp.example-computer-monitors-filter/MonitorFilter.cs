namespace solid_principles.ocp.example_computer_monitors_filter;

public class MonitorFilter : IFilter<ComputerMonitor>
{
    public List<ComputerMonitor> Filter(IEnumerable<ComputerMonitor> monitors, ISpecification<ComputerMonitor> specification) =>
        monitors.Where(m => specification.isSatisfied(m)).ToList();
}