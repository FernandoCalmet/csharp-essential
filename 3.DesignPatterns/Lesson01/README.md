# Patrón de diseño: Builder y Fluent Builder

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Implementación del patrón de diseño del constructor

Vamos a escribir un ejemplo sencillo de cómo crear un informe de stock para todos los productos de nuestra tienda.

Entonces, comencemos con una clase `Product` simplificada :

```csharp
public class Product
{
    public string Name { get; set; }
    public double Price { get; set; }
}
```

Usaremos esta clase solo para almacenar algunos datos básicos sobre un solo producto.

Nuestro objeto de informe de existencias constará de las partes de encabezado, cuerpo y pie de página. Entonces, es bastante lógico dividir el proceso de construcción de objetos en esas tres acciones. Primero, comencemos con la clase `ProductStockReport`:

```csharp
public class ProductStockReport
{
    public string HeaderPart { get; set; }
    public string BodyPart { get; set; }
    public string FooterPart { get; set; }

    public override string ToString() =>
        new StringBuilder()
        .AppendLine(HeaderPart)
        .AppendLine(BodyPart)
        .AppendLine(FooterPart)
        .ToString();
}
```

Este es el objeto que vamos a construir con el patrón de diseño `Builder`.

Para continuar, necesitamos una interfaz de constructor para organizar el proceso de construcción:

```csharp
public interface IProductStockReportBuilder
{
    void BuildHeader();
    void BuildBody();
    void BuildFooter();
    ProductStockReport GetReport();
}
```

Podemos ver que la clase de constructor de concreto que va a implementar esta interfaz, necesita crear todas las partes para nuestro objeto de informe de existencias y devolver ese objeto también. Entonces, implementemos nuestra clase de constructor de concreto:

```csharp
public class ProductStockReportBuilder : IProductStockReportBuilder
{
    private ProductStockReport _productStockReport;
    private IEnumerable<Product> _products;

    public ProductStockReportBuilder(IEnumerable<Product> products)
    {
        _products = products;
        _productStockReport = new ProductStockReport();
    }

    public void BuildHeader()
    {
        _productStockReport.HeaderPart = $"STOCK REPORT FOR ALL THE PRODUCTS ON DATE: {DateTime.Now}\n";
    }

    public void BuildBody()
    {
        _productStockReport.BodyPart = string.Join(Environment.NewLine, _products.Select(p => $"Product name: {p.Name}, product price: {p.Price}"));
    }

    public void BuildFooter()
    {
        _productStockReport.FooterPart = "\nReport provided by the IT_PRODUCTS company.";
    }

    public ProductStockReport GetReport()
    {
        var productStockReport = _productStockReport;
        Clear();
        return productStockReport;
    }

    private void Clear() => _productStockReport = new ProductStockReport();
}
```

Esta lógica es bastante sencilla. Recibimos todos los productos necesarios para nuestro informe y creamos una instancia del objeto `_productStockReport`. Luego, creamos todas las partes de nuestro objeto y finalmente lo devolvemos. En el método `GetReport`, restablecemos nuestro objeto y preparamos una nueva instancia para estar lista para crear otro informe. Este es un comportamiento habitual pero no es obligatorio.

Una vez que nuestra lógica de construcción termina, podemos comenzar a construir nuestro objeto en una clase de cliente o incluso encapsular el proceso de construcción de la clase de cliente dentro de una clase de Director. Bueno, esto es exactamente lo que vamos a hacer:

```csharp
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
```

## Crear el objeto StockReport

Una vez que hayamos terminado todo este trabajo, podemos comenzar a construir nuestro objeto:

```csharp
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

        var builder = new ProductStockReportBuilder(products);
        var director = new ProductStockReportDirector(builder);
        director.BuildStockReport();

        var report = builder.GetReport();
        Console.WriteLine(report);
    }
}
```

El resultado :

```bash
STOCK REPORT FOR ALL THE PRODUCTS ON DATE: 26/12/2020 12:41:28 PM

Product name: Monitor, product price: 200.5
Product name: Mouse, product price: 20.41
Product name: Keyboard, product price: 30.15

Report provided by the IT_PRODUCTS company.

Press any key to continue ...
```

Excelente. Hemos creado nuestro objeto con el patrón de diseño Builder.

## Fluent Builder

El constructor Fluent es una pequeña variación del patrón de diseño del constructor, que nos permite encadenar las llamadas de nuestro constructor hacia diferentes acciones. Para implementar el constructor Fluent, primero cambiaremos la interfaz del constructor:

```csharp
public interface IProductStockReportBuilder
{
    IProductStockReportBuilder BuildHeader();
    IProductStockReportBuilder BuildBody();
    IProductStockReportBuilder BuildFooter();
    ProductStockReport GetReport();
}
```

También tenemos que modificar la implementación de la clase `ProductStockReportBuilder`:

```csharp
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
```

Como resultado de estas modificaciones, podemos encadenar las llamadas en la clase `Director`:

```csharp
public void BuildStockReport()
{
    _productStockReportBuilder
        .BuildHeader()
        .BuildBody()
        .BuildFooter();
}
```

Si iniciamos nuestra aplicación ahora, el resultado será el mismo, pero esta vez usamos la interfaz fluida.

## Conclusión

En este artículo, hemos aprendido cómo crear Builder Design Pattern y cómo implementarlo en nuestro proyecto para crear objetos complejos. Además, hemos ampliado nuestro ejemplo para utilizar la interfaz Fluent, que nos permite encadenar nuestras llamadas de Builder.
<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com