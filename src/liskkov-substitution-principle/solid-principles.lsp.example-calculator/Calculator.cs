namespace solid_principles.lsp.example_calculator;

public abstract class Calculator
{
    protected readonly int[] _numbers;
    public Calculator(int[] numbers)
    {
        _numbers = numbers;
    }
    public abstract int Calculate();
}