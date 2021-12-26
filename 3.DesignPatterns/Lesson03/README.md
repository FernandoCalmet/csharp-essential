# Patrón de diseño: Faceted Builder

[![Github][github-shield]][github-url]
[![Kofi][kofi-shield]][kofi-url]
[![LinkedIn][linkedin-shield]][linkedin-url]
[![Khanakat][khanakat-shield]][khanakat-url]

## Implementación de Faceted Builder

Vamos a empezar con un modelo de objetos "complejo":

```csharp
public class Car
{
    public string Type { get; set; }
    public string Color { get; set; }
    public int NumberOfDoors { get; set; }

    public string City { get; set; }
    public string Address { get; set; }

    public override string ToString()
    {
        return $"CarType: {Type}, Color: {Color}, Number of doors: {NumberOfDoors}, Manufactured in {City}, at address: {Address}";
    }
} 
```

Tenemos la parte de información y la parte de dirección de nuestro objeto, por lo que vamos a usar dos constructores para crear este objeto completo.

Como dijimos, necesitamos una fachada, así que comencemos con eso:

```csharp
public class CarBuilderFacade
{
    protected Car Car { get; set; }

    public CarBuilderFacade()
    {
        Car = new Car();
    }

    public Car Build() => Car;
}
```

Instanciamos el objeto `Car` que queremos construir y lo exponemos a través del método Build.

Lo que necesitamos ahora es crear constructores de hormigón. Entonces, comencemos con lo que `CarInfoBuilder` debe heredar de la clase de fachada:

```csharp
public class CarInfoBuilder: CarBuilderFacade
{
    public CarInfoBuilder(Car car)
    {
        Car = car;
    }

    public CarInfoBuilder WithType(string type)
    {
        Car.Type = type;
        return this;
    }

    public CarInfoBuilder WithColor(string color)
    {
        Car.Color = color;
        return this;
    }

    public CarInfoBuilder WithNumberOfDoors(int number)
    {
        Car.NumberOfDoors = number;
        return this;
    }
}
```

Como podemos ver, recibimos, a través del constructor, un objeto que queremos construir y usamos la interfaz fluida para propósitos de construcción.

Hagamos lo mismo para la clase `CarAddresBuilder`:

```csharp
public class CarAddressBuilder: CarBuilderFacade
{
    public CarAddressBuilder(Car car)
    {
        Car = car;
    }

    public CarAddressBuilder InCity(string city)
    {
        Car.City = city;
        return this;
    }

    public CarAddressBuilder AtAddress(string address)
    {
        Car.Address = address;
        return this;
    }
}
```

En este momento tenemos ambas clases de constructores, pero no podemos empezar a construir nuestro objeto todavía porque no hemos expuesto a nuestros constructores dentro de la clase de fachada. Bueno, hagámoslo:

```csharp
public class CarBuilderFacade
{
    protected Car Car { get; set; }

    public CarBuilderFacade()
    {
        Car = new Car();
    }

    public Car Build() => Car;

    public CarInfoBuilder Info => new CarInfoBuilder(Car);
    public CarAddressBuilder Built => new CarAddressBuilder(Car);
}
```

A partir de este momento, podemos empezar a construir nuestro objeto:

```csharp
class Program
{
    static void Main(string[] args)
    {
        var car = new CarBuilderFacade()
            .Info
              .WithType("BMW")
              .WithColor("Black")
              .WithNumberOfDoors(5)
            .Built
              .InCity("Leipzig ")
              .AtAddress("Some address 254")
            .Build();

        Console.WriteLine(car);
    }
}
```

Y eso es todo. Hemos construido nuestro objeto con el enfoque Creador de facetas (Faceted Builder).

## Conclusión

Con este artículo, terminamos con la pequeña serie Builder Design Pattern.

<!--- reference style links --->
[github-shield]: https://img.shields.io/badge/-@fernandocalmet-%23181717?style=flat-square&logo=github
[github-url]: https://github.com/fernandocalmet
[kofi-shield]: https://img.shields.io/badge/-@fernandocalmet-%231DA1F2?style=flat-square&logo=kofi&logoColor=ff5f5f
[kofi-url]: https://ko-fi.com/fernandocalmet
[linkedin-shield]: https://img.shields.io/badge/-fernandocalmet-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/fernandocalmet
[linkedin-url]: https://www.linkedin.com/in/fernandocalmet
[khanakat-shield]: https://img.shields.io/badge/khanakat.com-brightgreen?style=flat-square
[khanakat-url]: https://khanakat.com