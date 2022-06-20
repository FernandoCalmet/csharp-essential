namespace solid_principles.ocp.example_calculator;

public class SeniorDevSalaryCalculator : BaseSalaryCalculator
{
    public SeniorDevSalaryCalculator(DeveloperReport report)
        : base(report)
    {
    }
    public override double CalculateSalary() => DeveloperReport.HourlyRate * DeveloperReport.WorkingHours * 1.2;
}