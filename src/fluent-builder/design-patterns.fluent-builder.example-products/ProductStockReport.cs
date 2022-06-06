using System.Text;

namespace design_patterns.fluent_builder.example_products;

public class ProductStockReport
{
    public string HeaderPart { get; set; } = string.Empty;
    public string BodyPart { get; set; } = string.Empty;
    public string FooterPart { get; set; } = string.Empty;

    public override string ToString() =>
        new StringBuilder()
        .AppendLine(HeaderPart)
        .AppendLine(BodyPart)
        .AppendLine(FooterPart)
        .ToString();
}