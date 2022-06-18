namespace design_patterns.strategy.example_salary_calculator;

public class SeniorDevSalaryCalculator : ISalaryCalculator
{
    public double CalculateTotalSalary(IEnumerable<DeveloperReport> reports) =>
        reports
            .Where(r => r.Level == DeveloperLevel.Senior)
            .Select(r => r.CalculateSalary() * 1.2)
            .Sum();
}