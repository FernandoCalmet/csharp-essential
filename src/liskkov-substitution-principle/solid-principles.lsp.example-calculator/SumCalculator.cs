namespace solid_principles.lsp.example_calculator;

public class SumCalculator : Calculator
{
    public SumCalculator(int[] numbers)
        : base(numbers)
    {
    }
    public override int Calculate() => _numbers.Sum();
}