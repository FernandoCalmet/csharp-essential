using design_patterns.command.example_products;

static void Execute(Product product, ModifyPrice modifyPrice, ICommand productCommand)
{
    modifyPrice.SetCommand(productCommand);
    modifyPrice.Invoke();
}

var modifyPrice = new ModifyPrice();
var product = new Product("Phone", 500);

Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 100));
Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 25));
Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 2500));

Console.WriteLine(product);
Console.WriteLine();

modifyPrice.UndoActions();
Console.WriteLine(product);