namespace design_patterns.strategy.example_salary_calculator;

public class SalaryCalculator
{
    private ISalaryCalculator _calculator;
    public SalaryCalculator(ISalaryCalculator calculator)
    {
        _calculator = calculator;
    }
    public void SetCalculator(ISalaryCalculator calculator) => _calculator = calculator;
    public double Calculate(IEnumerable<DeveloperReport> reports) => _calculator.CalculateTotalSalary(reports);
}