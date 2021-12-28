# Patrón de diseño: Decorator

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Acerca del patrón de diseño del decorador

Un decorador es un patrón de diseño estructural que nos permite extender el comportamiento de los objetos colocando estos objetos en una clase contenedora especial. El patrón de diseño Decorator es bastante popular en C # debido al hecho de que nos ayuda a agregar comportamientos dinámicamente a los objetos envueltos.

La estructura de este patrón consta de una clase de componente y una clase de componente de hormigón de una parte y una clase de decorador y una clase de decorador de hormigón en el otro lado. La clase Decorador de hormigón agregará un comportamiento adicional a nuestro Componente de hormigón.

Entonces, ¿cuándo usamos este patrón?

Bueno, deberíamos usar este patrón cuando tengamos la necesidad de agregar un comportamiento adicional a nuestros objetos. Además, deberíamos usarlo cuando sea demasiado complicado usar la herencia o cuando no tenga ningún sentido (demasiadas capas de herencia, necesidad de modificar la jerarquía de herencia existente agregando algunas capas adicionales, etc.).

Vamos a ver cómo todos estos elementos trabajan juntos dentro del patrón de diseño Decorator a través del ejemplo práctico, que hará que este patrón sea más fácil de comprender.

## Implementación del patrón de diseño del decorador

Imaginemos que tenemos una aplicación sencilla para calcular el precio total del pedido en nuestra tienda. Pero también tenemos algunas solicitudes adicionales. Si un comprador pide nuestros productos en un período de preorden, le daremos un descuento del 10 por ciento. Entonces, comencemos primero con nuestra clase `Component` :

```csharp
public abstract class OrderBase
{
    protected List<Product> products = new List<Product>
    {
        new Product {Name = "Phone", Price = 587},
        new Product {Name = "Tablet", Price = 800},
        new Product {Name = "PC", Price = 1200}
    };

    public abstract double CalculateTotalOrderPrice();
}
```

La clase Component contiene funcionalidad que se compartirá con otras clases de `Concrete Component`. Teniendo esto en cuenta, creemos los `concrete components` :

```csharp
public class RegularOrder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a regular order");
        return products.Sum(x => x.Price);
    }
}
```

```csharp
public class Preorder : OrderBase
{
    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine("Calculating the total price of a preorder.");
        return products.Sum(x => x.Price) * 0.9;
    }
}
```

Este código es bastante limpio y fácil de entender. Simplemente anulamos nuestro método abstracto `CalculateOrderPrice` y calculamos el precio total. Entonces, ahora mismo, podemos comenzar a usar estos componentes concretos:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var regularOrder = new RegularOrder();
        Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
        Console.WriteLine();

        var preOrder = new PreOrder();
        Console.WriteLine(preOrder.CalculateTotalOrderPrice());
        Console.WriteLine();
    }
}
```

Esto funciona bien.

Pero ahora, recibimos una solicitud adicional para permitir un descuento adicional del 10 por ciento a nuestros usuarios premium para el pedido por adelantado. Por supuesto, solo podríamos cambiar la clase `Preorder` con una declaración if para verificar si nuestro usuario es un usuario premium, pero eso rompería el `Principio Abierto Cerrado`. Entonces, para implementar esta solicitud adicional, comenzaremos con una clase Decorator que va a envolver nuestro objeto `OrderBase`:

```csharp
public class OrderDecorator : OrderBase
{
    protected OrderBase order;

    public OrderDecorator(OrderBase order)
    {
        this.order = order;
    }

    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine($"Calculating the total price in a decorator class");
        return order.CalculateTotalOrderPrice();
    }
}
```

Ahora, podemos implementar la clase `PremiumPreorder(Concrete Decorator):

```csharp
public class PremiumPreorder : OrderDecorator
{
    public PremiumPreorder(OrderBase order) 
        : base(order)
    {
    }

    public override double CalculateTotalOrderPrice()
    {
        Console.WriteLine($"Calculating the total price in the {nameof(PremiumPreorder)} class.");
        var preOrderPrice =  base.CalculateTotalOrderPrice();

        Console.WriteLine("Adding additional discount to a preorder price");
        return preOrderPrice * 0.9;
    }
}
```

En esta clase, calculamos el precio total del objeto `OrderBase`, pero también sumamos el comportamiento de descuento adicional.

Finalmente, podemos modificar la clase `Program.cs`:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var regularOrder = new RegularOrder();
        Console.WriteLine(regularOrder.CalculateTotalOrderPrice());
        Console.WriteLine();

        var preOrder = new Preorder();
        Console.WriteLine(preOrder.CalculateTotalOrderPrice());
        Console.WriteLine();

        var premiumPreorder = new PremiumPreorder(preOrder);
        Console.WriteLine(premiumPreorder.CalculateTotalOrderPrice());
    }
}
```

Como podemos ver, con el objeto `premiumPreorder` estamos envolviendo el objeto `preOrder` al que le agregamos un comportamiento adicional:

![img01](/img/01.png)

Ahora podemos ver claramente cómo nuestra clase Decorator envuelve el objeto de preorden.

Excelente.

## Conclusión

En este artículo, hemos aprendido:

- ¿Cuál es el patrón de diseño de Decorator?
- Cuando debemos usarlo
- Cómo implementar este patrón en la práctica

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com