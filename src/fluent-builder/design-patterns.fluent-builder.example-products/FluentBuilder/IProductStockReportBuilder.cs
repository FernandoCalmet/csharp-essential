namespace design_patterns.fluent_builder.example_products.FluentBuilder;

public interface IProductStockReportBuilder
{
    IProductStockReportBuilder BuildHeader();
    IProductStockReportBuilder BuildBody();
    IProductStockReportBuilder BuildFooter();
    ProductStockReport GetReport();
}