namespace design_patterns.fluent_builder.example_products.FluentBuilder;

public class ProductStockReportBuilder : IProductStockReportBuilder
{
    private ProductStockReport _productStockReport;
    private readonly IEnumerable<Product> _products;

    public ProductStockReportBuilder(IEnumerable<Product> products)
    {
        _products = products;
        _productStockReport = new ProductStockReport();
    }

    public IProductStockReportBuilder BuildHeader()
    {
        _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
        return this;
    }

    public IProductStockReportBuilder BuildBody()
    {
        _productStockReport.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
        return this;
    }

    public IProductStockReportBuilder BuildFooter()
    {
        _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
        return this;
    }

    public ProductStockReport GetReport()
    {
        var productStockReport = _productStockReport;
        Clear();
        return productStockReport;
    }

    private void Clear() => _productStockReport = new ProductStockReport();
}