namespace design_patterns.command.example_products;

public interface ICommand
{
    void ExecuteAction();
    void UndoAction();
}