namespace design_patterns.fluent_builder_generics.example_employers;

public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
{
    public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
}