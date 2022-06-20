namespace solid_principles.lsp.example_calculator;

public class EvenNumbersSumCalculator : Calculator
{
    public EvenNumbersSumCalculator(int[] numbers)
       : base(numbers)
    {
    }
    public override int Calculate() => _numbers.Where(x => x % 2 == 0).Sum();
}