namespace solid_principles.ocp.example_calculator;

public class SalaryCalculator
{
    private readonly IEnumerable<BaseSalaryCalculator> _developerCalculation;
    public SalaryCalculator(IEnumerable<BaseSalaryCalculator> developerCalculation)
    {
        _developerCalculation = developerCalculation;
    }
    public double CalculateTotalSalaries()
    {
        double totalSalaries = 0D;
        foreach (var devCalc in _developerCalculation)
        {
            totalSalaries += devCalc.CalculateSalary();
        }
        return totalSalaries;
    }
}