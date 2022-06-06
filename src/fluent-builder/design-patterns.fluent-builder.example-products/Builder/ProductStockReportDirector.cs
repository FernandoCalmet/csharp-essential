namespace design_patterns.fluent_builder.example_products.Builder;

public class ProductStockReportDirector
{
    private readonly IProductStockReportBuilder _productStockReportBuilder;

    public ProductStockReportDirector(IProductStockReportBuilder productStockReportBuilder)
    {
        _productStockReportBuilder = productStockReportBuilder;
    }

    public void BuildStockReport()
    {
        _productStockReportBuilder.BuildHeader();
        _productStockReportBuilder.BuildBody();
        _productStockReportBuilder.BuildFooter();
    }
}