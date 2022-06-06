namespace design_patterns.fluent_builder.example_products.FluentBuilder;

public class ProductStockReportDirector
{
    private readonly IProductStockReportBuilder _productStockReportBuilder;

    public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
    {
        _productStockReportBuilder = productStockReportBuilder;
    }

    public void BuildStockReport()
    {
        _productStockReportBuilder
            .BuildHeader()
            .BuildBody()
            .BuildFooter();
    }
}