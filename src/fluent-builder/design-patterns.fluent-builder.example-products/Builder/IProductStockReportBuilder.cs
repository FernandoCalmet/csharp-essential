namespace design_patterns.fluent_builder.example_products.Builder;

public interface IProductStockReportBuilder
{
    void BuildHeader();
    void BuildBody();
    void BuildFooter();
    ProductStockReport GetReport();
}