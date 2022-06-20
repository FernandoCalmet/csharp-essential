namespace solid_principles.ocp.example_computer_monitors_filter;

public class ScreenSpecification : ISpecification<ComputerMonitor>
{
    private readonly Screen _screen;
    public ScreenSpecification(Screen screen)
    {
        _screen = screen;
    }
    public bool isSatisfied(ComputerMonitor item) => item.Screen == _screen;
}