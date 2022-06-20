namespace solid_principles.ocp.example_computer_monitors_filter;

public class MonitorTypeSpecification : ISpecification<ComputerMonitor>
{
    private readonly MonitorType _type;
    public MonitorTypeSpecification(MonitorType type)
    {
        _type = type;
    }
    public bool isSatisfied(ComputerMonitor item) => item.Type == _type;
}