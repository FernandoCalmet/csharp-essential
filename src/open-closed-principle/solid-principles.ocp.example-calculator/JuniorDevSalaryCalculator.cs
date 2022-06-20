namespace solid_principles.ocp.example_calculator;

public class JuniorDevSalaryCalculator : BaseSalaryCalculator
{
    public JuniorDevSalaryCalculator(DeveloperReport developerReport)
        : base(developerReport)
    {
    }
    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours;
}