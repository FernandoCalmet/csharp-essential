namespace design_patterns.fluent_builder.example_products;

class Program
{
    static void Main(string[] args)
    {
        var products = new List<Product>
        {
            new Product { Name = "Monitor", Price = 200.50 },
            new Product { Name = "Mouse", Price = 20.41 },
            new Product { Name = "Keyboard", Price = 30.15}
        };

        #region Builder
        var builder = new Builder.ProductStockReportBuilder(products);
        var director = new Builder.ProductStockReportDirector(builder);
        director.BuildStockReport();
        var report = builder.GetReport();
        Console.WriteLine(report);
        #endregion

        #region FluentBuilder   
        var fluentBuilder = new FluentBuilder.ProductStockReportBuilder(products);
        var fluentDirector = new FluentBuilder.ProductStockReportDirector(fluentBuilder);
        fluentDirector.BuildStockReport();
        var fluentReport = fluentBuilder.GetReport();
        Console.WriteLine(fluentReport);
        #endregion
    }
}