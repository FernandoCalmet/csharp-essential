namespace design_patterns.strategy.example_salary_calculator;

public interface ISalaryCalculator
{
    double CalculateTotalSalary(IEnumerable<DeveloperReport> reports);
}