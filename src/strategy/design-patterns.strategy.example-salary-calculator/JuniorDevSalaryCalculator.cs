namespace design_patterns.strategy.example_salary_calculator;

public class JuniorDevSalaryCalculator : ISalaryCalculator
{
    public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports) =>
        reports
            .Where(r => r.Level == DeveloperLevel.Junior)
            .Select(r => r.CalculateSalary())
            .Sum();
}