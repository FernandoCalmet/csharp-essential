namespace design_patterns.strategy.example_salary_calculator;

public class DeveloperReport
{
    public int Id { get; set; }
    public string Name { get; set; }
    public DeveloperLevel Level { get; set; }
    public int WorkingHours { get; set; }
    public double HourlyRate { get; set; }

    public double CalculateSalary() => WorkingHours * HourlyRate;
}