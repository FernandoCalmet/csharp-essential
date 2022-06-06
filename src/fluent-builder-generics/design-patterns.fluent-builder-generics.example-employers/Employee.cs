namespace design_patterns.fluent_builder_generics.example_employers;

public class Employee
{
    public string Name { get; set; } = string.Empty;
    public string Position { get; set; } = string.Empty;
    public double Salary { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Position: {Position}, Salary: {Salary}";
    }
}