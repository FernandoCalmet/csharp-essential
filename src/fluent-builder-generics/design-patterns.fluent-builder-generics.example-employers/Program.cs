using design_patterns.fluent_builder_generics.example_employers;

class Program
{
    static void Main(string[] args)
    {
        var emp = EmployeeBuilderDirector
            .NewEmployee
            .SetName("Fernando")
            .AtPosition("Software Developer")
            .WithSalary(3500)
            .Build();

        Console.WriteLine(emp);
    }
}